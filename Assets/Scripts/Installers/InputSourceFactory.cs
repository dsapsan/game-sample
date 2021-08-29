using GameSample.Core;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Installers
{
    public class InputSourceFactory : MonoInstaller
    {
        [SerializeField] private int mPoolSize;
        [SerializeField] private InputSource mInputSource;

        public override void InstallBindings()
        {
            Container.BindFactory<InputSource, InputSource.Factory>()
                .FromMonoPoolableMemoryPool<InputSource>(opts => opts
                    .WithInitialSize(mPoolSize)
                    .FromComponentInNewPrefab(mInputSource)
                    .UnderTransform(transform));
        }
    }
}