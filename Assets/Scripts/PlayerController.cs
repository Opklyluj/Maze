
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 12f;
    CharacterController characterController;
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
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        float y = Input.GetAxis("Jump");

        Vector3 move = transform.right * x + transform.forward * z + transform.up * y;
        characterController.Move(move* speed * Time.deltaTime);
    }
}
