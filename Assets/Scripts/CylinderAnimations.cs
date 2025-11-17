using UnityEngine;

public class CylinderAnimations : MonoBehaviour
{
    Animator myAnimator;
    void Start()
    {
        myAnimator = GetComponent<Animator>();
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            myAnimator.SetTrigger("Cylinderpos");

        }
    }
}
