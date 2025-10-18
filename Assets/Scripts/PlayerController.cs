using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 12f;
    CharacterController characterController;

    public Transform groundCheck;
    public LayerMask groundLayer;
    
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        PlayerMove();
    }

    void PlayerMove()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        float y = 0f;

        if (Input.GetKey(KeyCode.LeftShift))
            y = -1f;
        else if (Input.GetKey(KeyCode.Space))
            y = 1f;

            RaycastHit hit;
        if (Physics.Raycast(groundCheck.position, transform.TransformDirection(Vector3.down), out hit, 0.4f, groundLayer))
        {
            string terrainType;
            terrainType = hit.collider.gameObject.tag;

            switch (terrainType)
            {
                default:
                    speed = 12;
                    break;
                case "Low":
                    speed = 3;
                    break;
                case "High":
                    speed = 20;
                    break;
            }
        }
        
        Vector3 move = transform.right * x + transform.forward * z + transform.up * y;
        characterController.Move(move * speed * Time.deltaTime);
    }


    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.collider.gameObject.tag == "PickUp")
        {
            hit.gameObject.GetComponent<PickUp>().Picked();
        }
    }
}
