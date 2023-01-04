using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageSelectManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoToGame()
    {
        SceneManager.LoadScene("Scenes/StageScenes/Race_Stage" + StageNumberManager.stageNum);
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("Scenes/SystemScenes/MenuScene");
    }
}
