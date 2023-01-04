using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenguinController : MonoBehaviour
{
    public static PenguinController instance;
    public Vector3 startPoint;
    public Rigidbody rb;
    public float speed = 5.0f;
    public float maxSpeed = 12.0f;
    public float rotateSpeed = 2.0f;
    public Quaternion firstRot;

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
        startPoint = transform.position;
        firstRot = transform.rotation;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (CountDown.started == true && PauseSystem.paused == false && PenguinGameManager.instance.cleared == false)
        {
            float feet = Input.GetAxis("Vertical") * speed;
            if (feet > maxSpeed)
            {
                feet = maxSpeed;
            }
            float rot = Input.GetAxis("Horizontal") * rotateSpeed;
            rb.AddForce(transform.TransformDirection(Vector3.forward * feet));
            transform.Rotate(new Vector3(0, rot, 0));
        }
    }
}
