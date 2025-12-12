using UnityEngine;
using UnityEngine.UI;
public class BagUI : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
     public GameObject bagPanel;
    public Transform container;        
    public GameObject slotPrefab;      

    void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            bagPanel.SetActive(!bagPanel.activeSelf);

            if (bagPanel.activeSelf)
                RefreshUI();
        }
    }

    void RefreshUI()
    {
        
        foreach (Transform child in container)
            Destroy(child.gameObject);

       
        foreach (Sprite icon in BagSystem.instance.collectedAnimals)
        {
            GameObject slot = Instantiate(slotPrefab, container);
            slot.GetComponent<Image>().sprite = icon;
        }
    }
}
