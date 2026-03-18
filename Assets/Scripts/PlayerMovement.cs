using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    public float Speed;

    void Start()
    {
       
        rb = GetComponent<Rigidbody>();


    }

    private void FixedUpdate()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3 (moveX, 0.7f, moveZ);
        rb.AddForce (movement * Speed);
    }


}
