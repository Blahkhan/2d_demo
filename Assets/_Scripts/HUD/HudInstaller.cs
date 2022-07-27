using UnityEngine;
using Zenject;

namespace Blahkhan.Demo.Hud
{
    public class HudInstaller : MonoInstaller
    {
        [SerializeField] private HudController hudController;

        public override void InstallBindings()
        {
            Container.Bind<HudController>().FromInstance(hudController).AsSingle();
        }
    }
}
