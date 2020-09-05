using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public Transform Player;
    public float speed;
    public float TimeBtwShots;
    private float ResetShotTime;
    public float Distance;
    public Vector2 dir;
    public float health;
    private GameObject HealthBar;
    public float shotCount;
    public GameObject HealthBoost;
    public float BoostCount;

    [SerializeField]
    int numberOfProjectiles;

    [SerializeField]
    GameObject projectile;

    Vector2 startPoint;

    public float radius, moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        shotCount = 0;
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        HealthBar = GameObject.FindGameObjectWithTag("BossHealth");
        ResetShotTime = TimeBtwShots;
        BossHealthBar.healthVal = health;
        BossHealthBar.EnemyHealthBar.maxValue = health;
    }

    void SpawnProjectiles(int numberOfProjectiles)
    {
        float angleStep = 360f / numberOfProjectiles;
        float angle = 0f;

        for (int i = 0; i <= numberOfProjectiles - 1; i++)
        {

            float projectileDirXposition = startPoint.x + Mathf.Sin((angle * Mathf.PI) / 180) * radius;
            float projectileDirYposition = startPoint.y + Mathf.Cos((angle * Mathf.PI) / 180) * radius;

            Vector2 projectileVector = new Vector2(projectileDirXposition, projectileDirYposition);
            Vector2 projectileMoveDirection = (projectileVector - startPoint).normalized * moveSpeed;

            var proj = Instantiate(projectile, startPoint, Quaternion.identity);
            proj.GetComponent<Rigidbody2D>().velocity =
                new Vector2(projectileMoveDirection.x, projectileMoveDirection.y);

            angle += angleStep;
        }
    }

    // Update is called once per frame
    void Update()
    {
        BossHealthBar.healthVal = health;
        dir = transform.position - Player.position;

        startPoint = this.gameObject.transform.position;

        TimeBtwShots -= Time.deltaTime;
        if (TimeBtwShots <= 0)
        {
            SpawnProjectiles(numberOfProjectiles);
            TimeBtwShots = ResetShotTime;
            shotCount += 1;
        }

        if (shotCount%2 == 0)
        {
            numberOfProjectiles = 11;
        }

        if (shotCount % 2 == 1)
        {
            numberOfProjectiles = 9;
        }

        if (Vector2.Distance(transform.position, Player.position) > Distance)
        {
            transform.position = Vector2.MoveTowards(transform.position, Player.position, speed * Time.deltaTime);
        }

        if (Vector2.Distance(transform.position, Player.position) < Distance - 1)
        {
            transform.Translate(dir * speed * Time.deltaTime);
        }

        if (health <= 0)
        {
            Destroy(this.gameObject);
            HealthBar.SetActive(false);
            Spawner.BossSpawned = false;
            Spawner.wave += 1;
            Spawner.newWave = true;
            Score.scoreVal += 10000;
            for (int i = 0; BoostCount >= i; i++)
            {
                int X = Random.Range(-9, 10);
                int Y = Random.Range(-2, 3);
                int Z = 0;
                Instantiate(HealthBoost, new Vector3(X, Y, Z), Quaternion.identity);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.tag == "Bullet")
        {
            health -= 10;
        }

        if (col.collider.tag == "Player")
        {
            health -= 10;
        }
    }
}
