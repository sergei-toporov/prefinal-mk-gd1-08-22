using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameStates
{
    MainMenu,
    InGame,
    InGame_Dead,
    Paused,
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
        OnEnablePause();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void OnEnablePause()
    {
        PauseGame();
    }

    public void OnDisablePause()
    {
        UnpauseGame();
    }

    public void OnGameExit()
    {
        Application.Quit();
    }

    public void OnGameReset()
    {
        ResetGame();
    }

    protected void PauseGame()
    {
        Time.timeScale = 0.0f;
        isPaused = true;
        Debug.Log("isPaused: " + isPaused);
        Debug.Log("Game paused.");
    }

    protected void UnpauseGame()
    {
        Time.timeScale = 1.0f;
        isPaused = false;
        Debug.Log("isPaused: " + isPaused);
        Debug.Log("Game unpaused.");
    }

    protected void ResetGame()
    {
        Debug.Log("Game reset.");
        foreach (Character character in GameObject.FindObjectsOfType<Character>())
        {
            character.ResetPosition();
        }
    }



}
