using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ghost : MonoBehaviour
{

    private string[] ArrayOfItems = { "Duck", "Nose", "Rose", "Ribbon" };
    public List<string> chosenItem;
    [SerializeField]
    private Image deathSequenceHolder;
    private DeathSequence sequenceScript;
    public Image deathSequenceImage;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sequenceScript = GameObject.FindGameObjectWithTag("GameManager").GetComponent<DeathSequence>();
        //StartCoroutine(DieAfter5());
        deathSequenceImage =  sequenceScript.AllDeathSequences[Random.Range(0, sequenceScript.AllDeathSequences.Count)]; 
        deathSequenceHolder.sprite = deathSequenceImage.sprite;

        Debug.Log(deathSequenceImage);
        switch (deathSequenceImage.name) {
            case "Drowning(DuckRose)":
                Debug.Log("Need the Nose or the Ribbon");
                break;
            case "Proposal(Rose)":
                Debug.Log("Need the Nose, the Duck, or the Ribbon");
                break;
            case "Race(DuckRibbonRose)":
                Debug.Log("Need the Nose");
                break;
            case "ReindeerRunOver(Nose)":
                Debug.Log("Need the Ribbon, the Rose, or the Duck");
                break;
            case "Smothered(Duck)":
            Debug.Log("Need the Nose, the Ribbon, or the Rose");
                break;
            case "Train(Ribbon)":
                Debug.Log("Need the Nose, the Rose, or the Duck");
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    IEnumerator DieAfter5() {
        yield return new WaitForSeconds(5.5f);
        Destroy(this.gameObject);    
    }
}
