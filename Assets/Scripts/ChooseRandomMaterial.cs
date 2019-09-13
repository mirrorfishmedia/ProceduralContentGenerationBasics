using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseRandomMaterial : MonoBehaviour
{

    public Material[] materialsToChooseFrom;
    public Renderer thisRenderer;

    // Start is called before the first frame update
    void Start()
    {
        thisRenderer.material = materialsToChooseFrom[Random.Range(0, materialsToChooseFrom.Length)];
    }
    
}
