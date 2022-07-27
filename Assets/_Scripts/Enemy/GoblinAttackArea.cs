using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Blahkhan.Demo.Enemy
{
    public class GoblinAttackArea : MonoBehaviour
    {
		#region variable
		
		[SerializeField] private GoblinController goblinController;
		[SerializeField] private SpriteRenderer sr;
		[SerializeField] private bool isLeftSide;

		#endregion

		#region unity methods

		private void OnTriggerEnter2D(Collider2D collision)
		{
			if (collision.transform.tag != "Player") return;
			if (goblinController.IsAttacking) return;

			sr.flipX = isLeftSide;
			StartCoroutine(goblinController.Attack());
		}

		#endregion
	}
}
