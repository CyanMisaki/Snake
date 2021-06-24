using System;
using System.Collections.Generic;
using Model;
using UnityEngine;

namespace ViewModel
{
    public interface ISnakeMoveModel
    {
        ISnakeModel SnakeModel { get; }

        bool IsMoveOnLeft { get; set; }
        bool IsMoveOnRight { get; set; }
        bool IsMoveOnTop { get; set; }
        bool IsMoveOnBottom { get; set; }
        bool IsOneStepTaken { get; set; }
        Vector3 SnakeScaleLocalScale { get; }

        int GetSnakeLength();
        Vector3 GetSnakeLastScalePosition();
        void ChangeScalesPosition();
        void MoveScales();
        void RewritePositionsInDictionary();
    }
}