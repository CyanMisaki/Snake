using System;
using Model;
using Model.Points;
using Snake.ViewModel.CollisionHandler;
using Snake.ViewModel.PointsViewModel;
using UnityEngine;
using View;
using ViewModel;

namespace Snake
{
    public class GameStarter : MonoBehaviour
    {
        [SerializeField] private GameObject _scalePrefab;
        [SerializeField]private SnakeView _snakeView;
        [SerializeField] private int _numOfStartSnakeLength;
        [SerializeField][Range(150, 10)] private int _snakeSpeed=100;
        [SerializeField] private GameObject _gameFiled;
        private SnakeHeadView _snakeHeadView;
        
        private void Start()
        {
            var gameFieldModel = new GameFieldModel(_gameFiled);
            var collisionHandler = new CollisionHandler();
            var snakeModel = new SnakeModel(_scalePrefab);
            
            var gameFieldViewModel = new ScaleSpawner(gameFieldModel,snakeModel);
            var snakeMoveViewModel = new SnakeMoveViewModel(snakeModel);
            
            var snakeViewModel = new SnakeViewModel(snakeModel, _numOfStartSnakeLength);

            var pointsModel = new PointsModel();
            var pointsViewModel = new PointsViewModel(pointsModel);
            
            _snakeView.Init(snakeViewModel, snakeMoveViewModel, gameFieldViewModel, collisionHandler, pointsViewModel, ref _snakeSpeed);

            _snakeHeadView = FindObjectOfType<SnakeHeadView>();
            _snakeHeadView.Init(collisionHandler);

        }
    }
}