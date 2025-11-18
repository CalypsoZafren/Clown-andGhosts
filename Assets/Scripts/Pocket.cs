using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class Pocket : MonoBehaviour
{
    public Sprite roseSprite;
    public Sprite noseSprite;
    public Sprite ribbonSprite;
    public Sprite duckSprite;
    public List<Sprite> allItems;
    private List<Sprite> itemsInPocket = new List<Sprite>();
    public List<Image> pocketImages = new List<Image>();
    private int roseNum;
    private int noseNum;
    private int ribbonNum;
    private int duckNum;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        //Randomizing items in pocket
        for(int i = 0; i < 4; i++)
        {
            int tempIndex = Random.Range(0, allItems.Count);
            itemsInPocket.Add(allItems[tempIndex]);
            allItems.RemoveAt(tempIndex);
        }

        //Setting pocket images
        foreach (Image img in pocketImages)
        {
            img.sprite = itemsInPocket[pocketImages.IndexOf(img)];
            if (img.sprite == roseSprite)
            {
                roseNum = pocketImages.IndexOf(img) + 1;
            }
            else if (img.sprite == noseSprite)
            {
                noseNum = pocketImages.IndexOf(img) + 1;
            }
            else if (img.sprite == ribbonSprite)
            {
                ribbonNum = pocketImages.IndexOf(img) + 1;
            }
            else if (img.sprite == duckSprite)
            { 
                duckNum = pocketImages.IndexOf(img) + 1;
            }



                returnRoseNum();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int returnRoseNum() {

        return roseNum;
    }

    public int returnNoseNum()
    {
        return noseNum;
    }

    public int returnRibbonNum() {
        return ribbonNum;

    }

    public int returnDuckNum()
    {
        return duckNum;
    }
    }
