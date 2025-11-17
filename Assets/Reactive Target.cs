using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactiveTarget : MonoBehaviour
{
    public Material skychange;
    public Material oskybox2;
    public GameObject fire;
    [SerializeField] GameObject cubefire;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ReactToHit()
    {
        Wandering behaviour = GetComponent<Wandering>();
        if (behaviour != null)
        {
            behaviour.SetAlive(false);
        }
        StartCoroutine(Die());
        //StartCoroutine(CubeIndicator(this.transform.position));
        ChangeSkybox(skychange);
        StartCoroutine(skyboxback());
    }

    private IEnumerator Die()
    {
        this.transform.Rotate(-75, 0, 0);
        yield return new WaitForSeconds(5.0f);
        Destroy(this.gameObject);

    }
    private void ChangeSkybox(Material Skymaterial)
    {
        RenderSettings.skybox = Skymaterial;

    }

    private IEnumerator skyboxback()
    {
        yield return new WaitForSeconds(5.0f);
        RenderSettings.skybox = oskybox2;
    }

    private IEnumerator CubeIndicator(Vector3 pos)
    {
        // GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        // cube.transform.position = pos;
        if (fire == null)
        {
            fire = Instantiate(cubefire) as GameObject;
            fire.transform.position = transform.TransformPoint(Vector3.forward * 1.5f);
            fire.transform.rotation = transform.rotation;

        }
        // yield return new WaitForSeconds(1);//等待一秒钟
        // Destroy(cube);
         yield return new WaitForSeconds(1);
    }
}
