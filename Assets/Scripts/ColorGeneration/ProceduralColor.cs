using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ProceduralColor
{
    public Color color;
    public float maxSaturation = 1f;
    public float minSaturation = 0f;
    public float maxBrightnessValue = 1f;
    public float minBrightnessValue = 0f;
    public int variationsToGenerate = 8;
}
