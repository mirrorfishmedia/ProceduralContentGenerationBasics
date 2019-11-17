using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePaletteMaterial : MonoBehaviour
{
    public MultiColorPalette colorPalette;

    public MeshRenderer[] renderers;
    public int targetIndexToColor = 0;
    
    void Start()
    {
        Color newColor = colorPalette.outputColors[Random.Range(0, colorPalette.outputColors.Count)];
        ApplyMaterial(newColor,0);
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
