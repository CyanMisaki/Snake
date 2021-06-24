using System;
using Markers;
using Model.Points;
using Snake.ViewModel.CollisionHandler;
using Snake.ViewModel.PointsViewModel;
using UnityEngine;
using UnityEngine.UI;
using ViewModel;

namespace View
{
    public class SnakeView : MonoBehaviour
    {
        [SerializeField] private Text _gameOverText;
        [SerializeField] private Text _pointsText;
        private ISnakeViewModel _snakeViewModel;
        private ISnakeMoveModel _snakeMoveModel;
        private IScalesSpawner _scalesSpawner;
        private ICollisionHandler _collisionHandler;
        private IPointsViewModel _pointsViewModel;
        private bool _isGameOver = false;

        private int _snakeSpeed;
        
        public void Init(ISnakeViewModel snakeViewModel, ISnakeMoveModel snakeMoveModel, IScalesSpawner scalesSpawner, ICollisionHandler collisionHandler, IPointsViewModel pointsViewModel,ref int snakeSpeed)
        {
            _gameOverText.text = "Вы проиграли!";
            _gameOverText.enabled = false;
            
            _pointsText.text = "0";
            _pointsText.enabled = true;
            _scalesSpawner = scalesSpawner;
            _collisionHandler = collisionHandler;
            _collisionHandler.OnSnakeCrash += OnSnakeCrash;
            _collisionHandler.OnSnakePicketFood += OnSnakePicketFood;
            
            _snakeViewModel = snakeViewModel;
            _snakeViewModel.OnScalesAdd += OnScalesAdd;
            
            _snakeMoveModel = snakeMoveModel;

            _pointsViewModel = pointsViewModel;
            _pointsViewModel.OnSpeedIncrease += SpeedIncrease;
            _pointsViewModel.OnPointsAdd += ChangePointsText;
            
            _snakeSpeed = snakeSpeed;
            _snakeViewModel.InitSnake();
            
            _scalesSpawner.InitNewFood(Instantiate(_scalesSpawner.GetScalePrefab(), _scalesSpawner.GetRandomFoodPosition(), Quaternion.identity));
        }

        private void Update()
        {
            #region UserInput
            if (_snakeMoveModel.IsOneStepTaken)
            {
                if (Input.GetKeyDown(KeyCode.UpArrow) && !_snakeMoveModel.IsMoveOnBottom)
                {
                    _snakeMoveModel.IsMoveOnTop = true;
                    _snakeMoveModel.IsMoveOnBottom = false;
                    _snakeMoveModel.IsMoveOnLeft = false;
                    _snakeMoveModel.IsMoveOnRight = false;
                    _snakeMoveModel.IsOneStepTaken = false;
                }
            
                if (Input.GetKeyDown(KeyCode.LeftArrow) && !_snakeMoveModel.IsMoveOnRight)
                {
                    _snakeMoveModel.IsMoveOnTop = false;
                    _snakeMoveModel.IsMoveOnBottom = false;
                    _snakeMoveModel.IsMoveOnLeft = true;
                    _snakeMoveModel.IsMoveOnRight = false;
                    _snakeMoveModel.IsOneStepTaken = false;
                }
                if (Input.GetKeyDown(KeyCode.DownArrow) && !_snakeMoveModel.IsMoveOnTop)
                {
                    _snakeMoveModel.IsMoveOnTop = false;
                    _snakeMoveModel.IsMoveOnBottom = true;
                    _snakeMoveModel.IsMoveOnLeft = false;
                    _snakeMoveModel.IsMoveOnRight = false;
                    _snakeMoveModel.IsOneStepTaken = false;
                }
                if (Input.GetKeyDown(KeyCode.RightArrow) && !_snakeMoveModel.IsMoveOnLeft)
                {
                    _snakeMoveModel.IsMoveOnTop = false;
                    _snakeMoveModel.IsMoveOnBottom = false;
                    _snakeMoveModel.IsMoveOnLeft = false;
                    _snakeMoveModel.IsMoveOnRight = true;
                    _snakeMoveModel.IsOneStepTaken = false;
                }
            }
            #endregion

            if (!_isGameOver)
            {
                if (Time.frameCount%_snakeSpeed==0 && _snakeViewModel.IsSnakeInited)
                {
                    _snakeMoveModel.ChangeScalesPosition();
                }
            }
        }

       

        private void OnScalesAdd(GameObject scalePrefab)
        {
            GameObject newScale;
            if (_snakeMoveModel.GetSnakeLength() == 0)
            {
                newScale = Instantiate(scalePrefab, new Vector3(1f, 1f, 15f),
                    Quaternion.identity);
                newScale.AddComponent<HeadMarker>();
                newScale.AddComponent<SnakeHeadView>();
                _snakeViewModel.AddScaleToSnake(newScale);
            }
            else
            {
                newScale = Instantiate(scalePrefab,
                    new Vector3(_snakeMoveModel.GetSnakeLastScalePosition().x,
                        (_snakeMoveModel.GetSnakeLastScalePosition().y -
                         _snakeMoveModel.SnakeScaleLocalScale.y) - 0.2f,
                        _snakeMoveModel.GetSnakeLastScalePosition().z),
                    Quaternion.identity);
                newScale.AddComponent<ScaleMarker>();
                _snakeViewModel.AddScaleToSnake(newScale);
            }
        }
        
        private void OnSnakePicketFood(GameObject food)
        {
            Destroy(food.GetComponent<FoodMarker>());
            food.AddComponent<ScaleMarker>();
            food.SetActive(false);
            _snakeViewModel.LengthenTheSnake(food);
            _pointsViewModel.AddPoints();
            _scalesSpawner.InitNewFood(Instantiate(_scalesSpawner.GetScalePrefab(), _scalesSpawner.GetRandomFoodPosition(), Quaternion.identity));
        }

        private void OnSnakeCrash()
        {
            _gameOverText.enabled = true;
            _isGameOver = true;
        }
        
        private void SpeedIncrease()
        {
            _snakeSpeed -= 5;
        }

        private void ChangePointsText(int points)
        {
            _pointsText.text=points.ToString();
        }
        
        ~SnakeView()
        {
            _collisionHandler.OnSnakeCrash -= OnSnakeCrash;
            _collisionHandler.OnSnakePicketFood -= OnSnakePicketFood;
            _snakeViewModel.OnScalesAdd -= OnScalesAdd;
            _pointsViewModel.OnSpeedIncrease -= SpeedIncrease;
            _pointsViewModel.OnPointsAdd -= ChangePointsText;
        }
    }
}