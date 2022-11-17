using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Asteroid Config", menuName = "Configs/Asteroid Config", order = 0)]
public class AsteroidConfig : ScriptableObject
{
    public GameObject AsteroidBase;
    public List<Sprite> AsteroidGraphics;
    public AsteroidType AsteroidType;
    
}
public enum AsteroidType
{
    Small,
    Medium,
    Big
}