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
    public Text bestTimeText; // 時間のテキスト
    public Text clearText; // コースクリア時のテキスト
    public Text rankingText; // ランキング表示用のテキスト
    public Text nameText; // プレイヤー名表示用のテキスト
    public GameObject menuButton; // タイトルボタンのオブジェクト取得
    public GameObject retryButton; // リトライボタンのオブジェクト取得
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
            nameText.text = RankingName.submitName + "さん";
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
            rankingText.text += "最速タイム\n";
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