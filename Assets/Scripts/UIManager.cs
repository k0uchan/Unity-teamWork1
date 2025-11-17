using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public void QuitGame(){
        Debug.Log("The application has quit!");
        Application.Quit();
    }
    
    public void ChangeScene(string sceneName){
        SceneManager.LoadScene(sceneName);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
