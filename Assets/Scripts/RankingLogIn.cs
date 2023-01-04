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
            stateText.text = "Error!!�F���O���Z�����܂��B";
        }
        else if (inputName.Length > 20)
        {
            stateText.text = "Error!!�F���O���������܂��B";
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
result => { stateText.text = "OK�F���O�C�������I"; RankingName.submitName = inputName; },
error => Debug.Log("Error!!�F���O�C���Ɏ��s���܂����B"));
    }
}

/*
��PlayFab���p�̎Q�l�Ƃ����Ē������L���Q�̃T�C�g�l

PlayFab�}�X�^�[�ւ̓��bPlayFab���w�K���������Ȃ���
https://playfab-master.com/

�yPlayFab�z�v���C���[���iDisplayName�j��o�^�E�X�V�yUnity�z | Makihiro��devlog
https://mackysoft.net/playfab-update-display-name/

*/
