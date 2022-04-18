using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverScreen;
    public Text secondsSurvivedUI;

    bool gameOver;
    void Start()
    {
        FindObjectOfType<PlayerController>().OnPlayerDeath += OnGameOver;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(0);
            }
        }
    }

    void OnGameOver()
    {
        gameOverScreen.SetActive(true);

        int totalScore = Mathf.RoundToInt(Time.timeSinceLevelLoad) + Difficulty.bonusNumber;

        if (totalScore >= 1)
        {
            secondsSurvivedUI.text = "超神";
            //secondsSurvivedUI.fontSize = 100;
        }
        else
        {
            secondsSurvivedUI.text = totalScore.ToString();
        }
        gameOver = true;
        Difficulty.bonusNumber = 0;
    }
}
