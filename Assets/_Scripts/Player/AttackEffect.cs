using Blahkhan.Demo.Enemy;
using Blahkhan.Demo.Vase;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Blahkhan.Demo.Player
{
    public class AttackEffect : MonoBehaviour
    {
		#region variables

		[SerializeField] private Animator animator;

		#endregion

		#region unity methods

		private void OnTriggerEnter2D(Collider2D collision)
		{
			if (collision.transform.tag == "Enemy")
			{
				StartCoroutine(DamageEnemy(collision.gameObject.GetComponent<EnemyController>()));
			}
			else if (collision.transform.tag == "Vase")
			{
				StartCoroutine(collision.GetComponent<VaseController>().Break());
			}
		}

		#endregion

		#region public methods

		public void TriggerAnim()
		{
			animator.SetTrigger("Attack");
			StartCoroutine(EndAnim());
		}

		#endregion

		#region private methods

		private IEnumerator DamageEnemy(EnemyController enemy)
		{
			yield return new WaitForSeconds(.5f);
			enemy.TakeDamage();
		}

		private IEnumerator EndAnim()
		{
			yield return new WaitForSeconds(1f); 
			gameObject.SetActive(false);
		}

		#endregion
	}
}
