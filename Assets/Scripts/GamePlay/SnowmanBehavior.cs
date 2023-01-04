using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowmanBehavior : MonoBehaviour
{
    public enum MoveStyle
    {
        x_move, z_move, circle
    }

    [SerializeField] GameObject coreObject;
    Vector3 corePos = new Vector3(0f, 0f, 0f); // âÒì]ÇÃíÜêSï®ëÃÇÃç¿ïW 
    public float speed = 0.1f;
    public float angleSpeed = 30f;
    public float moveDistance_X = 1.0f;
    public float moveDistance_Z = 1.0f;
    float distanceMeter_X = 0.0f;
    float distanceMeter_Z = 0.0f;
    bool returning = false;
    public MoveStyle move = MoveStyle.x_move;
    

    // Start is called before the first frame update
    void Start()
    {
        distanceMeter_X = 0f;
        distanceMeter_Z = 0f;
        returning = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (move == MoveStyle.x_move)
        {
            Move_X();
        }
        else if (move == MoveStyle.z_move)
        {
            Move_Z();
        }
        else if (move == MoveStyle.circle)
        {
            Move_Circle();
        }
    }

    private void OnCollisionEnter(Collision col)
    {

        if (col.gameObject.tag == "Player")
        {
            Debug.Log("Hit!");
            Rigidbody playerRB = col.gameObject.GetComponent<Rigidbody>();
            playerRB.AddForce(0f, 0f, 4f);
        }
    }

    public void Move_X()
    {
        if (returning == false)
        {
            if (speed >= 0)
            {
                distanceMeter_X += speed;
                transform.position += new Vector3(speed, 0.0f, 0.0f);
                if (distanceMeter_X >= moveDistance_X)
                {
                    returning = true;
                }
            }
            else if (speed < 0)
            {
                distanceMeter_X += speed;
                transform.position += new Vector3(speed, 0.0f, 0.0f);
                if (distanceMeter_X <= -moveDistance_X)
                {
                    returning = true;
                }
            }
        }
        else if (returning == true)
        {
            if (speed >= 0)
            {
                distanceMeter_X -= speed;
                transform.position -= new Vector3(speed, 0.0f, 0.0f);
                if (distanceMeter_X <= -moveDistance_X)
                {
                    returning = false;
                }
            }
            else if (speed < 0)
            {
                distanceMeter_X -= speed;
                transform.position -= new Vector3(speed, 0.0f, 0.0f);
                if (distanceMeter_X >= moveDistance_X)
                {
                    returning = false;
                }
            }
        }
    }

    public void Move_Z()
    {
        if (returning == false)
        {
            if (speed >= 0)
            {
                distanceMeter_Z += speed;
                transform.position += new Vector3(0.0f, 0.0f, speed);
                if (distanceMeter_Z >= moveDistance_Z)
                {
                    returning = true;
                }
            }
            else if (speed < 0)
            {
                distanceMeter_Z += speed;
                transform.position += new Vector3(0.0f, 0.0f, speed);
                if (distanceMeter_Z <= -moveDistance_Z)
                {
                    returning = true;
                }
            }
        }
        else if (returning == true)
        {
            if (speed >= 0)
            {
                distanceMeter_Z -= speed;
                transform.position -= new Vector3(0.0f, 0.0f, speed);
                if (distanceMeter_Z <= -moveDistance_Z)
                {
                    returning = false;
                }
            }
            else if (speed < 0)
            {
                distanceMeter_Z -= speed;
                transform.position -= new Vector3(0.0f, 0.0f, speed);
                if (distanceMeter_Z >= moveDistance_Z)
                {
                    returning = false;
                }
            }
        }
    }

    public void Move_Circle()
    {
        // RotateAround(íÜêSÇÃà íu, é≤, âÒì]äpìx)
        transform.RotateAround(coreObject.transform.position ,Vector3.up, angleSpeed * Time.deltaTime);
    }
}

