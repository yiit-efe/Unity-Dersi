using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Hareket Ayarlarý")]
    public float moveSpeed = 7f;
    public float jumpHeight = 2.5f;

    [Header("Geliþmiþ Fizik (Düþüþ Hýzý)")]
    public float gravity = -30f;       // Standart -9.81 yerine -30 daha serttir
    public float fallMultiplier = 3.5f; // Düþerken yerçekimini 3.5 katýna çýkarýr
    public float lowJumpMultiplier = 2f; // Zýplama tuþuna kýsa basýlýrsa daha hýzlý düþer

    [Header("Zýplama Cooldown")]
    public float jumpCooldown = 0.2f;
    private float lastJumpTime;

    [Header("Yer Kontrolü")]
    public Transform groundCheck;
    public float groundDistance = 0.3f;
    public LayerMask groundMask;

    private CharacterController controller;
    private Vector3 velocity;
    private bool isGrounded;

    void Start() => controller = GetComponent<CharacterController>();

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        // Hareket
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * moveSpeed * Time.deltaTime);

        // Zýplama
        if (Input.GetButtonDown("Jump") && isGrounded && Time.time >= lastJumpTime + jumpCooldown)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            lastJumpTime = Time.time;
        }

        // --- GELÝÞMÝÞ YERÇEKÝMÝ HESABI ---
        if (velocity.y < 0) // Düþüþteyse
        {
            velocity.y += gravity * fallMultiplier * Time.deltaTime;
        }
        else if (velocity.y > 0 && !Input.GetButton("Jump")) // Zýplarken tuþu erken býrakýrsa
        {
            velocity.y += gravity * lowJumpMultiplier * Time.deltaTime;
        }
        else // Normal yükseliþ veya sabit duruþ
        {
            velocity.y += gravity * Time.deltaTime;
        }

        controller.Move(velocity * Time.deltaTime);
    }
}