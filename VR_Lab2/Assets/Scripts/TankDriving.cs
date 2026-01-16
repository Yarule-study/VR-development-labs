using UnityEngine;

public class TankDriving : MonoBehaviour
{
    [SerializeField] private float drivingSpeed = 1000f;
    [SerializeField] private float turningSpeed = 50f;
    [SerializeField] private float strafeSpeed = 800f; 

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        if (rb == null)
        {
            Debug.LogError("Rigidbody не знайдено на " + gameObject.name);
        }
    }

    void FixedUpdate()
    {
        if (rb == null) return;

        float moveInput = Input.GetAxis("Vertical");      // W/S
        float turnInput = Input.GetAxis("Horizontal");    // A/D

        float strafeInput = 0f;
        if (Input.GetKey(KeyCode.Q))
            strafeInput = -1f;
        else if (Input.GetKey(KeyCode.E))
            strafeInput = 1f;

        Vector3 moveForce = transform.forward * moveInput * drivingSpeed;
        rb.AddForce(moveForce);

        Vector3 strafeForce = transform.right * strafeInput * strafeSpeed;
        rb.AddForce(strafeForce);

        float turnAmount = turnInput * turningSpeed * Time.fixedDeltaTime;
        Quaternion turnRotation = Quaternion.Euler(0f, turnAmount, 0f);
        rb.MoveRotation(rb.rotation * turnRotation);
    }
}