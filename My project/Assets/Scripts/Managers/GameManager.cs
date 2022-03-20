/**** 
 * Created by: Akram Taghavi-Burrs
 * Date Created: Feb 23, 2022
 * 
 * Last Edited by: Ben Jenkins
 * Last Edited: Feb 23, 2022
 * 
 * Description: Basic GameManager Template
****/

/** Import Libraries **/
using System; //C# library for system properties
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //libraries for accessing scenes


public class GameManager : MonoBehaviour
{
    /*** VARIABLES ***/

    #region GameManager Singleton
    static private GameManager gm; //refence GameManager
    static public GameManager GM { get { return gm; } } //public access to read only gm 

    //Check to make sure only one gm of the GameManager is in the scene
    void CheckGameManagerIsInScene()
    {
    
        //Check if instnace is null
        if (gm == null)
        {
           gm = this; //set gm to this gm of the game object
            Debug.Log(gm);
        }
        else //else if gm is not null a Game Manager must already exsist
        {
            Destroy(this.gameObject); //In this case you need to delete this gm
        }
        DontDestroyOnLoad(this); //Do not delete the GameManager when scenes load
        Debug.Log(gm);
    }//end CheckGameManagerIsInScene()
    #endregion

    [Header("GENERAL SETTINGS")]
    public string gameTitle = "Untitled Game";  //name of the game
    public string gameCredits = "Made by Me"; //game creator(s)
    public string copyrightDate = "Copyright " + thisDay; //date cretaed

    [Header("GAME SETTINGS")]

    [Tooltip("Will the high score be recoreded")]
    public bool recordHighScore = false; //is the High Score recorded

    [SerializeField] //Access to private variables in editor
    private int defaultHighScore = 1000;
    static public int highScore = 1000; // the default High Score
    public int HighScore { get { return highScore; } set { highScore = value; } }//access to private variable highScore [get/set methods]

    [Space(10)]
    
    //static vairables can not be updated in the inspector, however private serialized fileds can be
    [SerializeField] //Access to private variables in editor
    private int numberOfLives; //set number of lives in the inspector
    static public int lives; // number of lives for player 
    public int Lives { get { return lives; } set { lives = value; } }//access to private variable died [get/set methods]

    static public int score;  //score value
    public int Score { get { return score; } set { score = value; } }//access to private variable died [get/set methods]

    [SerializeField] //Access to private variables in editor
    [Tooltip("Check to test player lost the level")]
    private bool levelLost = false;//we have lost the level (ie. player died)
    public bool LevelLost { get { return levelLost; } set { levelLost = value; } } //access to private variable lostLevel [get/set methods]

    [Space(10)]
    public string defaultEndMessage = "Game Over";//the end screen message, depends on winning outcome
    public string looseMessage = "You Loose"; //Message if player looses
    public string winMessage = "You Win"; //Message if player wins
    [HideInInspector] public string endMsg ;//the end screen message, depends on winning outcome

    [Header("SCENE SETTINGS")]
    [Tooltip("Name of the start scene")]
    public string startScene;
    
    [Tooltip("Name of the game over scene")]
    public string gameOverScene;
    
    [Tooltip("Count and name of each Game Level (scene)")]
    public string[] gameLevels; //names of levels
    [HideInInspector]
    public int gameLevelsCount; //what level we are on
    private int loadLevel; //what level from the array to load
     
    public static string currentSceneName; //the current scene name;

    [Header("FOR TESTING")]
    public bool nextLevel = false; //test for next level

    //Game State Varaiables
    [HideInInspector] public enum gameStates { Idle, Playing, Death, GameOver, BeatLevel };//enum of game states
    [HideInInspector] public gameStates gameState = gameStates.Idle;//current game state

    //Timer Varaibles
    private float currentTime; //sets current time for timer
    private bool gameStarted = false; //test if games has started

    //Win/Lose conditon
    [SerializeField] //to test in inspector
    private bool playerWon = false;

    [HideInInspector] public GameObject cubeSlotHolder;
    [HideInInspector] public List<List<GameObject>> allSlots;
    public GameObject cubeSlotprefab;

