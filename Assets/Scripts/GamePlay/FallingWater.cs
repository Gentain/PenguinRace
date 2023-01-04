using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingWater : MonoBehaviour
{
    public static PenguinController p_controller;
    public AudioClip outSE = null;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        outSE = null;
}

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        audioSource.PlayOneShot(outSE);
        PenguinController.instance.transform.position = PenguinController.instance.startPoint;
        PenguinController.instance.rb.velocity = Vector3.zero;
        PenguinController.instance.transform.rotation = PenguinController.instance.firstRot;
        Debug.Log("Oops!");
    }
}
