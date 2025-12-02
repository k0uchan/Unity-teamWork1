using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Wandering : MonoBehaviour
{
    public float speed = 0f;
    public float aseSpeed = 0f;
    public float obstaclerange = 5.0f;

    private bool isAlive;

    public float baseSpeed = 3f; // 在 Inspector 设置

    [SerializeField] GameObject fireballPrefab;
    private GameObject fireball;

    void OnEnable()
    {
        Messenger<float>.AddListener(GameEvent.SPEED_CHANGED, OnSpeedChanged);
    }

    void OnDisable()
    {
        Messenger<float>.RemoveListener(GameEvent.SPEED_CHANGED, OnSpeedChanged);
    }

    void Start()
    {
        isAlive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isAlive)
        {
            transform.Translate(0, 0, speed * Time.deltaTime);

            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;
            if (Physics.SphereCast(ray, 0.75f, out hit))
            {
                GameObject hitObejct = hit.transform.gameObject;
                if (hitObejct.GetComponent<PlayerCharactar>())
                {
                    if (fireball == null)
                    {
                        fireball = Instantiate(fireballPrefab) as GameObject;
                        fireball.transform.position = transform.TransformPoint(Vector3.forward * 1.5f);
                        //以我的位置往前一点五倍,把下列位置转化成全局坐标系
                        fireball.transform.rotation = transform.rotation;
                    }
                }
                else if (hit.distance < obstaclerange)
                {
                    float angle = Random.Range(-110, -110);
                    transform.Rotate(0, angle, 0);
                }

            }

        }
        //Debug.Log("敌人速度 = " + speed);
    }

    public void SetAlive(bool alive)
    {
        isAlive = alive;
    }

    private void OnSpeedChanged(float value)
    {
        //speed = aseSpeed * value;
        speed = baseSpeed * value; // 改变倍率但不影响基础速度
    }
}
