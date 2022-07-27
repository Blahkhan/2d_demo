using System.Collections.Generic;
using UnityEngine;

namespace Blahkhan.Demo.Enemy
{
	public class EnemyManager : MonoBehaviour
	{
		#region variables

		[SerializeField] private List<EnemyController> enemiesList = new List<EnemyController>();

		#endregion

		#region properties

		public List<EnemyController> EnemiesList => enemiesList;

		#endregion

		#region unity methods

		private void Update()
		{
			foreach(var enemy in enemiesList)
			{
				enemy.Loop();
			}
		}

		#endregion
	}
}
