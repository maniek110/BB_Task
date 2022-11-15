using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
    public GameObject PlayerObject;
    public override void InstallBindings()
    {
        Container.Bind<PlayerController>().AsSingle().WithArguments(PlayerObject).NonLazy();
    }

}
