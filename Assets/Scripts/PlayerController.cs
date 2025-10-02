using UnityEngine;

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
        float y = Input.GetAxisRaw("Jump");

        RaycastHit hit;
        if (Physics.Raycast(groundCheck.position,transform.TransformDirection(Vector3.down), out hit, 0.4f, groundLayer))
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
                    speed = 30;
                    break;
                case "TooHigh":
                    speed = 100;
                    break;
            }
        }

        Vector3 move = transform.right * x + transform.forward * z + transform.up * y;
        characterController.Move(move* speed * Time.deltaTime);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.collider.gameObject.tag == "Pickup")
        {
            hit.gameObject.GetComponent<Pickup>().Picked();
        }
    }
}
