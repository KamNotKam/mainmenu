using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float walkSpeed = 5f;
    public float sprintSpeed = 8f;

    float currentSpeed;

    void Update()
    {
        float x = Input.GetAxis("Horizontal"); // A D
        float z = Input.GetAxis("Vertical");   // W S

        // cek sprint
        if (Input.GetKey(KeyCode.LeftShift))
            currentSpeed = sprintSpeed;
        else
            currentSpeed = walkSpeed;

        Vector3 move = transform.right * x + transform.forward * z;

        transform.Translate(move * currentSpeed * Time.deltaTime, Space.World);
    }
}