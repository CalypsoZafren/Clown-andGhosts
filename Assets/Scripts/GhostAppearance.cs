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
    public GameObject ghostToSpawn;
    public Quaternion ghostRotation;
    private int currentPhase = 1;
    public int ghostsInPhase1;
    public int ghostsInPhase2;
    public int ghostsInPhase3;
    public int ghostsSleepyed = 0;
    public int ghostsMad = 0;
    public int maxGhostsMad = 5;
    private TextMeshProUGUI ghostSleepeyedText;
    private TextMeshProUGUI ghostsMadText;
    private Transform player;
    private bool allGravesFull = false;
    private DeathManager deathManagerScript;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < gravesObject.transform.childCount; i++)
        {
            graveSites.Add(gravesObject.transform.GetChild(i).GetComponent<Transform>());
          
          
        }

        ghostSleepeyedText = GameObject.FindGameObjectWithTag("GhostsSleepyedText").GetComponent<TextMeshProUGUI>();
        ghostsMadText = GameObject.FindGameObjectWithTag("GhostsMadText").GetComponent<TextMeshProUGUI>();
        deathManagerScript = GameObject.FindGameObjectWithTag("GameManager").GetComponent<DeathManager>();
        Debug.Log(ghostSleepeyedText);
  
       player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

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

       
        Instantiate(ghostToSpawn, graveSites[randomGraveIndex].position, ghostRotation);
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
        }
        else if (ghostsSleepyed >= ghostsInPhase1 && ghostsSleepyed < (ghostsInPhase1 + ghostsInPhase2))
        {
            currentPhase = 2;
        }
        else if (ghostsSleepyed >= (ghostsInPhase1 + ghostsInPhase2) && ghostsSleepyed < (ghostsInPhase1 + ghostsInPhase2 + ghostsInPhase3))
        {
            currentPhase = 3;
        }
    }


     IEnumerator GhostTimer() {
            yield return new WaitForSeconds(10);
            Ping();
            StartCoroutine(GhostTimer());
     }

    private void UpdateScore() {
        ghostSleepeyedText.text = ghostsSleepyed.ToString();
        ghostsMadText.text = ghostsMad.ToString();

        if(ghostsMad == maxGhostsMad) {
            deathManagerScript.Death();
        }
    }


    public void PingGraves() { 
       foreach (Transform grave in graveSites) {
            Grave graveScript = grave.GetComponent<Grave>();
            if (graveScript.playerInRange) {
                graveScript.isOccupied = false;
                break;
            }
        }
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
    