using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizeRotation : MonoBehaviour
{
    public Vector3 randomRotationRange;
    
    // Start is called before the first frame update
    void Start()
    {
        RandomizeByAxis(randomRotationRange);
    }

    void RandomizeMyRotation()
    {
        transform.rotation = Random.rotation;
    }

    public void RandomizeByAxis(Vector3 randomRotationConstraints)
    {
        Quaternion randomConstrainedRotation = Quaternion.Euler(transform.rotation.eulerAngles.x + Random.Range(-randomRotationConstraints.x, randomRotationConstraints.x),
            transform.rotation.eulerAngles.y + Random.Range(-randomRotationConstraints.y, randomRotationConstraints.y),
            transform.rotation.eulerAngles.z + Random.Range(-randomRotationConstraints.z, randomRotationConstraints.z));

        transform.rotation = randomConstrainedRotation;
    }
    
}
