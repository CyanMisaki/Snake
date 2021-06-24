using System;
using UnityEngine;

namespace Snake.ViewModel.CollisionHandler
{
    public interface ICollisionHandler
    {
        void HandleCollision(Collider other);
        event Action OnSnakeCrash;
        event Action<GameObject> OnSnakePicketFood;
    }
}