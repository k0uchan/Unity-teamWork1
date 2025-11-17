using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float speed = 3.0f;
    public int damage = 1;
    public Material shotsky;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerCharactar player = other.GetComponent<PlayerCharactar>();
        if (player != null)
        {
            Debug.Log("player hit");
            Messenger.Broadcast(GameEvent.ENEMY_HIT);
            player.Hurt(damage);
            RenderSettings.skybox = shotsky;
        }
        Destroy(this.gameObject);
    }
}
