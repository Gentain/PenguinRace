using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
    static public bool started = false;
    float time = 0f;
    float endCountTime = 5f;
    public Text readyText;
    public AudioClip startSE;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        time = 0f;
        readyText = GetComponent<Text>();
        started = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (time < endCountTime)
        {
            Time.timeScale = 0f;
            time += Time.unscaledDeltaTime;
            readyText.text = "Ready...";
        }
        else
        {
            if (started == false)
            {
                audioSource.PlayOneShot(startSE);
            }
            Time.timeScale = 1.0f;
            readyText.text = "";
            started = true;
        }
    }

    /*
    
    bool ready = false;
    bool started = false;
    float time = 0f;
    int count = 3;
    public Text readyText;
     * 
     private void Start()
    {
        time = 0f;
        readyText = GetComponent<Text>();
        readyText.text = "Ready...";
        Time.timeScale = 0f;
        count = 3;
        ready = false;
        started = false;
    }

    private void Update()
    {
        if (ready == false)
        {
            WaitFewSeconds();
            Ready();
        }

        if (ready == true && started == false)
        {
            readyText.text = "";
            Time.timeScale = 1f;
            started = true;
        }
    }

    public void Ready()
    {
        ready = true;
    }

    IEnumerator WaitFewSeconds()
    {
        yield return new WaitForSeconds(3);
    }
     */
}
