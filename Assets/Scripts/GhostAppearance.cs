using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GhostAppearance : MonoBehaviour
{

    public GameObject gravesObject;
    private List<Transform> graveSites = new List<Transform>();
    public GameObject ghostToSpawn;
    public Quaternion ghostRotation;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < gravesObject.transform.childCount; i++)
        {
            graveSites.Add(gravesObject.transform.GetChild(i).GetComponent<Transform>());
          
          
        }

 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            SpawnGhost();
        }

    }

    private void SpawnGhost() {
        int randomGraveIndex = UnityEngine.Random.Range(0, graveSites.Count);
        Instantiate(ghostToSpawn, graveSites[randomGraveIndex].position, ghostRotation);
    }

}
