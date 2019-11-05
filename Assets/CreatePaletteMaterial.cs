using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePaletteMaterial : MonoBehaviour
{
    public MultiColorPalette colorPalette;

    public List<Color> saturationVariations;
    public List<Color> valueVariations;
    public List<Color> combinedColorList;

    public MeshRenderer thisRenderer;


    void Start()
    {

        thisRenderer = GetComponent<MeshRenderer>();
        if (colorPalette.outputColors.Count <= 0)
        {
            return;
        }
        Color newColor = colorPalette.outputColors[Random.Range(0, colorPalette.outputColors.Count)];

        Material generatedMaterial = new Material(Shader.Find("Standard"));
        generatedMaterial.SetColor("_Color", newColor);
        thisRenderer.material = generatedMaterial;
        
    }
}
