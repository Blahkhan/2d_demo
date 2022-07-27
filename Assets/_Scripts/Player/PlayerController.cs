using Blahkhan.Demo.GameState;
using Blahkhan.Demo.Input;
using Blahkhan.Demo.UI;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Blahkhan.Demo.Player
{
	public class PlayerController : MonoBehaviour
	{
		#region types

		public class Factory : PlaceholderFactory<PlayerController> { }

		#endregion

		#region variables

		[Inject] private InputController inputController;
		[Inject] private GameStateController gameStateController;
		[Inject] private UIController uiController;

		[Header("Components")]
		[SerializeField] private AttackEffect attackRight;
		[SerializeField] private AttackEffect attackLeft;
		[SerializeField] private SpriteRenderer spriteRenderer;
		[SerializeField] private Animator animator;
		[SerializeField] private Rigidbody2D rb;
		[Header("Variables")]
		[SerializeField] private float playerSpeed;
		[SerializeField] private float jumpForce;

		private bool isAttacking = false;
		private bool isMoving = false;
		private bool isJumping = false;
		private bool canMove = true;
		private bool canJump = false;

		private Vector2 move = Vector2.zero;

		#endregion

		#region properties

		public bool IsAttacking => isAttacking;

		#endregion

		#region unity methods

		private void OnTriggerEnter2D(Collider2D collision)
		{
			canJump = true;
			animator.SetBool("IsGrounded", true);
			animator.SetBool("IsFalling", false);
		}

		private void OnTriggerExit2D(Collider2D collision)
		{
			canJump = false;
			animator.SetBool("IsGrounded", false);
		}

		private void OnEnable()
		{
			inputController.Attack.performed += Attack;
			inputController.Jump.performed += Jump;
			inputController.Move.performed += ToggleMove;
			inputController.Move.canceled += ToggleMove;
		}

		private void OnDisable()
		{
			inputController.Attack.performed -= Attack;
			inputController.Jump.performed -= Jump;
			inputController.Move.performed += ToggleMove;
			inputController.Move.canceled += ToggleMove;
		}

		private void Update()
		{
			Movement();
			Gravity();

			rb.velocity = move;
		}

		#endregion

		#region public methods

		public IEnumerator Die()
		{
			canMove = false;
			canJump = false;
			move = Vector2.zero;
			animator.SetTrigger("Die");
			yield return new WaitForSeconds(.55f);
			gameStateController.DeletePlayer();
			uiController.ShowDiePanel();
		}

		public IEnumerator PushPlayer(float x, float y, float time)
		{
			canJump = false;
			canMove = false;
			isJumping = true;
			move.x = x;
			move.y = y;
			yield return new WaitForSeconds(time);
			move = Vector2.zero;
			canMove = true;
			isJumping = false;
		}

		#endregion

		#region private methods

		private void Attack(InputAction.CallbackContext callback)
		{
			if (isAttacking) return;

			isAttacking = true;
			animator.SetTrigger("Attack");
			if (spriteRenderer.flipX)
			{
				attackLeft.gameObject.SetActive(true);
				attackLeft.TriggerAnim();
				StartCoroutine(AttackTime(attackLeft));
			}
			else
			{
				attackRight.gameObject.SetActive(true);
				attackRight.TriggerAnim();
				StartCoroutine(AttackTime(attackRight));
			}
			
		}

		private void ToggleMove(InputAction.CallbackContext callback)
		{
			if (callback.ReadValue<Vector2>().y == 0f)
			{
				if (callback.performed)
				{
					isMoving = true;
					animator.SetFloat("Speed", 2f);
					spriteRenderer.flipX = callback.ReadValue<Vector2>().x < 0;
				}
				else
				{
					isMoving = false;
					animator.SetFloat("Speed", 0f);
				}
			}
		}

		private void Movement()
		{
			if (!canMove || isAttacking) return;

			if (isMoving)
			{
				move.x = inputController.Move.ReadValue<Vector2>().x * playerSpeed;
			}
			else
			{
				move.x = 0f;
			}
		}

		private void Gravity()
		{
			if (canJump || isJumping) return;

			move.y = -5f;
			animator.SetBool("IsFalling", true);
		}

		private void Jump(InputAction.CallbackContext callback)
		{
			if (!canJump) return;

			animator.SetTrigger("Jump");
			isJumping = true;
			move.y = jumpForce;
			StartCoroutine(JumpTime());
		}

		private IEnumerator JumpTime()
		{
			yield return new WaitForSeconds(.7f);
			isJumping = false;
		}

		private IEnumerator AttackTime(AttackEffect attackEffect)
		{
			yield return new WaitForSeconds(1f);
			isAttacking = false;
		}

		#endregion
	}
}
