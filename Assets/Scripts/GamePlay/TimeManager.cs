using System.Collections;
using System.Collections.Generic;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    static public TimeManager instance;
    private float time = 0;
    static public float bestTime = 0;
    public Text timeText;
    public string submitName;
    int FloatToInt = 100; //������100�{�ɂ���INT�^�ɂ�����A�Ăѕ\���p��FLOAT�^�ɂ���B
    private bool rankingSent = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        bestTime = 0;
        timeText = GetComponent<Text>();
        rankingSent = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (CountDown.started == true)
        {
            if (PenguinGameManager.instance.extraFlags > 0)
            {
                time += Time.deltaTime;
                timeText.text = "" + time.ToString("F2") + "s";
            }
            else if (PenguinGameManager.instance.extraFlags <= 0)
            {
                bestTime = time;
            }
        }
        if(PenguinGameManager.instance.cleared == true)
        {
            if(rankingSent == false)
            {
                SubmitPlayerTime(bestTime);
                SubmitPlayerDisplayName(RankingName.submitName);
                rankingSent = true;
            }
        }
    }

    public void SubmitPlayerDisplayName(string submitName)
    {
        PlayFabClientAPI.UpdateUserTitleDisplayName(
            new UpdateUserTitleDisplayNameRequest
            {
                DisplayName = submitName
            },
            result => {
                Debug.Log("���O����͂��܂����I");
            },
            error => {
                Debug.Log("�����\�z�O�̃G���[���N����܂����B");
            }
            );
    }

    public void SubmitPlayerTime(float bestTime)
    {
        int time_to_int = (int)(bestTime * FloatToInt);
        PlayFabClientAPI.UpdatePlayerStatistics(new UpdatePlayerStatisticsRequest
        {
            Statistics = new List<StatisticUpdate>
            {
                new StatisticUpdate
                {
                    StatisticName =  "PenguinRace_Record_Stage" + StageNumberManager.stageNum,
                    Value = time_to_int * -1 //�@���R�[�h�擾����-1���|���鎖�ň�U�l�𕉂̐��Ŋi�[���A�\�����ɂ�����x�L�^��-1���|���čŏ��L�^�Ɍ�����B 
                }
            }
        }, result =>
        {
            Debug.Log($"��������I�I�X�R�A�̑��M����!!!!!�@�X�R�A�F{time_to_int}");
        }, error =>
        {
            Debug.Log("����˂�c�X�R�A�����M�ł��Ȃ�������(�L�G�ցG�M)��ܯ");
        });
    }
}

/*
using System.Collections;
using System.Collections.Generic;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;
using UnityEngine.UI;

public class InputRecord : MonoBehaviour
{
    public string submitName;
   // public InputField inputField;
    int FloatToInt = 100; //������100�{�ɂ���INT�^�ɂ�����A�Ăѕ\���p��FLOAT�^�ɂ���B

    // Start is called before the first frame update
    void Start()
    {
      //  inputField = inputField.GetComponent<InputField>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void InputName()
    {
        //submitName = inputField.text;
        Debug.Log(submitName);
    }

    public void SubmitRecord(float bestTime)
    {
        InputPlayerDisplayName(PlayFabLogIn.inputName);
        SubmitPlayerScore(Timer.bestTime);
    }

    public void InputPlayerDisplayName(string inputName)
    {
        PlayFabClientAPI.UpdateUserTitleDisplayName(
            new UpdateUserTitleDisplayNameRequest
            {
                DisplayName = inputName
            },
            result => {
                Debug.Log("���O����͂��܂����I");
            },
            error => {
                Debug.Log("�����\�z�O�̃G���[���N����܂����B");
            }
            );
    }

    public void SubmitPlayerScore(float bestTime)
    {
        int score = (int)(bestTime * FloatToInt);
        PlayFabClientAPI.UpdatePlayerStatistics(new UpdatePlayerStatisticsRequest
        {
            Statistics = new List<StatisticUpdate>
            {
                new StatisticUpdate
                {
                    StatisticName = "SurvivingTime",
                    Value = score
                }
            }
        }, result =>
        {
            Debug.Log($"��������I�I�X�R�A�̑��M����!!!!!�@�X�R�A�F{score}");
        }, error =>
        {
            Debug.Log("����˂�c�X�R�A�����M�ł��Ȃ�������(�L�G�ցG�M)��ܯ");
        });
    }
}

/*
��PlayFab���p�̎Q�l�Ƃ����Ē������L���Q�̃T�C�g�l

PlayFab�}�X�^�[�ւ̓��bPlayFab���w�K���������Ȃ���
https://playfab-master.com/

�yPlayFab�z�v���C���[���iDisplayName�j��o�^�E�X�V�yUnity�z | Makihiro��devlog
https://mackysoft.net/playfab-update-display-name/

*/