using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.LookDev;
using UnityEngine.UI;

public class TipHolder : MonoBehaviour
{

    private Animator tipHolderAnim;
    private GhostAppearance ghostAppearanceScript;
    public string beginningText;
    public string MadGhostText;
    public string sadGhostText;
    public TextMeshProUGUI tipText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tipText.text = beginningText;
        ghostAppearanceScript = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GhostAppearance>();
        tipHolderAnim = GetComponent<Animator>();

        StartCoroutine(WaitFor10(false));

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator WaitFor10(bool pause) {
        tipHolderAnim.SetBool("open", true);
        tipHolderAnim.SetBool("close", false);
        if (pause)
        {

            yield return new WaitForSecondsRealtime(5f);
            
            yield return new WaitForSecondsRealtime(5f);
        }
        else {
            
            yield return new WaitForSecondsRealtime(10f);
        }
            tipHolderAnim.SetBool("open", false);
        tipHolderAnim.SetBool("close", true);

    }


    public void EndGame() {

        Time.timeScale = 0f;
;    }

    public void Ping(string type) {

        switch (type) { 
            case "Mad":
                tipText.text = MadGhostText;
                break;
            case "Sad":
                tipText.text = sadGhostText;
                break;
        }

        
        StartCoroutine(WaitFor10(true));


    }
}
