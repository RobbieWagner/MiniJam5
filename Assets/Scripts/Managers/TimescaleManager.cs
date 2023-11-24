using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimescaleManager : MonoBehaviour
{
    [SerializeField] int windowLimit = 3;
    [SerializeField] private List<UIWindow> openWindows;
    [SerializeField] private List<float> gameSpeeds;

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
        GameManager.Instance.gameSpeed = gameSpeeds[openWindows.Count];
        Time.timeScale = gameSpeeds[openWindows.Count];
    }
}
