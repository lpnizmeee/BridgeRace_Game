using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Nhân vật được camera follow
    public float smoothing = 5f; // Hệ số mượt khi camera di chuyển

    private Vector3 offset; // Khoảng cách giữa camera và nhân vật

    void Start()
    {
        // Tính khoảng cách giữa camera và nhân vật
        offset = transform.position - target.position;
    }

    void FixedUpdate()
    {
        // Tạo vị trí mới của camera
        Vector3 targetCamPos = target.position + offset;

        // Di chuyển camera đến vị trí mới theo hệ số mượt
        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
    }
}
