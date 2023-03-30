using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class DataReceiver : MonoBehaviour
{
    public Visualization visualizer;
    private bool _settingsInitialized = false;
    private void Start()
    {
        try
        {
            visualizer.settings = new VisualizationSettings(
                    new [] { Color.grey, Color.green, Color.green, Color.red, Color.red, Color.red }, 
                    new [] { 0.0f, 30.0f, 30.0f, 60.0f, 60.0f}
                    );
            _settingsInitialized = true;
        }
        // Проверить что работает на одной точке
        catch (Exception e)
        {
            Debug.Log(e.Message);
        }
    }

    void Update()
    {
        if (!_settingsInitialized) return;
        var lowerThreshold = visualizer.settings.Values[0] - 5.0f;
        // lowerThreshold = lowerThreshold + Time.unscaledDeltaTime * 3;
        float higherThreshold = visualizer.settings.Values[^1] + 5.0f;
        var data = new Dictionary<string, float>()
        {
            { "Fp1", Random.Range(lowerThreshold, higherThreshold) },
            { "Fp2", Random.Range(lowerThreshold, higherThreshold) },
            { "F7", Random.Range(lowerThreshold, higherThreshold) },
            { "F3", Random.Range(lowerThreshold, higherThreshold) },
            { "Fz", Random.Range(lowerThreshold, higherThreshold) },
            { "F4", Random.Range(lowerThreshold, higherThreshold) },
            { "F8", Random.Range(lowerThreshold, higherThreshold) },
            { "T3", Random.Range(lowerThreshold, higherThreshold) },
            { "C3", Random.Range(lowerThreshold, higherThreshold) },
            { "Cz", Random.Range(lowerThreshold, higherThreshold) },
            { "C4", Random.Range(lowerThreshold, higherThreshold) },
            { "T4", Random.Range(lowerThreshold, higherThreshold) },
            { "T5", Random.Range(lowerThreshold, higherThreshold) },
            { "P3", Random.Range(lowerThreshold, higherThreshold) },
            { "Pz", Random.Range(lowerThreshold, higherThreshold) },
            { "P4", Random.Range(lowerThreshold, higherThreshold) },
            { "T6", Random.Range(lowerThreshold, higherThreshold) },
            { "O1", Random.Range(lowerThreshold, higherThreshold) },
            { "O2", Random.Range(lowerThreshold, higherThreshold) },
        };
        visualizer.Draw(data);
    }
}