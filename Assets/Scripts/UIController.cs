using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class UIController : MonoBehaviour
{
    [SerializeField] TMP_Text scoreLable;

    [SerializeField] SettingsPopup SettingsPopup;
    [SerializeField] Slider speedSlider;

    private int score;

    void OnEnable()
    {
        Messenger.AddListener(GameEvent.ENEMY_HIT, OnEnemyHit);
    }
    void OnDisable()
    {
        Messenger.RemoveListener(GameEvent.ENEMY_HIT, OnEnemyHit);
    }
    // Start is called before the first frame update
    void Start()
    {
        SettingsPopup.Close();
        speedSlider.value = 1.0f;
        score = 10;
    }

    // Update is called once per frame
    void Update()
    {
        //scoreLable.text = Time.realtimeSinceStartup.ToString();
    }

    public void OnCloseSettings()
    {
        SettingsPopup.Close();
    }

    public void OnOpenSettings()
    {
        Debug.Log("Open settings");
        SettingsPopup.Open();
    }
    public void OnPointerDown()
    {
        Debug.Log("Pointer Down");
    }
    //public void OnpointerUp()
    //{
    //    Debug.Log("pointer up");
    //}
    private void OnEnemyHit()
    {
        score--;
        scoreLable.text = score.ToString();
    }
}
