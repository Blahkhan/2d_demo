using UnityEngine;

namespace Blahkhan.Demo.Enemy
{
	public class MushroomController : EnemyController
	{
		#region protected methods

		protected override void Setup()
		{
			maxHP = gameStateSettings.MaxMushroomHP;
			currenthp = maxHP;
		}

		#endregion
	}
}
