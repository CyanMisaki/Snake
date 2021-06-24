using System;
using Model.Points;

namespace Snake.ViewModel.PointsViewModel
{
    public class PointsViewModel : IPointsViewModel
    {
        public IPointsModel PointsModel { get; set; }
        public event Action OnSpeedIncrease;
        public event Action<int> OnPointsAdd;

        public PointsViewModel(IPointsModel pointsModel)
        {
            PointsModel = pointsModel;
        }
        public void AddPoints()
        {
            PointsModel.Points++;
            OnPointsAdd?.Invoke(PointsModel.Points);
            if (GetPoints()%5==0)
                OnSpeedIncrease?.Invoke();
        }

        public int GetPoints()
        {
            return PointsModel.Points;
        }

        
    }
}