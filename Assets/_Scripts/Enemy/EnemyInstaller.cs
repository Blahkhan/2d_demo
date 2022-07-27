using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Blahkhan.Demo.Enemy
{
    public class EnemyInstaller : MonoInstaller
    {
        [SerializeField] private EnemyManager enemyManager;

        public override void InstallBindings()
		{
            Container.Bind<EnemyManager>().FromInstance(enemyManager).AsSingle();
		}
    }
}
