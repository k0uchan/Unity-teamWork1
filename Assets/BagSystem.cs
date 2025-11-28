using UnityEngine;
using System.Collections.Generic;
public class BagSystem : MonoBehaviour
{
     public static BagSystem instance;

    // 背包中保存的是动物的图片
    public List<Sprite> collectedAnimals = new List<Sprite>();

    void Awake()
    {
        if (instance == null)
            instance = this;
    }

    // 收集新的动物（避免重复）
    public void AddAnimal(Sprite animalIcon)
    {
        if (!collectedAnimals.Contains(animalIcon))
        {
            collectedAnimals.Add(animalIcon);
            Debug.Log("Items of animal add to bag：" + animalIcon.name);
        }
    }
}
