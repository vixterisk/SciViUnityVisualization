using UnityEngine;

public struct VisualizationSettings
{    
    public Color[] Colors { get; private set; }
    public float[] Values { get; private set; }
    
    public VisualizationSettings(Color[] colors, float[] values)
    {
        if (colors.Length - 1 != values.Length)
            throw new InvalidSettingsFormatException("Values array length != colors array length + 1");
        Colors = colors;
        Values = values;
    }
}
