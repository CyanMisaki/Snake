using System;
using System.Collections.Generic;
using System.Linq;
using Model;
using UnityEngine;

namespace ViewModel
{
    public class SnakeViewModel : ISnakeViewModel
    {
        public event Action<GameObject> OnScalesAdd;
        public ISnakeModel SnakeModel { get; }
        public int NumOfStartSnakeLength { get; }
        public bool IsDead { get; }
        public bool IsSnakeInited { get; private set; }


        public SnakeViewModel(ISnakeModel snakeModel, int numOfStartSnakeLength)
        {
            SnakeModel = snakeModel;
            NumOfStartSnakeLength = numOfStartSnakeLength;
        }

        public void InitSnake()
        {
            for (var index = 0; index < NumOfStartSnakeLength; index++)
            {
                AddScale();
            }

            IsSnakeInited = true;
        }
        
        public void AddScale()
        {
            SnakeModel.NumOfScales ++;
            OnScalesAdd?.Invoke(SnakeModel.ScalePrefab);
        }
        
        public void AddScaleToSnake(GameObject scale)
        {
            SnakeModel.SnakeScales.Add(scale, scale.transform.position);
        }
        
        public void LengthenTheSnake(GameObject scale)
        {
            var scales = SnakeModel.SnakeScales;
            var prefabScale = SnakeModel.ScalePrefab.transform.localScale;
            
            if (scales.ElementAt(scales.Count - 2).Value.x < scales.Last().Value.x)
            {
                scale.transform.position = new Vector3(scales.Last().Value.x + prefabScale.x + 0.2f, scales.Last().Value.y, scales.Last().Value.z);
                scale.SetActive(true);
                AddScaleToSnake(scale);
            }
            else if (scales.ElementAt(scales.Count - 2).Value.x > scales.Last().Value.x)
            {
                scale.transform.position = new Vector3(scales.Last().Value.x - prefabScale.x + 0.2f, scales.Last().Value.y, scales.Last().Value.z);
                scale.SetActive(true);
                AddScaleToSnake(scale);
            }
            else if (scales.ElementAt(scales.Count - 2).Value.y < scales.Last().Value.y)
            {
                scale.transform.position = new Vector3(scales.Last().Value.x, scales.Last().Value.y + prefabScale.y + 0.2f,scales.Last().Value.z);
                scale.SetActive(true);
                AddScaleToSnake(scale);
            }
            else if (scales.ElementAt(scales.Count - 2).Value.y > scales.Last().Value.y)
            {
                scale.transform.position = new Vector3(scales.Last().Value.x, scales.Last().Value.y - prefabScale.y + 0.2f,scales.Last().Value.z);
                scale.SetActive(true);
                AddScaleToSnake(scale);
            }
        }
    }
}