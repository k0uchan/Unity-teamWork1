using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject panel;

    public GameObject PigPanel;

    public GameObject TextMention;

    void Awake()
    {
        instance = this;
    }

    
    void Start()
    {
        
    }
}
