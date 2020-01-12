using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickItem : MonoBehaviour
{
    public GameObject[] itemsToPickFrom;

    // Start is called before the first frame update
    void Start()
    {
        Pick();
    }

    void Pick()
    {
        int randomIndex = Random.Range(0, itemsToPickFrom.Length);
        GameObject clone = Instantiate(itemsToPickFrom[randomIndex], transform.position, transform.rotation);
    }



}
