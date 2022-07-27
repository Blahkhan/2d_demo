using Blahkhan.Demo.GameState;
using UnityEngine;
using Zenject;

namespace Blahkhan.Demo.Coin
{
    public class CoinController : MonoBehaviour
    {
		#region types

		public class Factory : PlaceholderFactory<CoinController> { }

		#endregion

		#region variables

		[Inject] private GameStateController stateController;

		[SerializeField] private int value = 1;

		#endregion

		#region unity methods

		private void OnCollisionEnter2D(Collision2D collision)
		{
			if (collision.collider.tag != "Player") return;

			Destroy(gameObject);
		}

		private void OnDestroy()
		{
			stateController.AddCoins(value);
		}

		#endregion
	}
}
