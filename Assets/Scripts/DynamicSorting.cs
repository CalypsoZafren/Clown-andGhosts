using UnityEngine;

public class DynamicSorting : MonoBehaviour
{

    private Transform sortPoint;
    private Transform playerSortPoint;
    private Transform player;
    private SpriteRenderer objectSprite;
    private SpriteRenderer playerSprite;
    


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        sortPoint = transform.GetChild(0);
        playerSortPoint = GameObject.FindGameObjectWithTag("Player").transform.GetChild(0);
        objectSprite = GetComponent<SpriteRenderer>();
        playerSprite = player.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        SortObject();
   
    }

    private void SortObject() { 
        if (playerSortPoint.position.y > sortPoint.position.y) { 
            objectSprite.sortingOrder = playerSprite.sortingOrder + 1;
        } else if(playerSortPoint.position.y < sortPoint.position.y){
            objectSprite.sortingOrder = playerSprite.sortingOrder - 1;
        }
    }

   
}


