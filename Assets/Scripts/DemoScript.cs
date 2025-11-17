using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    //float firstFloat = 4.5f; // 32 bits of memory space,  digits accuracy

    int firstNum = 6;
    int secondNum = 5;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // print ("Hello world!");
        int result = MultiplyByTwo(firstNum, secondNum);
        print(result);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Hello World again!");
        //Dbug.LogWarning("Warning!");
    }

    int MultiplyByTwo(int a, int b){
        return a * b;
    }
}
