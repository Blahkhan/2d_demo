using Blahkhan.Demo.GameState;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Blahkhan.Demo.Hud
{
    public class HudController : MonoBehaviour
    {
		#region variables

		[Zenject.Inject] private GameStateController gameStateController;

		[SerializeField] private Text coinCounter;
		[SerializeField] private Text coinChanger;
		[SerializeField] private List<Animator> heartsList;

		#endregion

		#region public methods

		public void Heal()
		{
			switch (gameStateController.CurrentPlayerHP)
			{
				case 2:
					heartsList[0].SetTrigger("Heal");
					break;
				case 1:
					heartsList[1].SetTrigger("Heal");
					break;
			}
		}

		public void TakeDamage()
		{
			switch (gameStateController.CurrentPlayerHP)
			{
				case 3:
					heartsList[0].SetTrigger("Gone");
					break;
				case 2:
					heartsList[1].SetTrigger("Gone");
					break;
				case 1:
					heartsList[2].SetTrigger("Gone");
					break;
			}
		}

		public void UpdateCoinCounter(int value)
		{
			coinCounter.text = value.ToString();
		}

		public void TriggerCoinChanger(int value, Color color)
		{
			coinChanger.color = color;
			if (value > 0)
			{
				coinChanger.text = $"+ {value.ToString()}";
			}
			else
			{
				coinChanger.text = $"- {value.ToString()}";
			}

			StartCoroutine(HideCoinChanger());
		}

		#endregion

		#region pirvate methods

		private IEnumerator HideCoinChanger()
		{
			yield return new WaitForSeconds(1f);
			var tempColor = coinChanger.color;
			tempColor.a = 0;
			coinChanger.color = tempColor;
		}

		#endregion
	}
}
