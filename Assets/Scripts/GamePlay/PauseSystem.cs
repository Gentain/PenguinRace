using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseSystem: MonoBehaviour
{
    static public bool paused = false;
    public GameObject pauseMenu;
    public PenguinGameManager G_Manager;

    // Start is called before the first frame update
    void Start()
    {
        paused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (CountDown.started == true && PenguinGameManager.instance.cleared == false)
        {
            if (Input.GetKeyDown(KeyCode.Escape) && paused == false)
            {
                paused = true;
                Debug.Log(paused);
            }
            else if (Input.GetKeyDown(KeyCode.Escape) && paused == true)
            {
                paused = false;
                Debug.Log(paused);
            }
        }
        if(paused == true)
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
        }
        else if(paused == false)
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1f;
        }
        if(PenguinGameManager.instance.cleared == true)
        {
            pauseMenu.SetActive(false);
        }
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("Scenes/SystemScenes/MenuScene");
    }

    public void GoToGame()
    {
        paused = false;
    }
}
