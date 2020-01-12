using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastItemAligner : MonoBehaviour
{
    public float raycastDistance = 100f;
    public GameObject objectToSpawn;

    // Start is called before the first frame update
    void Start()
    {
        PositionRaycast();
    }

    void PositionRaycast()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, Vector3.down, out hit, raycastDistance))
        {
            Quaternion spawnRotation = Quaternion.FromToRotation(Vector3.up, hit.normal);
            
            GameObject clone = Instantiate(objectToSpawn, hit.point, spawnRotation);
        }
    }
}
