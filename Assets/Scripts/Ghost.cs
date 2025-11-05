using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ghost : MonoBehaviour
{

    private string[] ArrayOfItems = { "Duck", "Nose", "Rose", "Ribbon" };
    public string chosenItem;
    [SerializeField]
    private List<Sprite> AllDeathSequences;
    private Sprite deathSequence;
    [SerializeField]
    private Image deathSequenceHolder;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        chosenItem = ArrayOfItems[Random.Range(0, ArrayOfItems.Length)];
        StartCoroutine(DieAfter5());
        deathSequence = AllDeathSequences[Random.Range(0, AllDeathSequences.Count)];
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
