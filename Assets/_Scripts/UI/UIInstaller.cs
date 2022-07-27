using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Blahkhan.Demo.UI
{
    public class UIInstaller : MonoInstaller
    {
        [SerializeField] private UIController uIController;

		public override void InstallBindings()
		{
			Container.Bind<UIController>().FromInstance(uIController).AsSingle();
		}
	}
}
