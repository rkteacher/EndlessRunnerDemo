using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreDisplay;
    [SerializeField] private TextMeshProUGUI ammoDisplay;

    GameManager gameManager;

   
    [SerializeField] private GameObject buttonStartGame;
    [SerializeField] private GameObject buttonLoseText;
    private void Start()
    {
        gameManager = GameManager.Instance;
    }

    private void OnGUI()
    {
        scoreDisplay.text = gameManager.ScoreDisplay();
        ammoDisplay.text = gameManager.currentAmmo.ToString();
    }


    public void StartGame()
    {
        buttonLoseText.gameObject.SetActive(false);
        buttonStartGame.gameObject.SetActive(false);
    }

    public void GameOver()
    {
        buttonLoseText.gameObject.SetActive(true);
        buttonStartGame.gameObject.SetActive(true);
    }
}
