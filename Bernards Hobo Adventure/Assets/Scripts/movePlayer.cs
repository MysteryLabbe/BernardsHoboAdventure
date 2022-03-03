using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class movePlayer : MonoBehaviour
{
    private float movementX;
    private float movementY;

    private float lookX;
    private float lookY;

    public float speed = 6f;
    public float rotationSmoothTime = 0.1f;
    public float gravity = -9.81f;

    public Transform cam;

    private float currentAngleVelocity = 0f;
    private CharacterController controller;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();   
    }


    private void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;

    }

    private void OnLook(InputValue lookValue)
    {

    }

    private void Update()
    {
        //gravity
        controller.Move(new Vector3 (0f,gravity * Time.deltaTime, 0f));

        Vector3 movement = new Vector3(movementX, 0f, movementY);
        if (movement.magnitude > 0.1f)
        {
            float targetAngle = Mathf.Atan2(movementX, movementY) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref currentAngleVelocity, rotationSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 direction = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            Vector3 motion = direction * speed * Time.deltaTime;
            controller.Move(motion);
        }
    }
}
