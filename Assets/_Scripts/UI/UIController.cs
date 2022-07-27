using Blahkhan.Demo.Input;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace Blahkhan.Demo.UI
{
	public class UIController : MonoBehaviour
	{
		#region variables

		[Zenject.Inject] private InputController inputController;

		[Header("Panels")]
		[SerializeField] private GameObject pausePanel;
		[SerializeField] private GameObject diePanel;
		[Header("Buttons")]
		[SerializeField] private Button resumeButton;
		[SerializeField] private Button exitButtonPause;
		[SerializeField] private Button exitButtonDie;

		#endregion

		#region unity methods

		private void OnEnable()
		{
			inputController.Pause.performed += SwitchPausePanel;

			resumeButton.onClick.AddListener(ResumeGame);
			exitButtonPause.onClick.AddListener(ExitGame);
			exitButtonDie.onClick.AddListener(ExitGame);
		}

		private void OnDisable()
		{
			inputController.Pause.performed -= SwitchPausePanel;

			resumeButton.onClick.RemoveListener(ResumeGame);
			exitButtonPause.onClick.RemoveListener(ExitGame);
			exitButtonDie.onClick.RemoveListener(ExitGame);
		}

		#endregion

		#region public methods

		public void ShowPausePanel()
		{
			pausePanel.SetActive(true);
			Time.timeScale = 0f;
		}

		public void ShowDiePanel()
		{
			diePanel.SetActive(true);
			Time.timeScale = 0f;
		}

		#endregion

		#region private methods

		private void SwitchPausePanel(InputAction.CallbackContext callback)
		{
			if (pausePanel.activeSelf)
			{
				ResumeGame();
			}
			else
			{
				ShowPausePanel();
			}
		}

		private void ResumeGame()
		{
			Time.timeScale = 1f;
			pausePanel.SetActive(false);
		}

		private void ExitGame()
		{
			Application.Quit();
		}

		#endregion
	}
}
