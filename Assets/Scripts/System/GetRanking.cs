using System.Collections;
using System.Collections.Generic;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GetRanking : MonoBehaviour
{
    public Text rankingText; // ランキング表示用のテキスト

    // Start is called before the first frame update
    void Start()
    {
        rankingText.text = "";
        rankingText.text += "最速タイム\n";
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
                    //　レコード取得時に-1を掛ける事で一旦値を負の数で格納し、表示時にもう一度記録に-1を掛けて最小記録に見せる。
                    rankingText.text += $"{ item.Position + 1}. {item.DisplayName}  {item.StatValue * 0.01f * -1}s" + "\n";
                }
            }, error =>
            {
                Debug.Log("ざんねん！わたしのランキングしゅとくはここでおわってしまった！");
            }
                );
    }
}