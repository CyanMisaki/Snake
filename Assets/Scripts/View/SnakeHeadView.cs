using System;
using Snake.ViewModel.CollisionHandler;
using UnityEngine;

namespace View
{
    public class SnakeHeadView : MonoBehaviour
    {
        private ICollisionHandler _collisionHandler;
        
        public void Init(ICollisionHandler collisionHandler)
        {
            _collisionHandler = collisionHandler;
        }

        private void OnTriggerEnter(Collider other)
        {
            _collisionHandler.HandleCollision(other);
        }
    }
}