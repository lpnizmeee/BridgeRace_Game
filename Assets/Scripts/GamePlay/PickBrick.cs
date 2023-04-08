using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class PickBrick : MonoBehaviour
{
    [SerializeField] private LayerMask layerBrick;
    [SerializeField] private GameObject brickSpawnPrefab;
    [SerializeField] private Transform brickContainer;

    private List<GameObject> collectBrick;
    private int numberofbrick = 0;

    private void Awake()
    {
        collectBrick = new List<GameObject>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        if (other.CompareTag("Brick"))
        {
            Brick br = other.GetComponent<Brick>();
            Debug.Log("1");
            if (br.isActiveMesh)
            {
                numberofbrick += 1;
                br.DeActiveMesh();
                GameObject newbr = Instantiate(brickSpawnPrefab);
                collectBrick.Add(newbr);
                newbr.transform.SetParent(brickContainer);
                newbr.transform.position = new Vector3(brickContainer.position.x, brickContainer.position.y + 0.2f * numberofbrick, brickContainer.position.z);
            }
        }

    }
}
