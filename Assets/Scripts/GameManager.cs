using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject panel;

    public GameObject PigPanel;

    public GameObject PandaPanel;

    public GameObject TextMention;

    public GameObject PigAlive;
    public GameObject PigDied;
    public GameObject CheckPig;
    public GameObject uncheckpig;

    public GameObject ElephantAlive;
    public GameObject ElephantDied;
    public GameObject CheckElephant;
    public GameObject uncheckelephant;

    public GameObject PandaAlive;
    public GameObject PandaDied;
    public GameObject CheckPanda;
    public GameObject uncheckpanda;

    void Awake()
    {
        instance = this;
    }

    
    void Start()
    {
        
    }
}
