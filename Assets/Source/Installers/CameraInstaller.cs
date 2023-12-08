using UnityEngine;
using Zenject;

public class CameraInstaller : MonoInstaller
{
    [SerializeField] private Camera playerCamera;

    public override void InstallBindings()
    {
        Container.Bind<Camera>().FromInstance(playerCamera).AsSingle();
    }
}