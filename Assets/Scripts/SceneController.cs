using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    [SerializeField] GameObject enemyprefab;//私有的但希望在inspecter访问
    private GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (enemy == null)
        {
            enemy = Instantiate(enemyprefab) as GameObject;//让父类强制转化成子类,创造用instanti
            enemy.transform.position = new Vector3(0, 0.25f, -1);
            float angle = Random.Range(0, 360);
            enemy.transform.Rotate(0, angle, 0);
        }
    }
}
