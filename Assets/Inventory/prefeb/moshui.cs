using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class moshui : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject moshuiBox;
    private int time = 5;

    private bool playerNpc;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ball"))
        {
            moshuiBox.SetActive(true);
            playerNpc = true;
            Debug.Log("1");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ball"))
        {
            moshuiBox.SetActive(false);
            playerNpc = false;
            Debug.Log("2");
        }
    }
}