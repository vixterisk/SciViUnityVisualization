using System;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class Visualizer : MonoBehaviour
{
    public Settings settings;

    private int GetIndex(float signal)
    {
        int left = 0;
        int right = settings.values.Length - 1;
        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            if (settings.values[mid] <= signal && settings.values[mid + 1] >= signal)
            {
                return mid;
            }
            else if (settings.values[mid + 1] < signal)
            {
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }
        return -1;
    }

    private bool AreNeighboringValuesEqual(int leftIndex)
    {
        return Math.Abs(settings.values[leftIndex + 1] - settings.values[leftIndex]) <= Single.Epsilon;
    }
    
    private Color ConvertSignalToColor(float signal)
    {
        //Debug.Log(1f/Time.unscaledDeltaTime);
        switch (signal)
        {
            case var _ when signal <= settings.values[0]:
                return settings.colors[0];
            case var _ when signal >= settings.values[^1]:
                return settings.colors[settings.values.Length];
            default:
                var leftIndex = GetIndex(signal);
                var denominator = AreNeighboringValuesEqual(leftIndex)
                    ? settings.values[leftIndex]
                    : settings.values[leftIndex + 1] - settings.values[leftIndex];
                var normalizedSignal = (signal - settings.values[leftIndex]) / denominator;
                return Color.Lerp(settings.colors[leftIndex + 1], settings.colors[leftIndex + 2], normalizedSignal);//.gamma;
        }
    }
    
    public void Draw(Dictionary<string, float> data)
    {
        var lights = GetComponentsInChildren<Light>();
        for (int i = 0; i < lights.Length; i++)
        {
            var currentLight = lights[i];
            var currentLightName = currentLight.name.ToLower();
            if (data.ContainsKey(currentLightName))
            {
                var color = ConvertSignalToColor(data[currentLightName]);
                currentLight.color = new Color(color.r / 255f, color.g / 255f, color.b / 255f, 1f);
            }
        }
    }
}
