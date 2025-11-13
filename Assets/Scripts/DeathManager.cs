using TMPro;
using UnityEngine;

public class DeathManager : MonoBehaviour
{

    public GameObject deathScreen;
    public GhostAppearance ghostAppearanceScript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ghostAppearanceScript = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GhostAppearance>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Death() { 
        deathScreen.SetActive(true);
        Time.timeScale = 0f;
        GameObject.FindGameObjectWithTag("FinalScoreText").GetComponent<TextMeshProUGUI>().text = ghostAppearanceScript.ghostsSleepyed.ToString();

    }
}
