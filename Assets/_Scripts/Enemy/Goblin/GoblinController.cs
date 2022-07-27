using System.Collections;
using UnityEngine;

namespace Blahkhan.Demo.Enemy
{
	public class GoblinController : EnemyController
	{
		#region properties

		public bool IsAttacking { get; set; }

		#endregion

		#region public methods

		public IEnumerator Attack()
		{
			IsAttacking = true;
			canMove = false;
			animator.speed = 1f;
			animator.SetTrigger("Attack");
			yield return new WaitForSeconds(.7f);
			gameStateController.TakeDamage();
			if (sr.flipX)
			{
				StartCoroutine(gameStateController.PlayerController.PushPlayer(-5f, 1f, 0.4f));
			}
			else
			{
				StartCoroutine(gameStateController.PlayerController.PushPlayer(5f, 1f, 0.4f));
			}

			yield return new WaitForSeconds(.4f);
			canMove = true;
			IsAttacking = false;
		}

		#endregion

		#region protected methods

		protected override void Setup()
		{
			maxHP = gameStateSettings.MaxGoblinHP;
			currenthp = maxHP;
		}

		#endregion
	}
}
