using PlayFab;
using PlayFab.ClientModels;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleManager : MonoBehaviour
{
    static bool logInFinish = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.anyKeyDown)
        {
            if(logInFinish == false)
            {
                LogIn(RankingName.defaultName);
            }
            SceneManager.LoadScene("Scenes/SystemScenes/MenuScene");
        }
    }

    public void LogIn(string name)
    {
        PlayFabClientAPI.LoginWithCustomID(new LoginWithCustomIDRequest { CustomId = name, CreateAccount = true },
result => Debug.Log("Login Succeeded!"),
error => Debug.Log("Login Failed"));
        logInFinish = true;
    }
}
