using UnityEngine;

namespace Blahkhan.Demo.GameState
{

    [CreateAssetMenu(fileName = "GameStateSettings", menuName = "Data/Settings/GameStateSettings")]
    public class GameStateSettings : ScriptableObject
    {
        [SerializeField] private int maxPlayerHP;
        [SerializeField] private int maxMushroomHP;
        [SerializeField] private int maxGoblinHP;

        public int MaxPlayerHP => maxPlayerHP;
        public int MaxMushroomHP => maxMushroomHP;
        public int MaxGoblinHP => maxGoblinHP;
    }
}
