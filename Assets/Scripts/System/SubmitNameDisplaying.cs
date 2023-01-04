using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubmitNameDisplaying : MonoBehaviour
{
    public Text displayName;

    // Start is called before the first frame update
    void Start()
    {
        displayName = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        displayName.text = "ÉÜÅ[ÉUÅ[ñº:\n" + RankingName.submitName + "Ç≥ÇÒ";
    }
}
