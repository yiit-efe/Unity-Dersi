using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    public float Speed;
    public float JumpHeight;
    void Start()
    {
       
        rb = GetComponent<Rigidbody>();


    }

    private void FixedUpdate()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        float moveY = Input.GetAxis("Jump");
        Vector3 movement = new Vector3 (moveX, moveY, moveZ);
        rb.AddForce (movement * Speed);

     
        

    }


}
