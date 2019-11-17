using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldColors : MonoBehaviour
{
    public MultiColorPalette colorPalette;
    public Camera myCamera;
    public float fogMin = 0.05f;
    public float fogMax = .04f;

    // Start is called before the first frame update
    void Start()
    {
        Color skyFogColor = colorPalette.outputColors[Random.Range(0, colorPalette.outputColors.Count)];
        myCamera.backgroundColor = skyFogColor;
        RenderSettings.fogColor = skyFogColor;
        RenderSettings.fogDensity = Random.Range(fogMin, fogMax);
    }
    
}
