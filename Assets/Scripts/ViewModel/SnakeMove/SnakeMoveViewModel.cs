using System;
using System.Collections.Generic;
using System.Linq;
using Markers;
using Model;
using UnityEngine;

namespace ViewModel
{
    public class SnakeMoveViewModel : ISnakeMoveModel
    {
        
        public ISnakeModel SnakeModel { get; }
        public bool IsMoveOnLeft { get; set; }
        public bool IsMoveOnRight { get; set; }
        public bool IsMoveOnTop { get; set; }
        public bool IsMoveOnBottom { get; set; }
        public bool IsOneStepTaken { get; set; }
        public Vector3 SnakeScaleLocalScale { get; private set; }
        private Vector3 _newScalePosition;
        
        public SnakeMoveViewModel(ISnakeModel snakeModel)
        {
            SnakeModel = snakeModel;
            IsMoveOnLeft = false;
            IsMoveOnRight = false;
            IsMoveOnTop = true;
            IsMoveOnBottom = false;
            IsOneStepTaken = true;
            SnakeScaleLocalScale = snakeModel.ScalePrefab.transform.localScale;
        }

        public int GetSnakeLength()
        {
            return SnakeModel.SnakeScales.Count();
        }

        public Vector3 GetSnakeLastScalePosition()
        {
            return SnakeModel.SnakeScales.Last().Key.transform.position;
        }

        public void ChangeScalesPosition()
        {
            if (IsMoveOnTop)
            {
                _newScalePosition = SnakeModel.SnakeScales.ElementAt(0).Value;
                _newScalePosition.y+=SnakeModel.SnakeScales.ElementAt(0).Key.transform.localScale.y + 0.2f;
                MoveScales();
                RewritePositionsInDictionary();
            }  
            else if (IsMoveOnLeft)
            {
                _newScalePosition = SnakeModel.SnakeScales.ElementAt(0).Value;
                _newScalePosition.x-=SnakeModel.SnakeScales.ElementAt(0).Key.transform.localScale.x + 0.2f; 
                MoveScales();
                RewritePositionsInDictionary();
            }
            else if (IsMoveOnRight)
            {
                _newScalePosition = SnakeModel.SnakeScales.ElementAt(0).Value;
                _newScalePosition.x+=SnakeModel.SnakeScales.ElementAt(0).Key.transform.localScale.x + 0.2f; 
                MoveScales();
                RewritePositionsInDictionary();
            }
            else if (IsMoveOnBottom)
            {
                _newScalePosition = SnakeModel.SnakeScales.ElementAt(0).Value;
                _newScalePosition.y-=SnakeModel.SnakeScales.ElementAt(0).Key.transform.localScale.y + 0.2f;
                MoveScales();
                RewritePositionsInDictionary();
            }
                
            IsOneStepTaken = true;
        }

        public void MoveScales()
        {
            SnakeModel.SnakeScales.ElementAt(0).Key.transform.position = _newScalePosition;
            for (var scaleKey = 1; scaleKey < SnakeModel.SnakeScales.Count; scaleKey++)
            {
                SnakeModel.SnakeScales.ElementAt(scaleKey).Key.transform.position = SnakeModel.SnakeScales.ElementAt(scaleKey - 1).Value;
            }
        }

        public void RewritePositionsInDictionary()
        {
            for (var scaleValue = SnakeModel.SnakeScales.Count-1; scaleValue > 0 ; scaleValue--)
            {
                SnakeModel.SnakeScales[SnakeModel.SnakeScales.ElementAt(scaleValue).Key] = SnakeModel.SnakeScales.ElementAt(scaleValue - 1).Value;
            }
            SnakeModel.SnakeScales[SnakeModel.SnakeScales.ElementAt(0).Key] = _newScalePosition;
        }
    }
}