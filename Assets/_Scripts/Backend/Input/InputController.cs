using UnityEngine;
using UnityEngine.InputSystem;

namespace Blahkhan.Demo.Input
{
	public class InputController : MonoBehaviour
	{
		[SerializeField] private InputActionAsset inputAction;

		public InputActionAsset InputAction => inputAction;
		public InputAction Move => inputAction.actionMaps[0].actions[0];
		public InputAction Jump => inputAction.actionMaps[0].actions[3];
		public InputAction Attack => inputAction.actionMaps[0].actions[4];
		public InputAction Pause => inputAction.actionMaps[0].actions[5];
	}
}
