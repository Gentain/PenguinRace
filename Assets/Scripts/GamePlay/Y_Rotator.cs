using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Y_Rotator : MonoBehaviour
{
    public float rotate_y = 20f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, rotate_y, 0) * Time.deltaTime);
    }
}
