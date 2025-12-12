using UnityEngine;
using System.Collections.Generic;
public class BagSystem : MonoBehaviour
{
     public static BagSystem instance;

    public List<Sprite> collectedAnimals = new List<Sprite>();

    void Awake()
    {
        if (instance == null)
            instance = this;
    }


    public void AddAnimal(Sprite animalIcon)
    {
        if (!collectedAnimals.Contains(animalIcon))
        {
            collectedAnimals.Add(animalIcon);
            Debug.Log("Items of animal add to bag：" + animalIcon.name);
        }
    }
}
