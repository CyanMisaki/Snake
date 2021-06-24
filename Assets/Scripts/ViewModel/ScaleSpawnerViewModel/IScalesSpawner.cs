using Model;
using UnityEngine;

namespace ViewModel
{
    public interface IScalesSpawner
    {
        IGameFieldModel GameFieldModel { get; }
        ISnakeModel SnakeModel { get; }

        Vector3 GameFieldSize { get; }
        Vector3 GetRandomFoodPosition();
        GameObject GetScalePrefab();
        void InitNewFood(GameObject food);

    }
}