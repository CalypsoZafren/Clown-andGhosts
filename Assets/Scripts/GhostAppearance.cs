using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GhostAppearance : MonoBehaviour
{

    public GameObject gravesObject;
    private List<Transform> graveSites = new List<Transform>();
    public GameObject madGhostToSpawn;
    public GameObject sadGhostToSpawn;
    public Quaternion ghostRotation;
    private int currentPhase = 1;
    public int ghostsInPhase1;
    public int ghostsInPhase2;
    public int ghostsInPhase3;
    public int ghostsSleepyed = 0;
    public int ghostsMad = 0;
    public int maxGhostsMad = 5;
    private TextMeshProUGUI ghostSleepeyedText;
    public TextMeshProUGUI ghostsMadText;
    private Transform player;
    private bool allGravesFull = false;
    private DeathManager deathManagerScript;
    private float madGhostAppearanceThreshhold = .1f;
    public bool firstMadGhost = false;
    public bool firstSadGhost = false;
    public TipHolder tipHolder;
    public AudioSource backgroundAudio;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Time.timeScale = 1f;
        for (int i = 0; i < gravesObject.transform.childCount; i++)
        {
            graveSites.Add(gravesObject.transform.GetChild(i).GetComponent<Transform>());
          
          
        }

        ghostSleepeyedText = GameObject.FindGameObjectWithTag("GhostsSleepyedText").GetComponent<TextMeshProUGUI>();
        ghostsMadText = GameObject.FindGameObjectWithTag("GhostsMadText").GetComponent<TextMeshProUGUI>();
        deathManagerScript = GameObject.FindGameObjectWithTag("GameManager").GetComponent<DeathManager>();
        Debug.Log(ghostSleepeyedText);
  
       player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
       backgroundAudio = GetComponent<AudioSource>();

        StartCoroutine(GhostTimer());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            SpawnGhost();
        }

        CheckPhase();
        UpdateScore();
    }

    private void SpawnGhost() {

        if (AllGravesFull()) { 
            deathManagerScript.Death();
        }


        int checkNums = 0;
        int randomGraveIndex = UnityEngine.Random.Range(0, graveSites.Count);

        while (graveSites[randomGraveIndex].GetComponent<Grave>().isOccupied == true) { 
            randomGraveIndex = nextInList(graveSites.Count, randomGraveIndex);
            checkNums++;

            if (checkNums > 10) {
                break;
            }
        }

        if(UnityEngine.Random.Range(0f, 1f) <= madGhostAppearanceThreshhold) {
            Instantiate(sadGhostToSpawn, graveSites[randomGraveIndex].position, ghostRotation);
            if (!firstSadGhost) {
                firstSadGhost = true;
                tipHolder.Ping("Sad"); 
                Debug.Log("Should be pinging sad tip");
            }
        } else {
            Instantiate(madGhostToSpawn, graveSites[randomGraveIndex].position, ghostRotation);
            if (!firstMadGhost) {
                firstMadGhost = true;
                tipHolder.Ping("Mad");
                Debug.Log("Should be pinging mad tip");
            }
        }
        graveSites[randomGraveIndex].GetComponent<Grave>().isOccupied = true;

        

    }

    public void Ping() {

        switch(currentPhase) {
            case 1:
                SpawnGhost();
                break;
            case 2:
                SpawnGhost();
                SpawnGhost();
                break;
            case 3:
                SpawnGhost();
                SpawnGhost();
                SpawnGhost();
                break;
            default:
                break;
        }
    }


    private void CheckPhase()
    {
        if (ghostsSleepyed < ghostsInPhase1)
        {
            currentPhase = 1;
            madGhostAppearanceThreshhold = .15f;
        }
        else if (ghostsSleepyed >= ghostsInPhase1 && ghostsSleepyed < (ghostsInPhase1 + ghostsInPhase2))
        {
            currentPhase = 2;
            madGhostAppearanceThreshhold = .3f;
            backgroundAudio.pitch = 1.2f;
        }
        else if (ghostsSleepyed >= (ghostsInPhase1 + ghostsInPhase2) && ghostsSleepyed < (ghostsInPhase1 + ghostsInPhase2 + ghostsInPhase3))
        {
            currentPhase = 3;
            madGhostAppearanceThreshhold = .45f;
            backgroundAudio.pitch = 1.5f;
        }
    }


     IEnumerator GhostTimer() {
            yield return new WaitForSeconds(10);
            Ping();
            StartCoroutine(GhostTimer());
     }

    private void UpdateScore() {
        ghostSleepeyedText.text = ghostsSleepyed.ToString();
        //gameEndGhostsSleepeyedText.text = ghostsSleepyed.ToString();
        ghostsMadText.text = ghostsMad.ToString();

        if(ghostsMad == maxGhostsMad) {
            deathManagerScript.Death();
        }
    }

    public void PingPlayer() { 
        player.GetComponent<Player>().currentGrave.isOccupied = false;
    }


    private int nextInList(int length, int currentIndex) {
        switch (currentIndex)
        {
            case 0:
                currentIndex++;
                break;
            case 1:
                currentIndex++;
                break;
            case 2:
                currentIndex++;
                break;
            case 3:
                currentIndex++;
                break;
            case 4:
                currentIndex++;
                break;
            case 5:
                currentIndex = 0;
                break;
            default:
                break;
        }

        return currentIndex;

    }


    public bool AllGravesFull() {
        int gravesFull = 0;
        for (int i = 0; i <graveSites.Count; i++) {
            if(graveSites[i].GetComponent<Grave>().isOccupied) {
                gravesFull++;
            }
        }

        if (gravesFull == 6)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
    