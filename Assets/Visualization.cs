using System;
using System.Collections.Generic;
using UnityEngine;

public class Visualization : MonoBehaviour
{
    public GameObject lightsProvider;
    public VisualizationSettings settings;

    private int GetIndex(float signal)
    {
        int left = 0;
        int right = settings.Values.Length - 1;
        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            if (settings.Values[mid] <= signal && settings.Values[mid + 1] >= signal)
            {
                return mid;
            }
            else if (settings.Values[mid + 1] < signal)
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
        return Math.Abs(settings.Values[leftIndex + 1] - settings.Values[leftIndex]) <= Single.Epsilon;
    }
    
    private Color ConvertSignalToColor(float signal)
    {
        Debug.Log(1f/Time.unscaledDeltaTime);
        switch (signal)
        {
            case var _ when signal <= settings.Values[0]:
                return settings.Colors[0];
            case var _ when signal >= settings.Values[^1]:
                return settings.Colors[settings.Values.Length];
            default:
                var leftIndex = GetIndex(signal);
                var denominator = AreNeighboringValuesEqual(leftIndex)
                    ? settings.Values[leftIndex]
                    : settings.Values[leftIndex + 1] - settings.Values[leftIndex];
                var normalizedSignal = (signal - settings.Values[leftIndex]) / denominator;
                return Color.Lerp(settings.Colors[leftIndex + 1], settings.Colors[leftIndex + 2], normalizedSignal);//.gamma;
        }
    }
    
    public void Draw(Dictionary<string, float> data)
    {
        var lights = lightsProvider.GetComponentsInChildren<Light>();
        for (int i = 0; i < lights.Length; i++)
        {
            lights[i].color = ConvertSignalToColor(data[lights[i].name]);
        }
    }
}
