using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public PlayerMovement playerMovement;

    private void FixedUpdate()
    {
        transform.position = playerMovement.transform.position + new Vector3(0, 1.1f, -4f);
    }
}
