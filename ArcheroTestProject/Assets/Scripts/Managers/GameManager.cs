using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///     List of the game states.
/// </summary>
public enum GameStates
{
    MainMenu,
    InGame,
    InGame_Dead,
    PauseScreen,
}

/// <summary>
///     GameManager instance.
/// </summary>
public class GameManager : MonoBehaviour
{

    private GameStates gameState;
    public GameStates GameState { get => gameState; }

    private GameManager manager;
    public GameManager Manager { get => manager; }

    private void Awake()
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
        switch (GameState)
        {
            case GameStates.MainMenu:

                break;

            case GameStates.InGame:

                break;

            case GameStates.InGame_Dead:

                break;

            case GameStates.PauseScreen:

                break;
        }
    }

    public void ChangeGameState(GameStates providedGameState)
    {
        gameState = providedGameState;
    }
}
