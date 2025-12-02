using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject panel;

    public GameObject PigPanel;

    public GameObject TextMention;

    public GameObject PigAlive;
    public GameObject PigDied;
    public GameObject CheckPig;
    public GameObject uncheckpig;

    public GameObject ElephantAlive;
    public GameObject ElephantDied;
    public GameObject CheckElephant;
    public GameObject uncheckelephant;

    void Awake()
    {
        instance = this;
    }

    
    void Start()
    {
        
    }
}
