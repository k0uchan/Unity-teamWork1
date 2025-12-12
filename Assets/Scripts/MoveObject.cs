using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("controlScript/FPS Input")]

public class MoveObject : MonoBehaviour
{
    //public float Speed = 5f; // 物体移动速度
    public float Force = 10f; // 物体跳跃力量
    private Rigidbody rb;
    public float bseSpeed = 2.5f;

    public float speed = 0f;
    public float gravity = -9.8f;

    private CharacterController characterController;

    void OnEnable()
    {
        Messenger<float>.AddListener(GameEvent.SPEED_CHANGED, OnSpeedChanged);
    }
    void OnDisable()
    {
        Messenger<float>.RemoveListener(GameEvent.SPEED_CHANGED, OnSpeedChanged);
    }

    private void OnSpeedChanged(float value)
    {
        speed = bseSpeed * value;
    }


    void Start()
    {
        characterController = GetComponent<CharacterController>();

        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {

        //float deltaX = Input.GetAxis("Horizontal") * speed ;
        //float deltaZ = Input.GetAxis("Vertical") * speed ;
        //float deltaY = jumpheight;
        //bool jump = false;
        float deltaX = Input.GetAxis("Horizontal");
        float deltaZ = Input.GetAxis("Vertical");

        
        Vector3 moveDirection = new Vector3(deltaX, 0f, deltaZ);
        transform.Translate(speed * moveDirection.normalized * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.Z))
        {
            rb.AddForce(Vector3.up * Force, ForceMode.Impulse);

        }
        // Vector3 movement = new Vector3(deltaX, deltaY, deltaZ) + Vector3.up * jumpheight;

        //Vector3 movement = new Vector3(deltaX, 0f, deltaZ);
        //movement = Vector3.ClampMagnitude(movement, speed);
        //movement.y = gravity;
        //movement *= Time.deltaTime;
        //movement = transform.TransformDirection(movement);
        //characterController.Move(movement);


    }


}