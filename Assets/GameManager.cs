using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject panel;

    void Awake()
    {
        instance = this;
    }

    
    void Start()
    {
        
    }
}
