using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimescaleManager : MonoBehaviour
{
    [SerializeField] private List<UIWindow> openWindows;
    [SerializeField] private List<float> gameSpeeds;
    [HideInInspector] public float currentGameSpeed;

    public static TimescaleManager Instance {get; private set;}

    private void Awake()
    {
        if (Instance != null && Instance != this) 
        { 
            Destroy(gameObject); 
        } 
        else 
        { 
            Instance = this; 
        } 
    }

    public void OpenNewWindow(UIWindow window)
    {
        if(!openWindows.Contains(window))
        {
            openWindows.Add(window);
            //window.OnCloseThisWindow += CloseWindow;
            UpdateGameSpeed();
        }
    }

    public void CloseWindow(UIWindow window)
    {
        if(openWindows.Contains(window))
        {
            openWindows.Remove(window);
            UpdateGameSpeed();
        }
    }

    private void UpdateGameSpeed()
    {
        if(openWindows.Count < gameSpeeds.Count) currentGameSpeed = gameSpeeds[openWindows.Count];
        else currentGameSpeed = gameSpeeds[gameSpeeds.Count - 1];

        GameManager.Instance.gameSpeed = currentGameSpeed;
        Time.timeScale = currentGameSpeed;
        OnUpdateGameSpeed?.Invoke(openWindows.Count);
    }
    public delegate void OnUpdateGameSpeedDelegate(int openDisplays);
    public event OnUpdateGameSpeedDelegate OnUpdateGameSpeed;
}
