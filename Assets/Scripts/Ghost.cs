using System.Collections;
using UnityEngine;

public class Ghost : MonoBehaviour
{

    private string[] ArrayOfItems = { "Duck", "Nose", "Rose", "Ribbon" };
    public string chosenItem;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        chosenItem = ArrayOfItems[Random.Range(0, ArrayOfItems.Length)];
        StartCoroutine(DieAfter5());
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
