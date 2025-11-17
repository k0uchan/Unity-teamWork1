using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class RayShooter : MonoBehaviour
{
    private Camera Cam;
    public TMP_InputField countinput;
    public GameObject fireball;
    public Material skybox;
    public GameObject shootpanel;
    public Material oskybox;
    [SerializeField] GameObject fireballPrefab;
    public int count = 3;
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

        if (Physics.Raycast(ray_speed, out hit_speed))
        {
            Wandering wandering = hit_speed.transform.GetComponent<Wandering>();
            if (wandering != null)
            {
                wandering.speed = 1;
                shootpanel.SetActive(true);
            }

            else
            {
                //wandering.speed = 0.3f;
                shootpanel.SetActive(false);

            }

        }
        //射子弹
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
                    ChangeSkybox(skybox);
                    StartCoroutine(skyboxback());

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

    private void OnGUI()
    {
        GUIStyle gUIStyle = new GUIStyle();
        gUIStyle.fontSize = 140;
        int size = 12;
        float posX = Cam.pixelWidth / 2 - size / 2;
        float posY = Cam.pixelHeight / 2 - size / 2;
        GUI.Label(new Rect(posX, posY, size, size), "+", gUIStyle);
        if (GUI.Button(new Rect(50, 50, 200, 80), "test"))
        {
            Debug.Log("test button");
        }
    }

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
    private IEnumerator skyboxback()
    {
        yield return new WaitForSeconds(2.0f);
        RenderSettings.skybox = oskybox;
    }
    private void ChangeSkybox(Material Skymaterial)
    {
        RenderSettings.skybox = Skymaterial;

    }
}
