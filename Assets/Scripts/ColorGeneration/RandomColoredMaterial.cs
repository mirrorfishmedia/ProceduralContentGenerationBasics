using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomColoredMaterial : MonoBehaviour
{
    public MeshRenderer[] renderers;

    void Start()
    {
        //Color newColor = Random.ColorHSV();
        //Color newColor = Random.ColorHSV(0f, .5f);
        Color newColor = Random.ColorHSV(0f, .25f, 0.4f, 1f);
        ApplyMaterial(newColor, 0);

    }

    void ApplyMaterial(Color color, int targetMaterialIndex)
    {
        Material generatedMaterial = new Material(Shader.Find("Standard"));
        generatedMaterial.SetColor("_Color", color);
        for (int i = 0; i < renderers.Length; i++)
        {
            renderers[i].material = generatedMaterial;
        }
    }
}
