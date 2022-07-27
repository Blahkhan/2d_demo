using System.Collections;
using UnityEngine;
using Blahkhan.Demo.Coin;
using Blahkhan.Demo.Heart;

namespace Blahkhan.Demo.Vase
{
	public enum VaseDrop
	{
		Coin,
		Heart,
		Random
	}

    public class VaseController : MonoBehaviour
    {
		#region variables

		[Zenject.Inject] private CoinController.Factory coinFactory;
		[Zenject.Inject] private HeartController.Factory heartFactory;

		[SerializeField] private Animator animator;
		[SerializeField] private VaseDrop vaseDrop;

		#endregion

		#region public methods

		public IEnumerator Break()
		{
			animator.SetTrigger("Gone");
			yield return new WaitForSeconds(.5f);
			switch (vaseDrop)
			{
				case VaseDrop.Coin:
					var drop1 = coinFactory.Create();
					drop1.transform.position = transform.position;
					break;
				case VaseDrop.Heart:
					var drop2 = heartFactory.Create();
					drop2.transform.position = transform.position;
					break;
				case VaseDrop.Random:
					var r = Random.Range(0, 2);
					if (r == 0)
					{
						var drop3 = heartFactory.Create();
						drop3.transform.position = transform.position;
						break;
					}
					else if (r == 1) 
					{
						var drop3 = coinFactory.Create();
						drop3.transform.position = transform.position;
						break;
					}
					break;
			}

			Destroy(gameObject);
		}

		#endregion
	}
}