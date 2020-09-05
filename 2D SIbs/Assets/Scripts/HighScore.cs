using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{

    Text score;
    public float highscore;

    // Start is called before the first frame update
    void Start()
    {
        score = GetComponent<Text>();
    }
    
    // Update is called once per frame
    void Update()
    {
        highscore = Player.checker;
        score.text = "High Score: " + highscore;
    }
}
