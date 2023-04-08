using UnityEngine;
using System.Collections;

public class JoyStickControl : MonoBehaviour
{
    [SerializeField] private CharacterController characterController;
    [SerializeField] private FloatingJoystick joystick;
    private float speed = 10.0f; // Tốc độ di chuyển của nhân vật


    void FixedUpdate()
    {
        // Lấy giá trị đầu vào của joystick
        float moveHorizontal = joystick.Horizontal;
        float moveVertical = joystick.Vertical;
        // Tạo vector di chuyển theo hướng của joystick
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        if (movement.magnitude < 0.5f)
        {
            movement = Vector3.zero;
        // Thay đổi vị trí của nhân vật
        }
            characterController.Move(new Vector3( movement.x * speed * Time.fixedDeltaTime, -9.8f, movement.z * speed * Time.fixedDeltaTime));
        
    }
}
