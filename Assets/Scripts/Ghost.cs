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
        deathSequenceImage =  sequenceScript.AllDeathSequences[Random.Range(0, sequenceScript.AllDeathSequences.Count)]; 
        deathSequenceHolder.sprite = deathSequenceImage;
        ghostAppearanceScript = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GhostAppearance>();
        pocketScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Pocket>();
        Duck = pocketScript.returnDuckNum();
        Rose = pocketScript.returnRoseNum();
        Ribbon = pocketScript.returnRibbonNum();
        Nose = pocketScript.returnNoseNum();


        switch (deathSequenceImage.name) {
            case "IMG_1737_0":
                //Drowning in Lake
                if (sadGhost)
                {
                    itemsNeeded.Add(Duck);
                    itemsNeeded.Add(Rose);
                }
                else {
                    itemsNeeded.Add(Ribbon);
                    itemsNeeded.Add(Ribbon);
                }
                
                //printList();
                break;
            case "IMG_1741_0":
                //Electrocuted proposal
                if (sadGhost)
                {
                    itemsNeeded.Add(Rose);
               
                }
                else
                {
                    itemsNeeded.Add(Nose);
                    itemsNeeded.Add(Duck);
                    itemsNeeded.Add(Ribbon);
                }

               // printList(); ;
                break;
            case "IMG_1736_0":
                //Lost race to duck
                if (sadGhost)
                {
                    itemsNeeded.Add(Duck);
                    itemsNeeded.Add(Rose);
                    itemsNeeded.Add(Ribbon);
                }
                else
                {
                    itemsNeeded.Add(Nose);
                }
                    //printList();
                    break;
            case "IMG_1740_0":
                //Red nose reindeer
                if (sadGhost)
                {
                   itemsNeeded.Add(Nose);
                }
                else
                {
                    itemsNeeded.Add(Duck);
                    itemsNeeded.Add(Rose);
                    itemsNeeded.Add(Ribbon);
                }
        
               // printList();
                break;
            case "IMG_1739_0":
                //Drowning in ducks
                if (sadGhost)
                {
                    itemsNeeded.Add(Duck);
                }
                else {
                    itemsNeeded.Add(Nose);
                    itemsNeeded.Add(Ribbon);
                    itemsNeeded.Add(Rose);
                }
                
               // printList();
                break;
            case "IMG_1738_0":
                //Scarf in train
                if (sadGhost)
                {
                    itemsNeeded.Add(Ribbon);
                }
                else
                {
                    itemsNeeded.Add(Nose);
                    itemsNeeded.Add(Duck);
                    itemsNeeded.Add(Rose);
                }
                //printList();
                break;
            case "IMG_1744_0":
                //Crushed by Carnival Ball
                if (sadGhost)
                {
                    itemsNeeded.Add(Ribbon);
                    itemsNeeded.Add(Nose);
                }
                else {
                    itemsNeeded.Add(Duck);
                    itemsNeeded.Add(Rose);
                }
               
                //printList();
                break;
            case "IMG_1745_0":
                //Duck in trenchcoat
                if (sadGhost)
                {
                    itemsNeeded.Add(Nose);
                    itemsNeeded.Add(Duck);
                }
                else {
                    itemsNeeded.Add(Ribbon);
                    itemsNeeded.Add(Rose);
                }
                
                //printList();
                break;
            case "IMG_1747 (1)_0":
                //Murdered by clown
                if (sadGhost)
                {
                    itemsNeeded.Add(Nose);
                }
                else {
                    itemsNeeded.Add(Duck);
                    itemsNeeded.Add(Rose);
                    itemsNeeded.Add(Ribbon);
                }
               
                //printList();
                break;
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
