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
    public bool sadGhost = false;
    private int Duck;
    private int Rose;
    private int Ribbon;
    private int Nose;
    private Pocket pocketScript;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sequenceScript = GameObject.FindGameObjectWithTag("GameManager").GetComponent<DeathSequence>();
        //StartCoroutine(DieAfter5());
       
        ghostAppearanceScript = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GhostAppearance>();
        pocketScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Pocket>();
        Duck = pocketScript.returnDuckNum();
        Rose = pocketScript.returnRoseNum();
        Ribbon = pocketScript.returnRibbonNum();
        Nose = pocketScript.returnNoseNum();

        if (sadGhost)
        {
            
            deathSequenceImage = sequenceScript.AllMemorySequences[Random.Range(0, sequenceScript.AllMemorySequences.Count)];
            deathSequenceHolder.sprite = deathSequenceImage;
            sadGhostSwitch();
        }
        else {
            
            deathSequenceImage = sequenceScript.AllDeathSequences[Random.Range(0, sequenceScript.AllDeathSequences.Count)];
            deathSequenceHolder.sprite = deathSequenceImage;
            madGhostSwitch();
        }
          


        


    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public IEnumerator DieAfter2() {
        ghostAppearanceScript.PingPlayer();
        yield return new WaitForSeconds(2f);
        Destroy(this.gameObject);

        
      
    }

    private void sadGhostSwitch()
    {
        switch (deathSequenceImage.name)
        {
            case "Memory_duck-rose_0":
                itemsNeeded.Add(Duck);
                itemsNeeded.Add(Rose);
                break;
            case "Memory_duck-rose-ribbon_0":
                itemsNeeded.Add(Duck);
                itemsNeeded.Add(Rose);
                itemsNeeded.Add(Ribbon);
                break;
            case "Memory_nose-rose-ribbon_0":
                itemsNeeded.Add(Nose);
                itemsNeeded.Add(Rose);
                itemsNeeded.Add(Ribbon);
                break;
            case "Memory_rose-nose_0":
                itemsNeeded.Add(Nose);
                itemsNeeded.Add(Rose);
                break;
            case "Memory_rose-ribbon_0":
                itemsNeeded.Add(Ribbon);
                itemsNeeded.Add(Rose);
                break;
        }
    }
    


    private void madGhostSwitch() {
        switch (deathSequenceImage.name)
        {
            case "IMG_1737_0":
                //Drowning in Lake
                
               
                {
                    itemsNeeded.Add(Ribbon);
                    itemsNeeded.Add(Nose);
                }

                //printList();
                break;
            case "IMG_1741_0":
                //Electrocuted proposal
                
                
                {
                    itemsNeeded.Add(Nose);
                    itemsNeeded.Add(Duck);
                    itemsNeeded.Add(Ribbon);
                }

                // printList(); ;
                break;
            case "Death_duck-rose-ribbon_0":
                //Lost race to duck
                
                {
                    itemsNeeded.Add(Nose);
                }
                //printList();
                break;
            case "IMG_1740_0":
                //Red nose reindeer
                
                {
                    itemsNeeded.Add(Duck);
                    itemsNeeded.Add(Rose);
                    itemsNeeded.Add(Ribbon);
                }

                // printList();
                break;
            case "IMG_1739_0":
                //Drowning in ducks
                
                {
                    itemsNeeded.Add(Nose);
                    itemsNeeded.Add(Ribbon);
                    itemsNeeded.Add(Rose);
                }

                // printList();
                break;
            case "IMG_1738_0":
                //Scarf in train
                
                {
                    itemsNeeded.Add(Nose);
                    itemsNeeded.Add(Duck);
                    itemsNeeded.Add(Rose);
                }
                //printList();
                break;
            case "IMG_1744_0":
                //Crushed by Carnival Ball
                
                {
                    itemsNeeded.Add(Duck);
                    itemsNeeded.Add(Rose);
                }

                //printList();
                break;
            case "IMG_1745_0":
                //Duck in trenchcoat
                
                {
                    itemsNeeded.Add(Ribbon);
                    itemsNeeded.Add(Rose);
                }

                //printList();
                break;
            case "IMG_1747 (1)_0":
                //Murdered by clown
                
                {
                    itemsNeeded.Add(Duck);
                    itemsNeeded.Add(Ribbon);
                }

                //printList();
                break;
            case "Death_nose-rose-ribbon_0":
                //Died in field
                
                {
                    itemsNeeded.Add(Duck);

                }
                break;
        }
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
