using Blahkhan.Demo.Coin;
using Blahkhan.Demo.Heart;
using Blahkhan.Demo.Player;
using UnityEngine;
using Zenject;

namespace Blahkhan.Demo.GameState
{
    public class GameStateInstaller : MonoInstaller
    {
        [SerializeField] private HeartController heartController;
        [SerializeField] private CoinController coinController;
        [SerializeField] private PlayerController playerController;
        [SerializeField] private GameStateController gameStateController;
        [SerializeField] private GameStateSettings gameStateSettings;

        public override void InstallBindings()
        {
            Container.Bind<GameStateController>().FromInstance(gameStateController).AsSingle();
            Container.Bind<GameStateSettings>().FromInstance(gameStateSettings).AsSingle();

            Container.BindFactory<PlayerController, PlayerController.Factory>()
                .FromComponentInNewPrefab(playerController);
            Container.BindFactory<CoinController, CoinController.Factory>()
                .FromComponentInNewPrefab(coinController);
            Container.BindFactory<HeartController, HeartController.Factory>()
                .FromComponentInNewPrefab(heartController);
        }
    }
}
