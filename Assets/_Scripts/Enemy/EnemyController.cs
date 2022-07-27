using Blahkhan.Demo.GameState;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Blahkhan.Demo.Enemy
{
    public abstract class EnemyController : MonoBehaviour
    {
		#region variables

		[Zenject.Inject] protected EnemyManager enemyManager;
		[Zenject.Inject] protected GameStateSettings gameStateSettings;
		[Zenject.Inject] protected GameStateController gameStateController;

		[Header("Components")]
		[SerializeField] protected Rigidbody2D rb;
		[SerializeField] protected SpriteRenderer sr;
		[SerializeField] protected Animator animator;
		[Header("Variables")]
		[SerializeField] protected float speed;
		[SerializeField] protected List<Transform> points = new List<Transform>();

		protected int maxHP;
		protected int currenthp;
		protected int pathIndex = 0;
		protected bool canMove = true;

		#endregion

		#region unity methods

		private void Start()
		{
			Setup();
		}

		private void OnCollisionEnter2D(Collision2D collision)
		{
			CollisionAttack(collision);
		}

		#endregion

		#region public methods

		public void TakeDamage()
		{
			currenthp -= 1;

			if (currenthp <= 0)
			{
				StartCoroutine(DieAnim());
			}
		}

		public void Loop()
		{
			ProccesPath();
		}

		#endregion

		#region protected methods

		protected abstract void Setup();

		protected void ProccesPath()
		{
			if (!canMove) return;

			if (points.Count == 0)
			{
				animator.speed = 0f;
				return;
			}

			var step = speed * Time.deltaTime;
			transform.position = Vector3.MoveTowards(transform.position, new Vector2(points[pathIndex].position.x, transform.position.y), step);
			sr.flipX = transform.position.x > points[pathIndex].position.x;
			if (transform.position.x == points[pathIndex].position.x)
			{
				if (pathIndex == points.Count - 1)
				{
					pathIndex = 0;
				}
				else
				{
					pathIndex++;
				}
			}
		}

		protected void CollisionAttack(Collision2D collision)
		{
			if (collision.collider.tag != "Player") return;

			gameStateController.TakeDamage();
			if (sr.flipX)
			{
				if (gameStateController.PlayerController.IsAttacking) return;
				StartCoroutine(gameStateController.PlayerController.PushPlayer(-5f, 1f, 0.4f));
			}
			else
			{
				if (gameStateController.PlayerController.IsAttacking) return;
				StartCoroutine(gameStateController.PlayerController.PushPlayer(5f, 1f, 0.4f));
			}
		}

		#endregion

		#region private methods
		private IEnumerator DieAnim()
		{
			canMove = false;
			animator.speed = 1f;
			animator.SetTrigger("Die");
			yield return new WaitForSeconds(.55f);
			enemyManager.EnemiesList.Remove(this);
			Destroy(gameObject);
		}

		#endregion
	}
}
