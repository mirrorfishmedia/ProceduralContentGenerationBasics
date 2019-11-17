using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ColorToy/Multi Color Palette")]
public class MultiColorPalette : ScriptableObject
{

    public ProceduralColor[] inputColors;

    public bool addInvertedColor;
    public bool addGoldenRatioColor;
    public List<Color> outputColors;
    public bool pickReducedSublistOfColors;
    public int sublistLength = 16;

    public void Generate()
    {
        outputColors.Clear();
        for (int i = 0; i < inputColors.Length; i++)
        {
            BuildListOfColorVariations(inputColors[i]);
        }
        if (pickReducedSublistOfColors)
        {
            GenerateRandomSublist(sublistLength);

        }
    }

    public void GenerateRandomSublist(int colorsToPick)
    {
        List<Color> tempColorList = new List<Color>();

        for (int i = 0; i < colorsToPick; i++)
        {
            tempColorList.Add(outputColors[Random.Range(0, outputColors.Count)]);
        }

        outputColors = tempColorList;
    }

    public void BuildListOfColorVariations(ProceduralColor inputColor)
    {
        List<Color> tempColorList = new List<Color>();
        tempColorList = GenerateSaturationVariations(inputColor, inputColor.variationsToGenerate);
        outputColors.AddRange(tempColorList);
        tempColorList = GenerateValueVariations(inputColor, inputColor.variationsToGenerate);
        outputColors.AddRange(tempColorList);

        if (addInvertedColor)
        {
            outputColors.Add(InvertColor(tempColorList[Random.Range(0, tempColorList.Count)]));
        }

        if (addGoldenRatioColor)
        {
            outputColors.Add(GoldenRatioColor(inputColor.color));
        }

    }

    public List<Color> GenerateSaturationVariations(ProceduralColor inputColor, int numberOfVariations)
    {
        List<Color> generatedColorList = new List<Color>();
        float saturationIncrement = Random.Range(inputColor.minSaturation, inputColor.maxSaturation) 
            / inputColor.variationsToGenerate;

        for (int i = 0; i < numberOfVariations; i++)
        {
            generatedColorList.Add(Desaturate(inputColor.color, saturationIncrement * i));
        }

        return generatedColorList;
    }

    public List<Color> GenerateValueVariations(ProceduralColor inputColor, int numberOfVariations)
    {
        List<Color> generatedColorList = new List<Color>();

        float valueIncrement = Random.Range(inputColor.minBrightnessValue, inputColor.maxBrightnessValue) / inputColor.variationsToGenerate;

        for (int i = 0; i < numberOfVariations; i++)
        {
            generatedColorList.Add(SetLevel(inputColor.color, valueIncrement * i));
        }
        return generatedColorList;

    }

    public Color RandomSaturated(Color rgbColor)
    {
        float myH, myS, myV;
        ColorConvert.RGBToHSV(rgbColor, out myH, out myS, out myV);
        Color returnColor = ColorConvert.HSVToRGB(myH, Random.Range(.5f, 1f), Random.Range(.5f, 1f));
        return returnColor;
    }

    public Color GoldenRatioColor(Color rgbColor)
    {
        float myH, myS, myV;
        ColorConvert.RGBToHSV(rgbColor, out myH, out myS, out myV);
        float goldH = myH + 0.618033988749895f;
        goldH = (goldH % 1f);
        Color returnColor = ColorConvert.HSVToRGB(goldH, myS, myV);
        return returnColor;
    }

    public Color SetLevel(Color aColor, float level)
    {
        Color returnColor = new Color(level * aColor.r, level * aColor.g, level * aColor.b);
        return returnColor;
    }

    public Color InvertColor(Color aColor)
    {
        Color returnColor = new Color(1.0f - aColor.r, 1.0f - aColor.g, 1.0f - aColor.b);
        return returnColor;
    }

    public Color Desaturate(Color rgbColor, float saturation)
    {
        float myH, myS, myV;
        ColorConvert.RGBToHSV(rgbColor, out myH, out myS, out myV);

        Color returnColor = ColorConvert.HSVToRGB(myH, myS * saturation, myV);
        return returnColor;
    }

}
