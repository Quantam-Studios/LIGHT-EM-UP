using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    private Vector2 moveVelocity;
    private Transform playerPos;
    public GameObject bullet;
    public float health;
    public GameObject DeadMenu;
    public static float checker;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerPos = GetComponent<Transform>();
        health = 100;
        DeadMenu.SetActive(false);
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput.normalized * speed;

        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(bullet, playerPos.position, Quaternion.identity);
        }

        HealthBar.healthVal = health;

        if (health <= 0)
        {
            DeadMenu.SetActive(true);
            Time.timeScale = 0;
        }

        if (Score.scoreVal >= checker)
        {
            checker = Score.scoreVal;
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.tag == "Enemy")
        {
            health -= 10;
        }

        if (col.collider.tag == "EnemyBullet")
        {
            health -= 10;
        }

        if (col.collider.tag == "HealthBoost")
        {
            if (health <= 90)
            {
                health += 10;
            }
            Destroy(col.gameObject);
        }
    }
}
