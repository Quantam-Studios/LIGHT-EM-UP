using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform Player;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, Player.position, speed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.collider.tag == "Bullet")
        {
            Score.scoreVal += 100;
            Destroy(this.gameObject);
            Spawner.amountInWave -= 1;
        }

        if (col.collider.tag == "Player")
        {
            Destroy(this.gameObject);
            Spawner.amountInWave -= 1;
        }
    }
}
