using UnityEngine;

public class playerMovement : MonoBehaviour
{

    public float speed = 5f;
    public float jumpForce = 5f;
    public Rigidbody Rigidbody;
    private bool isGrounded;
    public Camera playerCamera;

   public void Move(float horizontal, float vertical)
    {
        Vector3 movement = new Vector3(horizontal, 0, vertical).normalized * speed * Time.deltaTime;
        Vector3 moveDirection = transform.TransformDirection(movement);
        Rigidbody.MovePosition(Rigidbody.position + moveDirection);
    }

   public void Jump()
    {
        if (isGrounded)
        {
            Rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    public void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }


    public void LookAround(float mouseX, float mouseY)
    {
        transform.Rotate(0, mouseX, 0);
        playerCamera.transform.Rotate(-mouseY, 0, 0);
    }



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
