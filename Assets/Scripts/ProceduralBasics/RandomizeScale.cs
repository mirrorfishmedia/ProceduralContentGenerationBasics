using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizeScale : MonoBehaviour
{
    public float globalScaleMultiplier = 1f;

    public bool scaleUniformly;

    public float uniformScaleMin = .1f;
    public float uniformScaleMax = 1f;

    public float xScaleMin = .1f;
    public float xScaleMax = 3f;
    public float yScaleMin = .1f;
    public float yScaleMax = 3f;
    public float zScaleMin = .1f;
    public float zScaleMax = 3f;


    void Start()
    {
        RandomizeObjectScale();
    }

    void RandomizeObjectScale()
    {
        Vector3 randomizedScale = Vector3.one;
        if (scaleUniformly)
        {
            float uniformScale = Random.Range(uniformScaleMin, uniformScaleMax);
            randomizedScale = new Vector3(uniformScale, uniformScale, uniformScale);
        }
        else
        {
           randomizedScale = new Vector3(Random.Range(xScaleMin, xScaleMax), Random.Range(yScaleMin, yScaleMax), Random.Range(zScaleMin, zScaleMax));
        }

        transform.localScale = randomizedScale * globalScaleMultiplier;
    }
}
