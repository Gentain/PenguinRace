using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PenguinGameManager : MonoBehaviour
{
    public static PenguinGameManager instance;
    public GameObject[] flags;
    public int extraFlags;
    public int extraFish;
    public int maxFlags;
    private string flagTagName = "Flag";
    public Text flagText;
    public bool cleared;
    public GameObject rankingBoard;
        
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
        flags = GameObject.FindGameObjectsWithTag(flagTagName);
        maxFlags = flags.Length;
        extraFlags = maxFlags;
        cleared = false;
        rankingBoard.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        flagText.text = "残りフラッグ数\n" + extraFlags;
        if(extraFlags == 0)
        {
            cleared = true;
            rankingBoard.SetActive(true);
        }
    }
}
