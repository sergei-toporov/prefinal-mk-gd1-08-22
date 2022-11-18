using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor.PackageManager.UI;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;
using Unity.VisualScripting;

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
