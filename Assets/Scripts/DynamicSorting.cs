using UnityEngine;

public class DynamicSorting : MonoBehaviour
{

    private Transform sortPoint;
    private Transform player;
    private SpriteRenderer objectSprite;
    private SpriteRenderer playerSprite;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sortPoint = transform.GetChild(0);
        player = GameObject.FindGameObjectWithTag("Player").transform;
        objectSprite = GetComponent<SpriteRenderer>();
        playerSprite = player.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        SortObject();
   
    }

    private void SortObject() { 
        if (player.position.y > sortPoint.position.y) { 
            objectSprite.sortingOrder = playerSprite.sortingOrder + 1;
        } else if(player.position.y < sortPoint.position.y){
            objectSprite.sortingOrder = playerSprite.sortingOrder - 1;
        }
    }

   
}


