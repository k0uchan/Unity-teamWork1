using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spin : MonoBehaviour
{
    private bool Rotating = false;
    public float speed = 0.3f;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKeyDown(KeyCode.Space))
        {
            Rotating = false;
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            Rotating = true;
        }
        if (Rotating == true)
        {
            transform.Rotate(0, speed, 0);
        }
    }
}
