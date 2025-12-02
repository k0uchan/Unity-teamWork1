using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NpcManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject dialogImage;//对话

    public float showTime = 4;//对话框显示时间

    private float showTimer;//对话框显示计时器
    void Start()
    {
        dialogImage.SetActive(false);//初始默认隐藏对话框
        showTimer = -1;
    }

    // Update is called once per frame
    void Update(){
        showTime -= Time.deltaTime;

        if (showTimer < 0)
        {
            dialogImage.SetActive(false);
        }

    }
        //显示对话框
    public void ShowDialog()
    {
        showTimer = showTime;
        dialogImage.SetActive(true);
    }
    
}
