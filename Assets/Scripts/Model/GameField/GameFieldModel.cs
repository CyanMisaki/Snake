using UnityEngine;

namespace Model
{
    public class GameFieldModel : IGameFieldModel
    {
        public GameObject GameFieldPrefab { get; set; }
        

        public GameFieldModel(GameObject gameFieldPrefab)
        {
            GameFieldPrefab = gameFieldPrefab;
        }
    }
}