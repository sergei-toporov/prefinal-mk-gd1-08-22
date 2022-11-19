using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    protected static UIManager manager;
    public static UIManager Manager { get => manager; }

    [SerializeField] protected UIElementsBase mainMenuUI;
    [SerializeField] protected UIElementsBase ingameUI;
    [SerializeField] protected UIElementsBase pauseScreenUI;


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

    public void OnMainMenuStartPressed()
    {
        Debug.Log("Main Menu Start button pressed!");
        EventManager.Manager.DisablePause.TriggerEvent();
        mainMenuUI.DisableElement();
        ingameUI.EnableElement();
    }

    public void OnMainMenuExitPressed()
    {
        Debug.Log("Main Menu exit button pressed!");
        EventManager.Manager.ExitGame.TriggerEvent();
    }

    public void OnIngamePausePressed()
    {
        Debug.Log("Ingame pause button pressed!");
        EventManager.Manager.EnablePause.TriggerEvent();
        ingameUI.DisableElement();
        pauseScreenUI.EnableElement();
    }

    public void OnPauseResetPressed()
    {
        Debug.Log("On pause screen reset button pressed!");
        EventManager.Manager.ResetGame.TriggerEvent();
        pauseScreenUI.DisableElement();
        ingameUI.EnableElement();
        EventManager.Manager.DisablePause.TriggerEvent();
    }

    public void OnPauseResumePressed()
    {
        Debug.Log("On pause screen resume button pressed!");
        EventManager.Manager.DisablePause.TriggerEvent();
        ingameUI.EnableElement();
        pauseScreenUI.DisableElement();
    }

    public void OnPauseMainMenuReset()
    {
        Debug.Log("On pause screen main menu button pressed!");
        EventManager.Manager.ResetGame.TriggerEvent();
        pauseScreenUI.DisableElement();
        mainMenuUI.EnableElement();
    }
}
