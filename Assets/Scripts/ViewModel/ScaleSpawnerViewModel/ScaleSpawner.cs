using Markers;
using Model;
using UnityEngine;

namespace ViewModel
{
    public class ScaleSpawner : IScalesSpawner
    {
        public IGameFieldModel GameFieldModel { get; }
        public ISnakeModel SnakeModel { get; }
        public Vector3 GameFieldSize { get; }


        public ScaleSpawner(IGameFieldModel gameFieldModel, ISnakeModel snakeModel)
        {
            GameFieldModel = gameFieldModel;
            SnakeModel = snakeModel;
            GameFieldSize = gameFieldModel.GameFieldPrefab.transform.localScale;
        }
        public Vector3 GetRandomFoodPosition()
        {
            return new Vector3(Random.Range(-GameFieldSize.x/2+5f, GameFieldSize.x/2-5f), Random.Range(-GameFieldSize.y/2+5f, GameFieldSize.y/2-5f), 15f);
        }

        public GameObject GetScalePrefab()
        {
            return SnakeModel.ScalePrefab;
        }

        public void InitNewFood(GameObject food)
        {
            food.AddComponent<FoodMarker>();
        }
    }
}