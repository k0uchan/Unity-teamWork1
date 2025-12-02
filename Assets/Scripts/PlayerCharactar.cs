using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCharactar : MonoBehaviour
{
    private int health;
    public Material hurtsky;
    public Material oskybox3;

    public float fadeInDuration = 1.0f;
    public float fadeOutDuration = 1.0f;
    public GameObject healthpanel;
    //public float alphaSpeed = 1.0f;
    //private bool isFade = false;
    public CanvasGroup canvasgroup;
    // Start is called before the first frame update
    void Start()
    {
        health = 5;

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Awake()
    {
        canvasgroup = GetComponent<CanvasGroup>();
        if (canvasgroup == null)
            Debug.LogError("CanvasGroup not found on " + gameObject.name);
        //healthpanel = GetComponent<GameObject>();
    }

    public void Hurt(int damage)
    {

        health -= damage;
        Debug.Log("Player Hurt");
        RenderSettings.skybox = hurtsky;
        StartCoroutine(skyboxback());
        // 调用淡入效果
        /* FadeIn();*/

        // 淡出
        healthpanel.SetActive(true);
        StartCoroutine(FadeOutHitEffect());
        //StartCoroutine(DoFade(1, fadeInDuration));

    }
    private IEnumerator skyboxback()
    {
        yield return new WaitForSeconds(2.0f);
        RenderSettings.skybox = oskybox3;
    }


    //private void FadeIn()
    //{
    //    healthpanel.SetActive(true);
    //    StartCoroutine(DoFade(1, fadeInDuration));
    //    Debug.Log("do fade in");
    //}

    //private IEnumerator WaitAndFadeOut(float waitTime)
    //{
    //    yield return new WaitForSeconds(waitTime);
    //    FadeOut();

    //}

    //IEnumerator DoFade(float targetAlpha, float duration)
    //{
    //    float startAlpha = canvasgroup.alpha;
    //    float time = 0;

    //    while (time < duration)
    //    {
    //        canvasgroup.alpha = Mathf.Lerp(startAlpha, targetAlpha, time / duration);
    //        time += Time.deltaTime;
    //        yield return null;
    //    }

    //    canvasgroup.alpha = targetAlpha;
    //    Debug.Log("already fade");
    //}
    //private void FadeOut()
    //{
    //    healthpanel.SetActive(false);
    //    StartCoroutine(DoFade(0, fadeOutDuration));
    //}
    private IEnumerator FadeOutHitEffect()
    {
        // 获取被打中的效果对象的 Image 或 Text 组件（根据实际情况选择）
        Image hitImage = healthpanel.GetComponent<Image>();
        //Text hitText = healthpanel.GetComponent<Text>();

        // 设置初始透明度
        float alpha = 1f;

        while (alpha > 0f)
        {
            alpha -= Time.deltaTime;

            // 根据组件类型设置透明度
            if (hitImage != null)
            {
                hitImage.color = new Color(hitImage.color.r, hitImage.color.g, hitImage.color.b, alpha);
            }
            //else if (hitText != null)
            //{
            //    hitText.color = new Color(hitText.color.r, hitText.color.g, hitText.color.b, alpha);
            //}

            yield return null;
        }

        // 隐藏被打中的效果对象
        healthpanel.SetActive(false);
    }

}
