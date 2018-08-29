using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTimer : MonoBehaviour {

    public Text timerText;
    public GameObject winScreen;
    public Text winTimeText;
    float timer;
    bool playing = true;

    // Use this for initialization
    void Start () {		
	}
	
	// Update is called once per frame
	void Update () {
        if (playing){
            timer += Time.deltaTime;
            timerText.text = "Timer: " + timer.ToString("F2") + "s";
        }

       
	}

    public void WinState()
    {
        playing = false;
        timerText.enabled = false;
        winScreen.SetActive(true);
        winTimeText.text = timer.ToString("F2") + "s";
        Time.timeScale = 0;
    }
}
