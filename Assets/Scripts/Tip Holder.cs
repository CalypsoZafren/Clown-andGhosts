using System.Collections;
using UnityEngine;

public class TipHolder : MonoBehaviour
{

    private Animator tipHolderAnim;
    private GhostAppearance ghostAppearanceScript;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ghostAppearanceScript = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GhostAppearance>();
        tipHolderAnim = GetComponent<Animator>();
        tipHolderAnim.SetBool("open", true);
        StartCoroutine(WaitFor10());

    }

    // Update is called once per frame
    void Update()
    {
        if(ghostAppearanceScript.ghostsMad >= ghostAppearanceScript.maxGhostsMad) { 
            EndGame();
            Debug.Log("You Lose!");
        }

        if(ghostAppearanceScript.ghostsSleepyed >= ghostAppearanceScript.ghostsInPhase1 + ghostAppearanceScript.ghostsInPhase2 + ghostAppearanceScript.ghostsInPhase3) { 
            Debug.Log("You Win!");
            EndGame();
        }
    }

    private IEnumerator WaitFor10() { 
        yield return new WaitForSeconds(10);  
        tipHolderAnim.SetBool("open", false);
        tipHolderAnim.SetBool("close", true);

    }


    public void EndGame() {

        Time.timeScale = 0f;
;    }
}
