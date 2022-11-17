using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public int InitAmountOfAsteroids = 6;
    public List<AsteroidConfig> AsteroidConfigs;
    Dictionary<GameObject, AsteroidType> AsteroisList=new Dictionary<GameObject, AsteroidType>();
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < InitAmountOfAsteroids; i++)
        {
            AsteroidConfig config = AsteroidConfigs[Random.Range(0, AsteroidConfigs.Count-1)];
            GameObject gameObject = Instantiate(config.AsteroidBase);
            gameObject.GetComponent<AsteroidScript>().Init(config.AsteroidGraphics[Random.Range(0, config.AsteroidGraphics.Count-1)]);
            gameObject.GetComponent<AsteroidScript>().OnDeath += Respawn;
            AsteroisList.Add(gameObject, config.AsteroidType);
        }    
    }

    private void Respawn(GameObject obj)
    {
        Debug.Log(obj);
        AsteroidConfig config = AsteroidConfigs.Find(x => x.AsteroidType == AsteroisList[obj]);
        obj.GetComponent<AsteroidScript>().Init(config.AsteroidGraphics[Random.Range(0, config.AsteroidGraphics.Count-1)]);
        obj.SetActive(true);
    }
}
