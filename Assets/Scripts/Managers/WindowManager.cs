using System.Collections;
using System.Collections.Generic;
using System.Linq;
using RobbieWagnerGames;
using UnityEngine;
using UnityEngine.InputSystem;

public class WindowManager : MonoBehaviour
{
    [HideInInspector] public List<UIWindow> openWindows;
    [SerializeField] private List<float> gameSpeeds;
    [HideInInspector] public float currentGameSpeed;
    private PlayerInputActions inputActions;
    [SerializeField] public int windowLimit = 5;

    public static WindowManager Instance {get; private set;}

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

        inputActions = new PlayerInputActions();
    }

    public bool CanOpenWindow(UIWindow window)
    {
        return openWindows.Count < windowLimit;
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

    public void OnCloseAllWindows(InputValue inputValue)
    {
        List<UIWindow> windows = openWindows.Select(x => x).ToList();
        foreach(UIWindow window in windows)
        {
            window.CloseWindow();
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
