/**** 
 * Created by: Akram Taghavi-Burrs
 * Date Created: Feb 23, 2022
 * 
 * Last Edited by: NA
 * Last Edited: Feb 23, 2022
 * 
 * Description: Updates HUD canvas referecing game manager
****/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDCanvas : MonoBehaviour
{
    /*** VARIABLES ***/

    GameManager gm; //reference to game manager

    [Header("Canvas SETTINGS")]
    public Text levelTextbox; //textbox for level count
    public Text livesTextbox; //textbox for the lives
    public Text scoreTextbox; //textbox for the score
    public Text highScoreTextbox; //textbox for highscore
    public Text currentText;
    
    //GM Data
    private int level;
    private int totalLevels;
    private int lives;
    private int score;
    private int highscore;

    private void Start()
    {
        gm = GameManager.GM; //find the game manager

        //reference to levle info
        level = gm.gameLevelsCount;
        totalLevels = gm.gameLevels.Length;
        gm.SpawnSlots();


        SetHUD();
    }//end Start

    // Update is called once per frame
    void Update()
    {
        GetGameStats();
        SetHUD();
        currentText.text = "Current Cube Selected: " + CubeSlot.currentCube;

    }//end Update()

    void GetGameStats()
    {
        lives = gm.Lives;
        score = gm.Score;
        highscore = gm.HighScore;
    }

    void SetHUD()
    {
        //if texbox exsists update value
        if (levelTextbox) { levelTextbox.text = "Level " + level + "/" + totalLevels; }
        if (livesTextbox) { livesTextbox.text = "Lives " + lives; }
        if (scoreTextbox) { scoreTextbox.text = "Score " + score; }
        if (highScoreTextbox) { highScoreTextbox.text = "High Score " + highscore; }

    }//end SetHUD()

    public void setTransparent()
    {
        gm.SetTransparent();
    }
    public void setOpaque()
    {
        gm.SetOpaque();
    }
    public void CamTop()
    {
        gm.CamTop();
    }
    public void CamFront()
    {
        gm.CamFront();
    }
    public void CamSide()
    {
        gm.CamSide();
    }
    public void checkSolution()
    {
        gm.CheckSolution();
    }
}
