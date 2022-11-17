using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToOtherSide : MonoBehaviour
{
    public GameObject OtherSideObject;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Vector2 pos = collision.gameObject.transform.position;
        if (transform.position.x == OtherSideObject.transform.position.x)
        {
            pos.y= OtherSideObject.transform.position.y;
        }

        if (transform.position.y == OtherSideObject.transform.position.y)
        {

            pos.x = OtherSideObject.transform.position.y;
        }
        collision.gameObject.transform.position = pos;
    }
}
