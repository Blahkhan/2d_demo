using UnityEngine;
using Zenject;

namespace Blahkhan.Demo.Input
{
    public class InputInstaller : MonoInstaller
    {
        [SerializeField] private InputController inputController;

        public override void InstallBindings()
		{
           Container.Bind<InputController>().FromInstance(inputController).AsSingle();
        }
    }
}
