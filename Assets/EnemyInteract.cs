using Unity.VisualScripting;
using UnityEngine;

public class EnemyInteract : MonoBehaviour
{
    public float interactDistance = 2f;      // 玩家靠多近才能交互

    //public GameObject infoPanel;            // UI 面板
    //public GameObject infoPanel;            // UI 面板
    private ReactiveTarget target;

    private bool canInteract = false;       // 玩家是否在范围内

    void Start()
    {
        target = GetComponent<ReactiveTarget>();
    }

    void Update()
    {
        if (target != null && target.isDead)
        {
            // 获取玩家位置（摄像机即玩家）
            float dist = Vector3.Distance(Camera.main.transform.position, transform.position);

            if (dist <= interactDistance)
            {
                canInteract = true;
            }
            else
            {
                canInteract = false;
            }

            // 玩家在范围内并按下鼠标左键
            if (canInteract && Input.GetMouseButtonDown(0))
            {
                GameManager.instance.panel.SetActive(true);
            }
        }
    }
}
