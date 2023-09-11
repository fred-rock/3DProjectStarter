using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonManager : MonoBehaviour
{
    public static SingletonManager Instance { get; private set; }

    public GameManager GameManager { get; private set; }
    public LevelManager LevelManager { get; private set; }

    // public AudioManager AudioManager { get; private set; }
    // public UIManager UIManager { get; private set; }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        Instance = this;
        // AudioManager = GetComponentInChildren<AudioManager>();
        // UIManager = GetComponentInChildren<UIManager>();
        GameManager = GetComponentInChildren<GameManager>();
        LevelManager = GetComponentInChildren<LevelManager>();
    }
}
