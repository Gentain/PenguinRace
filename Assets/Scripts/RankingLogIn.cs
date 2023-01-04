using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;
using UnityEngine.UI;

public class RankingLogIn : MonoBehaviour
{
    static public string inputName;
    public InputField inputField;
    public Text stateText;

    // Start is called before the first frame update
    void Start()
    {
        stateText.text = "";
        inputField.text = "";
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

    public void Submit()
    {
        if (inputName.Length <= 3 || inputName == "")
        {
            stateText.text = "Error!!：名前が短すぎます。";
        }
        else if (inputName.Length > 20)
        {
            stateText.text = "Error!!：名前が長すぎます。";
        }
        else
        {
            LogIn();
        }
    }

    // Start is called before the first frame update
    public void LogIn()
    {
        PlayFabClientAPI.LoginWithCustomID(new LoginWithCustomIDRequest { CustomId = inputName, CreateAccount = true },
result => { stateText.text = "OK：ログイン成功！"; RankingName.submitName = inputName; },
error => Debug.Log("Error!!：ログインに失敗しました。"));
    }
}

/*
★PlayFab利用の参考とさせて頂いた記事群のサイト様

PlayFabマスターへの道｜PlayFabを学習したいあなたへ
https://playfab-master.com/

【PlayFab】プレイヤー名（DisplayName）を登録・更新【Unity】 | Makihiroのdevlog
https://mackysoft.net/playfab-update-display-name/

*/
