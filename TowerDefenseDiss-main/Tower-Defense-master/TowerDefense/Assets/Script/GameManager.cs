using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static bool GameOver;
  

    public GameObject gameOverUI;

    void Start()
    {
        GameOver = false;
    }
    void Update()
    {
        if (GameOver)
            return;

        if (PlayerStats.Lives <= 0)
        {
            EndGame();
        }
    }

    void EndGame ()
    {
        GameOver = true;
        Debug.Log("game over");

        gameOverUI.SetActive(true);
    }
}
