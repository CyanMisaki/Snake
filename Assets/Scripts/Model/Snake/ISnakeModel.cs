using System.Collections.Generic;
using UnityEngine;

namespace Model
{
    public interface ISnakeModel
    {
        int NumOfScales { get; set; }
        GameObject ScalePrefab { get; set; }
        
        Dictionary<GameObject, Vector3> SnakeScales { get; set; }

    }
}