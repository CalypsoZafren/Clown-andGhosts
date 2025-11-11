using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ghost : MonoBehaviour
{
    //items 1 = Duck, 2 = Rose, 3 = Ribbon, 4 = Nose
    public List<string> chosenItem;
    private int[] printedItems = new int[4];
   [SerializeField]
    private Image deathSequenceHolder;
    private DeathSequence sequenceScript;
    public Sprite deathSequenceImage;
    private List<int> itemsNeeded = new List<int>();
    public Sprite zzzImage;
    public Sprite booImage;
    private GhostAppearance ghostAppearanceScript;
    private bool itemFound;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sequenceScript = GameObject.FindGameObjectWithTag("GameManager").GetComponent<DeathSequence>();
        //StartCoroutine(DieAfter5());
        deathSequenceImage =  sequenceScript.AllDeathSequences[Random.Range(0, sequenceScript.AllDeathSequences.Count)]; 
        deathSequenceHolder.sprite = deathSequenceImage;
        ghostAppearanceScript = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GhostAppearance>();


        switch (deathSequenceImage.name) {
            case "IMG_1737_0":
                itemsNeeded.Add(4);
                itemsNeeded.Add(3);
                //printList();
                break;
            case "IMG_1741_0":
                itemsNeeded.Add(4);
                itemsNeeded.Add(1);
                itemsNeeded.Add(3);
               // printList(); ;
                break;
            case "IMG_1736_0":
                itemsNeeded.Add(4);
                itemsNeeded.Add(3); 
                //printList();
                break;
            case "IMG_1740_0":
                itemsNeeded.Add(1);
                itemsNeeded.Add(2);
                itemsNeeded.Add(3);
               // printList();
                break;
            case "IMG_1739_0":
                itemsNeeded.Add(4);
                itemsNeeded.Add(3);
                itemsNeeded.Add(2);
               // printList();
                break;
            case "IMG_1738_0":
                itemsNeeded.Add(4);
                itemsNeeded.Add(1);
                itemsNeeded.Add(2);
                //printList();
                break;
            case "IMG_1744_0":
                itemsNeeded.Add(1);
                itemsNeeded.Add(2);
                //printList();
                break;
            case "IMG_1745_0":
                itemsNeeded.Add(3);
                itemsNeeded.Add(4);
                //printList();
                break;
            case "IMG_1741 (1)_0":
                itemsNeeded.Add(1);
                itemsNeeded.Add(2);
                itemsNeeded.Add(3);
                //printList();
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public IEnumerator DieAfter2() {
        yield return new WaitForSeconds(2f);
        Destroy(this.gameObject);

        ghostAppearanceScript.PingGraves();
      
    }

    private void printList() {
        foreach (var item in itemsNeeded) {
            printedItems[item - 1] = item;
        }
        Debug.Log(printedItems[0] + ", " + printedItems[1] + ", " + printedItems[2] + ", " + printedItems[3]);

    }

    public void itemCheck(int itemUsed) {

        foreach (var item in itemsNeeded) {
            if (item == itemUsed) {
                itemFound = true;
            }
        }


        if (itemFound)
        {
            deathSequenceHolder.sprite = zzzImage;
            ghostAppearanceScript.ghostsSleepyed += 1;
        }
        else {
            deathSequenceHolder.sprite = booImage;
            ghostAppearanceScript.ghostsMad += 1;
        }

    }
}
