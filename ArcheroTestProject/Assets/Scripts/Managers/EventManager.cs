using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor.PackageManager.UI;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;
using Unity.VisualScripting;
using System;
using UnityEngine.Events;

[Serializable]
public class EventManager : MonoBehaviour
{
    protected static EventManager manager;
    public static EventManager Manager { get => manager; }

    [SerializeField] protected GameEvent onHPChange;
    public GameEvent OnHPChange { get => onHPChange; }

    [SerializeField] protected GameEvent onRKey;
    public GameEvent OnRKey { get => onRKey; }

    [SerializeField] protected GameEvent onSpaceKey;
    public GameEvent OnSpaceKey { get => onSpaceKey; }

    [SerializeField] protected GameEvent onPauseToggle;
    public GameEvent OnPauseToggle { get => onPauseToggle; }

    [SerializeField] protected GameEvent enablePasue;
    public GameEvent EnablePause { get => enablePasue; }

    [SerializeField] protected GameEvent disablePause;
    public GameEvent DisablePause { get => disablePause; }

    [SerializeField] protected GameEvent exitGame;
    public GameEvent ExitGame { get => exitGame; }

    [SerializeField] protected GameEvent resetGame;
    public GameEvent ResetGame { get => resetGame; }

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

}
