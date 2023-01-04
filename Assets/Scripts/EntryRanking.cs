using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;
using UnityEngine.UI;

public class EntryRanking : MonoBehaviour
{
    string defaultName = "Guest";
    static public string inputName;
    public InputField inputField;

    // Start is called before the first frame update
    void Start()
    {
        inputField.text = defaultName;
        inputName = "";
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void InputName()
    {
        inputName = inputField.text;
        Debug.Log(inputName);
    }

    public void submitPlayerDisplayName()
    {
        if (inputField.text == "" || inputField.text == defaultName)
        {
            inputName = defaultName;
        }
        RankingLogIn();
    }

    // Start is called before the first frame update
    public void RankingLogIn()
    {
        PlayFabClientAPI.LoginWithCustomID(new LoginWithCustomIDRequest { CustomId = inputName, CreateAccount = true },
result => Debug.Log("Login Succeeded!"),
error => Debug.Log("Login Failed"));
    }
}
