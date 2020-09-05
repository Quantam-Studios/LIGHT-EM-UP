using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    public Transform[] spawnSpots;
    public float TimeBtwSpawns;
    public float timer;
    public GameObject[] enemy;
    public static float wave;
    public static float amountInWave;
    public float Added;
    public float Goal;
    public static bool newWave;
    public Text waveText;
    public GameObject textObj;
    public float timer2;
    public GameObject HealthBoost;

    // Boss stuff
    public GameObject Boss;
    public float BossWave;
    public static bool BossSpawned;
    public GameObject bosshealthbar;

    void Start()
    {
        wave = 1;
        amountInWave = Added;
        Goal = amountInWave;
        newWave = true;
        timer2 = 3;
        BossSpawned = false;
        bosshealthbar.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        waveText.text = "Wave " + wave;

        if (newWave == true)
        {
            textObj.SetActive(true);
            timer2 -= Time.deltaTime;
            if (timer2 <= 0)
            {
                newWave = false;
                timer2 = 3;
            }
        }

        if (amountInWave == 0)
        {
            wave += 1;
            amountInWave = (Goal + Added);
            Goal = amountInWave;
            int X = Random.Range(-9, 10);
            int Y = Random.Range(-2, 3);
            int Z = 0;
            Instantiate(HealthBoost, new Vector3(X, Y, Z), Quaternion.identity);
            newWave = true;
        }


        if (newWave == false && BossSpawned == false)
        {
            textObj.SetActive(false);
            for (int i = 0; Goal > i; i++)
            {
                if (timer >= TimeBtwSpawns)
                {
                    int randPos = Random.Range(0, spawnSpots.Length);
                    int randEnemy = Random.Range(0, enemy.Length);
                    Instantiate(enemy[randEnemy], spawnSpots[randPos].position, Quaternion.identity);
                    timer = 0;
                }
            }
        }

        if (wave == BossWave && BossSpawned == false)
        {
            BossSpawned = true;
            bosshealthbar.SetActive(true);
            int randPos = Random.Range(0, spawnSpots.Length);
            Instantiate(Boss, spawnSpots[randPos].position, Quaternion.identity);
        }

        timer += Time.deltaTime;
    }
}
