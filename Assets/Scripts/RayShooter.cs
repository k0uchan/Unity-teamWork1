using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
using UnityEditor.UIElements;

public class RayShooter : MonoBehaviour
{
    private Camera Cam;
    public TMP_InputField countinput;
    public GameObject fireball;
    public Material skybox;
    public GameObject shootpanel;

    public GameObject Animal_1;
    public GameObject PigPanel;
    public GameObject PandaPanel;

    public GameObject IntroductionPanel;
    public Material oskybox;
    [SerializeField] GameObject fireballPrefab;
    public int count = 10;

    ReactiveTarget EnemyCondition;


    void Start()
    {
        Cam = GetComponent<Camera>();
        if (countinput != null)
        {
            Debug.Log("pleaseInput");
            countinput.onEndEdit.AddListener(UpdateCount);
            if (!int.TryParse(countinput.text, out count))
            {
                count = 10; // 如果转换失败则将默认值设为10
            }
        }
        shootpanel.GetComponent<CanvasGroup>().blocksRaycasts = false;

        


    }

    public void UpdateCount(string value)
    {
        if (int.TryParse(value, out int newBulletCount))
        {
            count = newBulletCount;
        }
    }

    // Update is called once per frame
    void Update()
    {


        Vector3 point_speed = new Vector3(Cam.pixelWidth / 2, Cam.pixelHeight / 2, 0);
        Ray ray_speed = Cam.ScreenPointToRay(point_speed);
        RaycastHit hit_speed;

        shootpanel.SetActive(false);
IntroductionPanel.SetActive(false);
PigPanel.SetActive(false);
PandaPanel.SetActive(false);

        if (Physics.Raycast(ray_speed, out hit_speed))
        {
    //         // Wandering wandering = hit_speed.transform.GetComponent<Wandering>();
    //         // if (wandering != null)
    //         // {
    //         //     wandering.speed = 0.1f;
    //         //     shootpanel.SetActive(true);
    //         //     IntroductionPanel.SetActive(true);
    //         // }

    //         // else
    //         // {
    //         //     //wandering.speed = 0.3f;
    //         //     shootpanel.SetActive(false);

    //         //     IntroductionPanel.SetActive(false);

    //         // }

    //           // ★ 新增：先判断有没有打到“Animal”这个 Tag 的物体
    // if (hit_speed.transform.CompareTag("Animal1"))   // Tag 名
    // {
    //     // 如果你还想在瞄准时让动物减速，可以保留这几行
    //     //Wandering wandering = hit_speed.transform.GetComponent<Wandering>();
    //     // if (wandering != null)
    //     // {
    //     //     wandering.speed = 0.1f;
    //     // }

    //     shootpanel.SetActive(true);
    //     IntroductionPanel.SetActive(true);
    // }
    // else
    // {
    //     shootpanel.SetActive(false);
    //     IntroductionPanel.SetActive(false);
    // }

    //     }
           string tag = hit_speed.transform.tag;

           ReactiveTarget reactiveTarget=hit_speed.transform.GetComponent<ReactiveTarget>();

            if (reactiveTarget != null && !reactiveTarget.isDead)
            {
    if (tag == "Animal1")
    {
        shootpanel.SetActive(true);
        IntroductionPanel.SetActive(true);
    }

    else if (tag == "Pig")
    {
        shootpanel.SetActive(true);
        PigPanel.SetActive(true);
    }

    else if(tag == "Panda")
                {
                    shootpanel.SetActive(true);
                    PandaPanel.SetActive(true);
                }
            }

    
        }

    //     if (Physics.Raycast(ray_speed, out hit_speed))
    //     {
    //         // Wandering wandering = hit_speed.transform.GetComponent<Wandering>();
    //         // if (wandering != null)
    //         // {
    //         //     wandering.speed = 0.1f;
    //         //     shootpanel.SetActive(true);
    //         //     IntroductionPanel.SetActive(true);
    //         // }

    //         // else
    //         // {
    //         //     //wandering.speed = 0.3f;
    //         //     shootpanel.SetActive(false);

    //         //     IntroductionPanel.SetActive(false);

    //         // }

    //           //先判断有没有打到“Animal”这个 Tag 的物体
    // if (hit_speed.transform.CompareTag("Pig"))   // Tag 名
    // {
    //     // 如果你还想在瞄准时让动物减速，可以保留这几行
    //     //Wandering wandering = hit_speed.transform.GetComponent<Wandering>();
    //     // if (wandering != null)
    //     // {
    //     //     wandering.speed = 0.1f;
    //     // }

    //     shootpanel.SetActive(true);
    //     PigPanel.SetActive(true);
    // }
    // else
    // {
    //     shootpanel.SetActive(false);
    //     PigPanel.SetActive(false);
    // }

    //     }

        else
    {
        // 射线什么都没打到时，也要关掉界面
        shootpanel.SetActive(false);
        IntroductionPanel.SetActive(false);
         PigPanel.SetActive(false);
         PandaPanel.SetActive(false);
    }

    

    

        //射子弹
       // if (Input.GetKeyDown(KeyCode.Space) && !EventSystem.current.IsPointerOverGameObject() && count > 0)
        if (Input.GetKeyDown(KeyCode.Space) && !EventSystem.current.IsPointerOverGameObject() && count > 0)
        {

            Vector3 point = new Vector3(Cam.pixelWidth / 2, Cam.pixelHeight / 2, 0);
            Ray ray = Cam.ScreenPointToRay(point);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                GameObject hitObject = hit.transform.gameObject;

                ReactiveTarget target = hitObject.GetComponent<ReactiveTarget>();
                StartCoroutine(SphereIndicator(hit.point));
                    //StartCoroutine(ScalerReduce());
                    // ChangeSkybox(skybox);
                    // StartCoroutine(skyboxback());

                if (target != null)
                {
                    //Debug.Log("Target hit");
                    target.ReactToHit();


                }
                // else
                // {
                //     StartCoroutine(SphereIndicator(hit.point));
                //     StartCoroutine(ScalerReduce());
                //     ChangeSkybox(skybox);
                //     StartCoroutine(skyboxback());

                // }

                Debug.Log("Hit" + hit.point);
                count--;
                //StartCoroutine(SphereIndicator(hit.point));
            }
        }
    }

    // private void OnGUI()
    // {
    //     GUIStyle gUIStyle = new GUIStyle();
    //     gUIStyle.fontSize = 140;
    //     int size = 12;
    //     float posX = Cam.pixelWidth / 2 - size / 2;
    //     float posY = Cam.pixelHeight / 2 - size / 2;
    //     GUI.Label(new Rect(posX, posY, size, size), "+", gUIStyle);
    //     // if (GUI.Button(new Rect(50, 50, 200, 80), "test"))
    //     // {
    //     //     Debug.Log("test button");
    //     // }
    // }

    //Coroutine
    //必须用StartCouroutine()调用
    //IEnumetaror定义
    //yield return
    private IEnumerator SphereIndicator(Vector3 pos)
    {
        //GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        //sphere.transform.position = pos;
        if (fireball == null)
        {
            fireball = Instantiate(fireballPrefab) as GameObject;
            fireball.transform.position = transform.TransformPoint(Vector3.forward * 1.5f);
            fireball.transform.rotation = transform.rotation;
            StartCoroutine(ScalerReduce());
        }
        //yield return new WaitForSeconds(1);//等待一秒钟
        //Destroy(sphere);
        yield return new WaitForSeconds(1);
    }

    private IEnumerator ScalerReduce()
    {
        while (transform.localScale.magnitude >= 0.1f)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, Vector3.zero, Time.deltaTime / 2);
            yield return new WaitForSeconds(2);
            Destroy(fireball);
        }


    }
    // private IEnumerator skyboxback()
    // {
    //     yield return new WaitForSeconds(2.0f);
    //     RenderSettings.skybox = oskybox;
    // }
    // private void ChangeSkybox(Material Skymaterial)
    // {
    //     RenderSettings.skybox = Skymaterial;

    // }
}
