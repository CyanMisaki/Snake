using System.Collections.Generic;
using UnityEngine;

namespace Model
{
    public class SnakeModel : ISnakeModel
    {
        public int NumOfScales { get; set; }
        public GameObject ScalePrefab { get; set; }
        public Dictionary<GameObject, Vector3> SnakeScales { get; set; }

        public SnakeModel(GameObject scalePrefab)
        {
            ScalePrefab = scalePrefab;
            NumOfScales = 0;
            SnakeScales = new Dictionary<GameObject, Vector3>();
        }
    }
}