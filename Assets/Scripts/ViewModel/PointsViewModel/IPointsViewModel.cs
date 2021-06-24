using System;
using Model.Points;
using UnityEngine;

namespace Snake.ViewModel.PointsViewModel
{
    public interface IPointsViewModel
    {
        IPointsModel PointsModel { get; set; }
        void AddPoints();
        int GetPoints();

        event Action OnSpeedIncrease;
        event Action<int> OnPointsAdd;
    }
}