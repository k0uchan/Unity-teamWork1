using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackAndForth : MonoBehaviour
{
    public float speed = 3.0f;
    public float maxz = 16.0f;
    public float minz = -16.0f;

    private int direction = 1;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, direction * speed * Time.deltaTime);
        bool bounced = false;
        if (transform.position.z > maxz || transform.position.z < maxz)
        {
            direction = -direction;
            bounced = true;
        }
        if (bounced)
        {
            transform.Translate(0, 0, direction * speed * Time.deltaTime);
        }
    }
}
