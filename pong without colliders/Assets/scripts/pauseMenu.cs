using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseMenu : MonoBehaviour {

    public static bool GameisPaused = false;
    public GameObject PausemenuUI;

     void Start()
    {
        //PausemenuUI.SetActive(false);
    }

    // Update is called once per frame
    void Update ()
    {
		if(Input.GetKeyDown(KeyCode.Escape))

        {
            if (GameisPaused)
                resume();
            else
                pause();
        }
        
	}
    public void resume()
    {
        PausemenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameisPaused = false;
    }
    public void pause()
    {
        PausemenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameisPaused = true;
    }
}
