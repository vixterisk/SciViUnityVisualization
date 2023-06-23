using System.Collections.Generic;
using JetBrains.Annotations;

namespace DefaultNamespace
{
    public class VisualizationPackage
    {
        [CanBeNull] public Settings settings { get; set; }
        [CanBeNull] public Dictionary<string, float> data { get; set; }
    }
}