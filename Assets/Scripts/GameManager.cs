using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    #region Singleton

    public static GameManager Instance;


    
    public int maxAmmo = 6;
    public int currentAmmo = 3;
    

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
        currentScore = 0;
        isPlaying = false;
    }

    private void Update()
    {
        if (isPlaying == true)
        {
            currentScore += Time.deltaTime;
        }

        if(Input.GetKeyDown("j"))
        {
            isPlaying = true;
        }
    }

    public void UpdateScoreText()
    {
        
    }

    public void EnemyDefeated()
    {
        currentScore += 50;
    }

    
}
