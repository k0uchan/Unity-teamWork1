using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class IntroPopupController : MonoBehaviour
{
    public GameObject introPanel;   // 总弹窗
    public List<GameObject> pages;   // 每一页（Page0、Page1、Page2）
    public Button Next_Button;
    public Button Close_Button;

    private int currentPage = 0;
    private int maxPage = 2;   // 0、1、2 → 共三页

    void Start()
    {
        introPanel.SetActive(true);
    }

    // ---- 玩家点击 Start 按钮后调用这个方法 ----
    public void ShowIntro()
    {
        introPanel.SetActive(true);
        currentPage = 0;
        UpdatePage();
    }

    // ---- 点击 Next 按钮 ----
    public void OnNextPage()
    {
        if (currentPage < maxPage)
            currentPage++;

        UpdatePage();
    }

    // ---- 点击 Close 按钮 ----
    public void OnClose()
    {
        if (currentPage >= maxPage)
        {
            introPanel.SetActive(false);
            Debug.Log("Intro closed.");
        }
        else
        {
            Debug.Log("Must reach last page to close.");
        }
    }

    // ---- 刷新UI显示 ----
    void UpdatePage()
    {
        // 显示对应页
        for (int i = 0; i < pages.Count; i++)
            pages[i].SetActive(i == currentPage);

        // 如果未到最后一页，禁用关闭按钮
        Close_Button.interactable = (currentPage >= maxPage);

        // 最后一页隐藏 next 按钮
        Next_Button.gameObject.SetActive(currentPage < maxPage);
    }
}


