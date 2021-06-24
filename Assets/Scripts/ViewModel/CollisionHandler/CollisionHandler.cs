using System;
using Markers;
using UnityEngine;

namespace Snake.ViewModel.CollisionHandler
{
    public class CollisionHandler : ICollisionHandler
    {
        public event Action OnSnakeCrash;
        public event Action<GameObject> OnSnakePicketFood;
        
        public void HandleCollision(Collider other)
        {
            if (other.gameObject.GetComponent<ScaleMarker>() || other.gameObject.GetComponent<WallMarker>())
                OnSnakeCrash?.Invoke();
            
            else if (other.gameObject.GetComponent<FoodMarker>())
                OnSnakePicketFood?.Invoke(other.gameObject);
        }
    }
}