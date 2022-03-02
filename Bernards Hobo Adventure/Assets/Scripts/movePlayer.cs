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

    public float speed = 1;
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
        Vector2 lookVector = lookValue.Get<Vector2>();

        lookX = lookVector.x;
        lookY = lookVector.y;

        Vector3 look = new Vector3(lookX, 0, lookY);
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0, movementY);
        controller.Move(movement * speed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
