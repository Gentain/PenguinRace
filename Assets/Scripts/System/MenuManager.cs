using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
          
        }
    }

    public void GoToTitle()
    {
        SceneManager.LoadScene("Scenes/SystemScenes/TitleScene");
    }

    public void GoToStageSelect()
    {
        SceneManager.LoadScene("Scenes/SystemScenes/StageSelect");
    }

    public void GoToRule()
    {
        SceneManager.LoadScene("Scenes/SystemScenes/RuleScene");
    }

    public void GoToRanking()
    {
        SceneManager.LoadScene("Scenes/SystemScenes/RankingScene");
    }

    public void GoToThanks()
    {
        SceneManager.LoadScene("Scenes/SystemScenes/SpecialThanks");
    }

    public void GoToEntry()
    {
        SceneManager.LoadScene("Scenes/SystemScenes/RankingEntry");
    }
}
