using UnityEngine;

public class TankDriving : MonoBehaviour
{
    [SerializeField] private float drivingSpeed = 3f;   // швидкість руху танка
    [SerializeField] private float turningSpeed = 20f;  // швидкість повороту танка

    void Update()
    {
        float moveInput = Input.GetAxis("Vertical");     // W / S
        float turnInput = Input.GetAxis("Horizontal");   // A / D

        float deltaTime = Time.deltaTime;
        float moveAmount = moveInput * drivingSpeed * deltaTime;
        float turnAmount = turnInput * turningSpeed * deltaTime;

        // Рух вперед-назад
        transform.Translate(0f, 0f, moveAmount);

        // Поворот навколо осі Y
        transform.Rotate(0f, turnAmount, 0f);
    }
}