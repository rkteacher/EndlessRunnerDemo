using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{

    //this class is a singleton. That means there is only one and it talks to many other classes. Other classes also talk to it. 
    #region Singleton
    // This #region creates a organized section of the code that can be collapsed
    public static GameManager Instance;

    [SerializeField] private UIManager uiManager;

    
    public int maxAmmo = 6;
    public int currentAmmo = 3;
    

    // this makes sure there are no duplicates of this class and makes it easy to access it from other scripts.
    private void Awake()
    {
        if (Instance == null) Instance = this;
    }


    #endregion

    public float currentScore = 0f;

    public bool isPlaying = false;

    
    
    public string ScoreDisplay()
    {
        return Mathf.RoundToInt(currentScore).ToString();
    }

    
    public void GameOver()
    {
        uiManager.GameOver();
        isPlaying = false;
    }

    public void GameStart()
    {
        uiManager.StartGame();
        currentScore = 0;
        isPlaying = true;
    }


    private void Update()
    {
        if (isPlaying == true)
        {
            //sets the score to the time played.
            currentScore += Time.deltaTime;
        }

        if(Input.GetKeyDown("j"))
        {
            //turns the game on. This is prototype programming. 
            //TODO create a menu with a button for this later
            isPlaying = true;
        }
    }

    public void EnemyDefeated()
    {
        currentScore += 20;
    }

    
    
}
