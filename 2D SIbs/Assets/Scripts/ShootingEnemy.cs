using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : MonoBehaviour
{
    public Transform Player;
    public float speed;
    public GameObject bullet;
    public float TimeBtwShots;
    private float ResetShotTime;
    public float Distance;
    public Vector2 dir;


    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        ResetShotTime = TimeBtwShots;
    }

    // Update is called once per frame
    void Update()
    {
        dir = transform.position - Player.position;

        TimeBtwShots -= Time.deltaTime;
        if (TimeBtwShots <= 0)
        {
            Instantiate(bullet, this.gameObject.transform.position, Quaternion.identity);
            TimeBtwShots = ResetShotTime;
        }

        if (Vector2.Distance(transform.position, Player.position) > Distance)
        {
            transform.position = Vector2.MoveTowards(transform.position, Player.position, speed * Time.deltaTime);
        }

        if (Vector2.Distance(transform.position, Player.position) < Distance - 1)
        {
           transform.Translate (dir * speed * Time.deltaTime);
        } 
    }


    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.tag == "Bullet")
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
