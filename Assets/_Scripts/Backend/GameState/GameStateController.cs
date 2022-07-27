using Blahkhan.Demo.Hud;
using Blahkhan.Demo.Player;
using UnityEngine;

namespace Blahkhan.Demo.GameState
{
    public class GameStateController : MonoBehaviour
    {
		#region variables

		[Zenject.Inject] private GameStateSettings gameStateSettings;
		[Zenject.Inject] private PlayerController.Factory playerFactory;
		[Zenject.Inject] private HudController hudController;

		private int coinAmount = 0;
		private int maxPlayerHP;
		private int currentPlayerHP;

		#endregion

		#region properties

		public int CurrentPlayerHP => currentPlayerHP;
		public int CoinAmount => coinAmount;
		public PlayerController PlayerController { get; private set; }

		#endregion

		#region unity methods

		private void Start()
		{
			CreatePlayer();
			SetupGame();
		}

		#endregion

		#region public methods

		public void TakeDamage()
		{
			if (PlayerController.IsAttacking) return;
			if (currentPlayerHP <= 0) return;

			hudController.TakeDamage();
			currentPlayerHP -= 1;
			if (currentPlayerHP == 0)
			{
				StartCoroutine(PlayerController.Die());
			}
		}

		public void Heal()
		{
			hudController.Heal();
			currentPlayerHP++;
		}

		public void AddCoins(int amount)
		{
			if (amount == 0) return;

			coinAmount += amount;
			hudController.UpdateCoinCounter(coinAmount);
			if (coinAmount > 0)
			{
				hudController.TriggerCoinChanger(amount, Color.green);
			}
			else
			{
				hudController.TriggerCoinChanger(amount, Color.red);
			}
		}

		public void CreatePlayer()
		{
			var player = playerFactory.Create();
			player.transform.position = Vector2.zero;
			player.transform.parent = transform;
			PlayerController = player;
		}

		public void DeletePlayer()
		{
			Destroy(PlayerController.gameObject);
			PlayerController = null;
		}

		#endregion

		#region private methods

		private void SetupGame()
		{
			hudController.UpdateCoinCounter(coinAmount);
			maxPlayerHP = gameStateSettings.MaxPlayerHP;
			currentPlayerHP = maxPlayerHP;
		}

		#endregion
	}
}
