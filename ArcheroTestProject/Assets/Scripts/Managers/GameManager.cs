using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameStates
{
    MainMenu,
    InGame,
    InGame_Dead,
    PauseScreen,
}

public class GameManager : MonoBehaviour
{
    protected static GameManager manager;
    public static GameManager Manager { get => manager; }

    protected bool isPaused = false;

    protected GameStates gameState;
    public GameStates GameState { get => gameState; }

    protected GameStates previousGameState;

    protected void Awake()
    {
        if (manager != null && manager != this)
        {
            Destroy(this);
        }
        else
        {
            manager = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    
    public void TogglePause()
    {
        if (isPaused)
        {
            gameState = previousGameState;
            Time.timeScale = 1.0f;
        }
        else
        {
            previousGameState = gameState;
            gameState = GameStates.PauseScreen;
            Time.timeScale = 0.0f;
        }

        isPaused = !isPaused;
    }


}
