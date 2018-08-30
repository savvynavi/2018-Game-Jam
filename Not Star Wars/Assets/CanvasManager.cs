using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasManager : MonoBehaviour {

    public GameObject mainMenu;
    public GameObject pauseMenu;
    bool paused;

	// Use this for initialization
	void Start () {
        Time.timeScale = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape) && !paused && Time.timeScale!=0)
        {
            Pause();
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && paused && Time.timeScale != 0)
        {
            ContinueButton();
        }

    }

    public void StartButton()
    {
        GetComponent<AudioSource>().Play();
        mainMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void QuitButton()
    {
        Application.Quit();
    }

	public void Restart() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

    public void Pause()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
        paused = true;
    }

    public void ContinueButton()
    {
        pauseMenu.SetActive(false);
        paused = false;
        Time.timeScale = 1;
    }
}
