using UnityEngine;

public class Mention : MonoBehaviour
{
    private EnemyInteract[] enemies;

    void Start()
    {
        enemies = FindObjectsOfType<EnemyInteract>();
    }

    void Update()
    {
        if (GameManager.instance == null || GameManager.instance.TextMention == null)
            return;

        bool shouldShow = false;

        foreach (var enemy in enemies)
        {
            if (enemy == null || enemy.target == null) continue;

            if (enemy.target.isDead && enemy.canInteract)
            {
                shouldShow = true;
                break;
            }
        }

        GameManager.instance.TextMention.SetActive(shouldShow);
    }
}
