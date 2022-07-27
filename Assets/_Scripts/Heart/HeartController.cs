using Blahkhan.Demo.GameState;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Blahkhan.Demo.Heart
{
    public class HeartController : MonoBehaviour
    {
		#region types

		public class Factory : PlaceholderFactory<HeartController> { }

		#endregion

		#region variables

		[Inject] private GameStateController stateController;

		#endregion

		#region unity methods

		private void OnTriggerEnter2D(Collider2D collision)
		{
			if (collision.tag != "Player") return;
			if (stateController.CurrentPlayerHP >= 3) return;

			Destroy(gameObject);
		}

		private void OnDestroy()
		{
			stateController.Heal();
		}

		#endregion
	}
}
