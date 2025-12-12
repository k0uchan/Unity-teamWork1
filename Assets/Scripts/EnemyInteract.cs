using Unity.VisualScripting;
using UnityEngine;

public class EnemyInteract : MonoBehaviour
{
    public float interactDistance = 2f;      

    
    public ReactiveTarget target;


    public bool canInteract = false;      

    public GameObject TheObject;

    AudioSource audioSource;
    public AudioClip ClickAudio;

    void Start()
    {
        target = GetComponent<ReactiveTarget>();
        audioSource = GetComponent<AudioSource>();
    }

     

    void Update()
    {
        if (target != null && target.isDead)
        {
            
            float dist = Vector3.Distance(Camera.main.transform.position, transform.position);

            canInteract = (dist <= interactDistance);

            // if (dist <= interactDistance)
            // {
            //     canInteract = true;
            // }
            // else
            // {
            //     canInteract = false;
            // }

            
            // if (canInteract && Input.GetMouseButtonDown(0))
            // {
            //     GameManager.instance.panel.SetActive(true);
            // }
           
             //GameManager.instance.TextMention.SetActive(canInteract);
        }
        

         if (canInteract && Input.GetKeyDown(KeyCode.E))
        {
            OpenUIPanel();
            audioSource.PlayOneShot(ClickAudio);
            
        }

        //  if (TheObject == null)
        // {
        //     canInteract = false;
        //     GameManager.instance.TextMention.SetActive(false);
        // }

         


    }

    void OpenUIPanel()
    {
        string tag = gameObject.tag;

        if (tag == "Animal1")
        {
            GameManager.instance.panel.SetActive(true);
            GameManager.instance.ElephantDied.SetActive(true);
            GameManager.instance.ElephantAlive.SetActive(false);
            GameManager.instance.uncheckelephant.SetActive(false);
            GameManager.instance.CheckElephant.SetActive(true);
            
        }
        else if (tag == "Pig")
        {
            GameManager.instance.PigPanel.SetActive(true);
             GameManager.instance.PigAlive.SetActive(false);
             GameManager.instance.PigDied.SetActive(true);
             GameManager.instance.uncheckpig.SetActive(false);
             GameManager.instance.CheckPig.SetActive(true);
        }
        else if (tag == "Panda")
        {
            GameManager.instance.PandaPanel.SetActive(true);
             GameManager.instance.PandaAlive.SetActive(false);
             GameManager.instance.PandaDied.SetActive(true);
             GameManager.instance.uncheckpanda.SetActive(false);
             GameManager.instance.CheckPanda.SetActive(true);
        }
       
    }
}
