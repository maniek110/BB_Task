using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
    public PlayerConfig PlayerConfig;
    public Transform StartingPosition;
    public override void InstallBindings()
    {
        Container.Bind<PlayerController>().AsSingle().WithArguments(PlayerConfig,StartingPosition).NonLazy();
    }

}