    [HideInInspector] private Vector3 topCameraPos = new Vector3(2f, 10f, 2.5f);
    [HideInInspector] private Quaternion topCameraRot = Quaternion.Euler(90f, 0, 0);
    [HideInInspector] private Vector3 frontCameraPos = new Vector3(2.175f,2f,-9f);
    [HideInInspector] private Quaternion frontCameraRot = Quaternion.Euler(0,0,0);
    [HideInInspector] private Vector3 sideCameraPos = new Vector3(14f,2f,2.175f);
    [HideInInspector] private Quaternion sideCameraRot = Quaternion.Euler(0,270f,0);
    public static GameObject spawnpoint;

    [HideInInspector] private List<List<string>> solution1;
    [HideInInspector] private List<List<string>> solution2;
    [HideInInspector] private List<List<string>> currentBoard;

    [HideInInspector] private static GameObject camera;
 
   //reference to system time
   private static string thisDay = System.DateTime.Now.ToString("yyyy"); //today's date as string


    /*** MEHTODS ***/
   
   //Awake is called when the game loads (before Start).  Awake only once during the lifetime of the script instance.
    void Awake()
    {
        //runs the method to check for the GameManager
        CheckGameManagerIsInScene();

        camera = GameObject.Find("Main Camera");
        //store the current scene
        currentSceneName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
        
        //Get the saved high score
        GetHighScore();

        cubeSlotHolder = GameObject.Find("CubeSlotHolder");
        
        

    }//end Awake()


    // Update is called once per frame
    private void Update()
    {
        //if ESC is pressed , exit game
        if (Input.GetKey("escape")) { ExitGame(); }
        
        //Check for next level
        if (nextLevel) { NextLevel(); }

        //if we are playing the game
        if (gameState == gameStates.Playing)
        {
            //if we have died and have no more lives, go to game over
            if (levelLost && (lives == 0)) { GameOver(); }

        }//end if (gameState == gameStates.Playing)

        //Check Score
        CheckScore();

    }//end Update

    public void SetOpaque()
    {
        CubeSlot.currentCube = "opaque";
    }
    public void SetTransparent()
    {
        CubeSlot.currentCube = "transparent";
    }
    public void CamTop()
    {
        camera.transform.position = topCameraPos;
        camera.transform.rotation = topCameraRot;
    }
    public void CamFront()
    {
        camera.transform.position = frontCameraPos;
        camera.transform.rotation = frontCameraRot;
    }
    public void CamSide()
    {
        camera.transform.position = sideCameraPos;
        camera.transform.rotation = sideCameraRot;
    }


    //LOAD THE GAME FOR THE FIRST TIME OR RESTART
   public void StartGame()
    {
        //SET ALL GAME LEVEL VARIABLES FOR START OF GAME

        gameLevelsCount = 1; //set the count for the game levels
        loadLevel = gameLevelsCount - 1; //the level from the array
        SceneManager.LoadScene(gameLevels[loadLevel]); //load first game level

        gameState = gameStates.Playing; //set the game state to playing

        lives = numberOfLives; //set the number of lives
        score = 0; //set starting score

        //set High Score
        if (recordHighScore) //if we are recording highscore
        {
            //if the high score, is less than the default high score
            if (highScore <= defaultHighScore)
            {
                highScore = defaultHighScore; //set the high score to defulat
                PlayerPrefs.SetInt("HighScore", highScore); //update high score PlayerPref
            }//end if (highScore <= defaultHighScore)
        }//end  if (recordHighScore) 

        endMsg = defaultEndMessage; //set the end message default

        playerWon = false; //set player winning condition to false
        SpawnSlots();
        solution1 = new List<List<string>>(Solutions.solution1);
        solution2 = new List<List<string>>(Solutions.solution2);
    }//end StartGame()

    public void SpawnSlots()
    {
        allSlots = new List<List<GameObject>>();
        float separatorx = 0.25f;
        for(int i=0; i < 4; i++)
        {
            float separatorz = 0.25f;
            List<GameObject> subSlots = new List<GameObject>();
            for(int j = 0; j < 4; j++)
            {
                GameObject currentCubeSlot = Instantiate(cubeSlotprefab) as GameObject;
                currentCubeSlot.transform.position = new Vector3(i+separatorx, 0, j+separatorz);
                subSlots.Add(currentCubeSlot);
                separatorz += 0.25f;
            }
            separatorx += 0.25f;
            allSlots.Add(subSlots);
        }
    }

