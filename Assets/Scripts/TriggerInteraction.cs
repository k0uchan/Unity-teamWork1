using UnityEngine;

public class TriggerInteraction : MonoBehaviour
{
    AudioSource myAudioSource;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
         myAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        Debug.Log("Passing throught!");
        myAudioSource.Play();
    }
}
