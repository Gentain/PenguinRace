using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Flag : MonoBehaviour
{
    bool touched = false;
    public PenguinGameManager G_Manager;
    public Material touchedMaterial;
    public AudioClip touchSE;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        touched = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
         if (other.gameObject.tag == "Player" && touched == false)
        {
            Debug.Log("Hit");
            touched = true;
            audioSource.PlayOneShot(touchSE);
            PenguinGameManager.instance.extraFlags--;
            this.gameObject.GetComponent<Renderer>().material = touchedMaterial;
        }
    }
}
