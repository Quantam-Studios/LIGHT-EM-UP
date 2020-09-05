using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashingEnemy : MonoBehaviour
{
    public int speed;
    private Transform player;
    public float Distance;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, player.position) < Distance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, (speed) * Time.deltaTime);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, (speed / 2) * Time.deltaTime);
        }

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.tag == "Player")
        {
            Destroy(this.gameObject);
            Spawner.amountInWave -= 1;
        }

        if (col.collider.tag == "Bullet")
        {
            Score.scoreVal += 100;
            Destroy(this.gameObject);
            Spawner.amountInWave -= 1;
        }
    }
}
