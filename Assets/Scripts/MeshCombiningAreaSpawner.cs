using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshCombiningAreaSpawner : MonoBehaviour
{
    public GameObject itemToSpread;
    public int numItemsToSpawn = 10;

    public float itemXSpread = 10;
    public float itemYSpread = 0;
    public float itemZSpread = 10;

    public Vector3 randomRotationConstraints;
    public GameObject[] meshColorObjects;

    private List<GameObject> gameObjectsToCombine = new List<GameObject>();
     

    // Start is called before the first frame update
    void Start()
    {
        SpreadColorAndCombine();
    }

    void SpreadColorAndCombine()
    {
        //Spread
        for (int i = 0; i < numItemsToSpawn; i++)
        {
            SpreadItem();
        }

        //Color and combine
        for (int j = 0; j < meshColorObjects.Length; j++)
        {
            CombineMeshes(meshColorObjects[j]);
        }
    }

    void SpreadItem()
    {
        Vector3 randPosition = new Vector3(Random.Range(-itemXSpread, itemXSpread), Random.Range(-itemYSpread, itemYSpread), 
            Random.Range(-itemZSpread, itemZSpread)) + transform.position;

        GameObject clone = Instantiate(itemToSpread, randPosition, itemToSpread.transform.rotation);

        clone.transform.rotation = RandomizeByAxis(randomRotationConstraints, clone.transform);

        clone.transform.SetParent(meshColorObjects[Random.Range(0,meshColorObjects.Length)].transform);
        gameObjectsToCombine.Add(clone);
    }

    public Quaternion RandomizeByAxis(Vector3 randomRotationConstraints, Transform transformToRotate)
    {
        Quaternion randomConstrainedRotation = 
            Quaternion.Euler(transformToRotate.rotation.eulerAngles.x + 
            Random.Range(-randomRotationConstraints.x, randomRotationConstraints.x),
            transformToRotate.rotation.eulerAngles.y + Random.Range(-randomRotationConstraints.y, randomRotationConstraints.y),
            transformToRotate.rotation.eulerAngles.z + Random.Range(-randomRotationConstraints.z, randomRotationConstraints.z));

        return randomConstrainedRotation;
    }

    public void CombineMeshes(GameObject obj)
    {
        //Temporarily set position to zero to make matrix math easier
        Vector3 position = obj.transform.position;
        obj.transform.position = Vector3.zero;

        //Get all mesh filters and combine
        MeshFilter[] meshFilters = obj.GetComponentsInChildren<MeshFilter>();
        CombineInstance[] combine = new CombineInstance[meshFilters.Length];
        int i = 1;
        while (i < meshFilters.Length)
        {
            combine[i].mesh = meshFilters[i].sharedMesh;
            combine[i].transform = meshFilters[i].transform.localToWorldMatrix;
            meshFilters[i].gameObject.SetActive(false);
            i++;
        }

        obj.transform.GetComponent<MeshFilter>().mesh = new Mesh();
        obj.transform.GetComponent<MeshFilter>().mesh.CombineMeshes(combine, true, true);
        obj.transform.gameObject.SetActive(true);

        //Return to original position
        obj.transform.position = position;

        //Add collider to mesh (if needed)
        //obj.AddComponent<MeshCollider>();
    }
}
