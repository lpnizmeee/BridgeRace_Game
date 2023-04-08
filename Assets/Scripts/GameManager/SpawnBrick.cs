using System;
using UnityEngine;

public class SpawnBrick : MonoBehaviour
{
    [SerializeField] private GameObject[] brickPrefabs; // Các loại viên gạch sẽ được spawn
    [SerializeField] private LayerMask spawnLayer; // Layer mà các viên gạch sẽ được spawn
    [SerializeField] private GameObject groundBrickParent;


    private int numBricks = 11; // Số lượng viên gạch sẽ được spawn
    private float spawnRadius = 1; // Bán kính của vùng spawn viên gạch
    void Start()
    {
        // Thực hiện spawn viên gạch
        SpawnBricks();
    }

    void SpawnBricks()
    {
        for (int i = 0; i < numBricks; i++) {

            for (int j = 0; j < numBricks; j++)
            {
                //Chon 1 loai gach de spawn
                GameObject brickPrefab = brickPrefabs[UnityEngine.Random.Range(0, brickPrefabs.Length)];
                // Tạo vị trí để spawn viên gạch
                Vector3 spawnPos = transform.position + new Vector3(4*i, 0, 4*j) + new Vector3(-20  , 1, -20);                
                // Kiểm tra xem có viên gạch nào đã được spawn tại vị trí này chưa
                Collider[] colliders = Physics.OverlapSphere(spawnPos, spawnRadius);
                foreach (Collider col in colliders)
                {
                    if (col.gameObject.CompareTag("Brick"))
                    {
                        // Nếu đã có viên gạch, không spawn thêm
                        Debug.Log("Co gach rooi");
                        return;
                    }
                }
                // Kiểm tra xem vị trí spawn có nằm trong layer cho sẵn không
                RaycastHit hit;
                if (Physics.Raycast(spawnPos + Vector3.up, Vector3.down, out hit, 10f, spawnLayer))
                {
                    // Nếu vị trí spawn hợp lệ, tạo viên gạch tại vị trí đó
                    Instantiate(brickPrefab, hit.point, Quaternion.identity, groundBrickParent.transform);
                }
            }
        }
    }
}