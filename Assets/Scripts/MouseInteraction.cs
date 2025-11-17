using UnityEngine;

public class MouseInteraction : MonoBehaviour
{
    Rigidbody myRigidbody;
    Renderer myRenderer;
    AudioSource myAudioSource;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
        myRenderer = GetComponent<Renderer>();
        myAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1)) {
            myRigidbody.useGravity = true;
        }

        if (Input.GetKey(KeyCode.R)) {
            myRenderer.material.color = Color.red;
        } else if (Input.GetKey(KeyCode.G)) {
            myRenderer.material.color = Color.green;
        } else if (Input.GetKey(KeyCode.B)) {
            myRenderer.material.color = Color.blue;
        }
    }

    void OnMouseDown(){
        Debug.Log("This should work!");
        myRenderer.material.color = Color.blue;
    }

    private void OnCollisionEnter (Collision other) {
        myAudioSource.Play(); 
        Debug.Log("This Collision work!" + other. gameObject.name);
        
    }
}
