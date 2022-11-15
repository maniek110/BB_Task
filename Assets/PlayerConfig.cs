using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player Config", menuName = "Configs/Player Config", order = 0)]

public class PlayerConfig : ScriptableObject
{
    public GameObject Player;
    public int Health;
    public int MaxRotAngle;
}
