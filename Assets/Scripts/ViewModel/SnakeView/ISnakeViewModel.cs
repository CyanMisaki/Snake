using System;
using System.Collections.Generic;
using Model;
using UnityEngine;

namespace ViewModel
{
    public interface ISnakeViewModel
    {
        ISnakeModel SnakeModel { get;  }
        int NumOfStartSnakeLength { get; }
        bool IsDead { get;  }
        bool IsSnakeInited { get;  }
        void InitSnake();
        void AddScale();
        void AddScaleToSnake(GameObject scale);
        
        void LengthenTheSnake(GameObject scale);
        
        event Action<GameObject> OnScalesAdd;
        
        
    }
}