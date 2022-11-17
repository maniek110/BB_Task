using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToSafeSpotOnHit : MonoBehaviour
{
    public Action OnHit;
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Asteroid")
        {
            OnHit?.Invoke();
        }
    }
}