    public void CheckSolution()
    {
        bool checkers = true;
        createCurrentBoard();
        Debug.Log(solution1[1][1]);
        Debug.Log(solution1[1][1] + " and " + currentBoard[1][1]);
        if (gameLevelsCount == 0)
        {
            for(int i = 0; i < 16; i++)
            {
                for(int j = 0; j < 4; j++)
                {
                    Debug.Log(solution1[i][j] + " and " + currentBoard[i][j]);
                    if (solution1[i][j].Equals(currentBoard[i][j]))
                    {
                        checkers = false;
                    }
                    Debug.Log(solution1[i][j]+" and "+currentBoard[i][j]);
                }
            }
        }
        else if (gameLevelsCount == 1)
        {
            for (int i = 0; i < 16; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (solution2[i][j] != currentBoard[i][j])
                    {
                        checkers = false;
                    }
                }
            }
        }
        else
        {
            checkers = false;
        }

        if (checkers)
        {
            Debug.Log("Correct");
        }
        if (!checkers)
        {
            Debug.Log("Incorrect");
        }
    }

    private void createCurrentBoard()
    {
        currentBoard = new List<List<string>>();
        List<string> currentBoardrow = new List<string>();
        foreach(List<GameObject> cubeSlots in allSlots)
        {
            currentBoardrow = new List<string>();
            for(int i = 0; i < 4; i++)
            {
                currentBoardrow.Add(cubeSlots[i].GetComponent<CubeSlot>().getFirst());
                currentBoardrow.Add(cubeSlots[i].GetComponent<CubeSlot>().getSecond());
                currentBoardrow.Add(cubeSlots[i].GetComponent<CubeSlot>().getThird());
                currentBoardrow.Add(cubeSlots[i].GetComponent<CubeSlot>().getFourth());
            }
            currentBoard.Add(currentBoardrow);
        }
    }
    //EXIT THE GAME
    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Exited Game");
    }//end ExitGame()


    //GO TO THE GAME OVER SCENE
    public void GameOver()
    {
        gameState = gameStates.GameOver; //set the game state to gameOver

       if(playerWon) { endMsg = winMessage; } else { endMsg = looseMessage; } //set the end message

        SceneManager.LoadScene(gameOverScene); //load the game over scene
        Debug.Log("Gameover");
    }
    
    
    //GO TO THE NEXT LEVEL
        void NextLevel()
    {
        nextLevel = false; //reset the next level

        //as long as our level count is not more than the amount of levels
        if (gameLevelsCount < gameLevels.Length)
        {
            gameLevelsCount++; //add to level count for next level
            loadLevel = gameLevelsCount - 1; //find the next level in the array
            SceneManager.LoadScene(gameLevels[loadLevel]); //load next level

        }else{ //if we have run out of levels go to game over
            GameOver();
        } //end if (gameLevelsCount <=  gameLevels.Length)
        SpawnSlots();
    }//end NextLevel()

    void CheckScore()
    { //This method manages the score on update. Right now it just checks if we are greater than the high score.
  
        //if the score is more than the high score
        if (score > highScore)
        { 
            highScore = score; //set the high score to the current score
           PlayerPrefs.SetInt("HighScore", highScore); //set the playerPref for the high score
        }//end if(score > highScore)

    }//end CheckScore()

    void GetHighScore()
    {//Get the saved highscore
 
        //if the PlayerPref alredy exists for the high score
        if (PlayerPrefs.HasKey("HighScore"))
        {
            Debug.Log("Has Key");
            highScore = PlayerPrefs.GetInt("HighScore"); //set the high score to the saved high score
        }//end if (PlayerPrefs.HasKey("HighScore"))

        PlayerPrefs.SetInt("HighScore", highScore); //set the playerPref for the high score
    }//end GetHighScore()


}
