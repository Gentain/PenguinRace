using System.Collections;
using System.Collections.Generic;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GetRanking : MonoBehaviour
{
    public Text rankingText; // �����L���O�\���p�̃e�L�X�g

    // Start is called before the first frame update
    void Start()
    {
        rankingText.text = "";
        rankingText.text += "�ő��^�C��\n";
        LoadRanking();
    }

    private void Update()
    {
            
    }

    public void LoadRanking()
    {     
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
    }
}