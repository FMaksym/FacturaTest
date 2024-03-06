using UnityEngine;
using Zenject;

public class CameraInstaller : MonoInstaller
{
    [SerializeField] private Camera _playerCamera;

    public override void InstallBindings()
    {
        Container.Bind<Camera>().FromInstance(_playerCamera).AsSingle();
    }
}