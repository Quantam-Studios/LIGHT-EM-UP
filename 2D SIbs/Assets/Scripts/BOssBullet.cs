using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOssBullet : MonoBehaviour
{


    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.collider.tag == "Border")
        {
            Destroy(this.gameObject);
        }

        if (col.collider.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }
}
