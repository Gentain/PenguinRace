using System.Collections;
using System.Collections.Generic;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Ranking_Cleared: MonoBehaviour
{
    public bool rankingGet;
    public Text bestTimeText; // ���Ԃ̃e�L�X�g
    public Text clearText; // �R�[�X�N���A���̃e�L�X�g
    public Text rankingText; // �����L���O�\���p�̃e�L�X�g
    public Text nameText; // �v���C���[���\���p�̃e�L�X�g
    public GameObject menuButton; // �^�C�g���{�^���̃I�u�W�F�N�g�擾
    public GameObject retryButton; // ���g���C�{�^���̃I�u�W�F�N�g�擾
    public GameObject rankingSystem;

    // Start is called before the first frame update
    void Start()
    {
        rankingText.text = "";
        rankingGet = false;
        rankingSystem.SetActive(false);
    }

    private void Update()
    {
        if (PenguinGameManager.instance.cleared == true)
        {
            rankingSystem.SetActive(true);
            nameText.text = RankingName.submitName + "����";
            bestTimeText.text = "" + TimeManager.bestTime.ToString("F2") + "s";
            clearText.text = "STAGE CLEAR!!";
            menuButton.SetActive(true);
            GetRanking();
        }
        else if (PenguinGameManager.instance.cleared == false)
        {
            nameText.text = "";
            bestTimeText.text = "";
            clearText.text = "";
            menuButton.SetActive(false);
            rankingSystem.SetActive(true);
        }
    }

    public void GetRanking()
    {
        if (rankingGet == false)
        {
            rankingText.text += "�ő��^�C��\n";
            PlayFabClientAPI.GetLeaderboard(new GetLeaderboardRequest
            {
                StatisticName = "PenguinRace_Record_Stage" + StageNumberManager.stageNum
            }, result =>
            {
                foreach (var item in result.Leaderboard)
                {
                    //�@���R�[�h�擾����-1���|���鎖�ň�U�l�𕉂̐��Ŋi�[���A�\�����ɂ�����x�L�^��-1���|���čŏ��L�^�Ɍ�����B
                    rankingText.text += $"{ item.Position + 1}. {item.DisplayName}  {item.StatValue * 0.01f * -1}s" + "\n";
                }
            }, error =>
            {
                Debug.Log("����˂�I�킽���̃����L���O����Ƃ��͂����ł�����Ă��܂����I");
            }
                );
            rankingGet = true;
        }
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("Scenes/SystemScenes/MenuScene");
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}