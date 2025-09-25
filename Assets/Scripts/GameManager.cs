using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private int timeToEnd;

    private bool isGamePaused = false;
    bool endGame = false;
    bool win = false;
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        if (timeToEnd <= 0)
        {
            timeToEnd = 60;
        }

        InvokeRepeating("Stopper", 2, 1);
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.P))
        { 
            if(!isGamePaused)
            {
                PauseGame();
            }
            else
            {
                ResumeGame();
            }
        
        }
        
    }
    public void EndGame()
    {
        CancelInvoke("Stopper");
        if (win)
            Debug.Log("Game is over but you won");
        else
            Debug.Log("Game Over");

        Time.timeScale = 0;
    }

    void Stopper()
    {
        timeToEnd--;
        Debug.Log(timeToEnd + "s til the end");

        if (timeToEnd <= 0)
        {
            timeToEnd = 0;
                endGame = true;
        }
        if (endGame)
            EndGame();
    }
    
    public void PauseGame()
    {
        isGamePaused = true;
        Time.timeScale = 0;
        Debug.Log("Game paused");
    }
    public void ResumeGame()
    {
        isGamePaused = false;
        Time.timeScale = 1;
        Debug.Log("Game resumed"); 
    }


}
