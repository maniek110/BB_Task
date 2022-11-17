using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidScript : MonoBehaviour
{
    public System.Action<GameObject> OnDeath;
    public SpriteRenderer renderer;

    public void Init(Sprite p_asteroidSprite) {
        gameObject.SetActive(true);
        renderer.sprite = p_asteroidSprite;
        float spawnY = Random.Range
                (Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).y, Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y);
        float spawnX = Random.Range
            (Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x, Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x);
        transform.position= new Vector2(spawnX, spawnY);
        this.GetComponent<Rigidbody2D>().AddForce(transform.up *Random.Range(-1,1)+ transform.right * Random.Range(-1, 1));
        this.GetComponent<Rigidbody2D>().AddTorque(Random.Range(-10, 10));
    }

    internal void Dissable()
    {
        OnDeath?.Invoke(gameObject);  
        gameObject.SetActive(false);
    }
}
