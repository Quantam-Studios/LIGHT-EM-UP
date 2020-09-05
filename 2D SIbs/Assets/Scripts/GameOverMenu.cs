using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public float scoreNum;
    public Text score;

    //Retry function
    public void Retry()
    {
        SceneManager.LoadScene(1);
    }

    // Update is called once per frame
    void Update()
    {
        //sets end score
        scoreNum = Score.scoreVal;
        score.text = "Score: " + scoreNum;
    }

    //Goes to main menu
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
    
   

    
}   
