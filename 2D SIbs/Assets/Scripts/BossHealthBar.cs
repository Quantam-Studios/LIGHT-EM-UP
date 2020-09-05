using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealthBar : MonoBehaviour
{
    public Slider Health;
    public static Slider EnemyHealthBar;
    public static float healthVal;

    void Start()
    {
        EnemyHealthBar = Health;
        Health.maxValue = EnemyHealthBar.maxValue;
    }

    // Update is called once per frame
    void Update()
    {
        Health.value = healthVal;
    }
}
