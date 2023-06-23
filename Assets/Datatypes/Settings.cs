using UnityEngine;

public class Settings
{
    public float[] values { get; set; }

    public Color[] colors { get; set; }

    public Settings(float[] values, Color[] colors)
    {
        if (values == null || colors == null)
            throw new NotConfiguredSettingsException("Settings package corrupted");
        if (values.Length == 0)
            throw new InvalidSettingsFormatException("The value array must not be empty");
        if (colors.Length - 1 != values.Length)
            throw new InvalidSettingsFormatException("The number of elements in the color array must exceed the number of elements in the value array by 1");
        this.colors = colors;
        this.values = values;
    }
}
