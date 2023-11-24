using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimescaleManager : MonoBehaviour
{
    [SerializeField] int windowLimit = 3;
    private List<UIWindow> openWindows;

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
            openWindows.Add(window);
    }

    public void CloseWindow(UIWindow window)
    {
        if(openWindows.Contains(window))
            openWindows.Remove(window);
    }
}
