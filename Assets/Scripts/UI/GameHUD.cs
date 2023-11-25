using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameHUD : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI performanceText;
    [SerializeField] private LayoutGroup windowIcons;
    private List<Image> openWindowsImages;
    [SerializeField] private Image openDisplayPrefab;
    private string PERFORMANCE_LABEL = "Performance: ";

    public static GameHUD Instance {get; private set;}

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

        WindowManager.Instance.OnUpdateGameSpeed += UpdatePerformanceDisplay;
        openWindowsImages = new List<Image>();

        UpdatePerformanceDisplay(0);
    }

    private void UpdatePerformanceDisplay(int openDisplays)
    {
        while(openWindowsImages.Count < openDisplays)
        {
            openWindowsImages.Add(Instantiate(openDisplayPrefab, windowIcons.transform));
        }
        while(openWindowsImages.Count > openDisplays)
        {
            Image image = openWindowsImages[openWindowsImages.Count-1];
            Destroy(image.gameObject);
            openWindowsImages.RemoveAt(openWindowsImages.Count-1);
        }

        switch(openDisplays)
        {
            case 0:
                performanceText.text = PERFORMANCE_LABEL + "Fast";
                performanceText.color = Color.white; 
                foreach(Image image in openWindowsImages) image.color =  Color.white; 
                break;
            case 1:
                performanceText.text = PERFORMANCE_LABEL + "Moderate";
                performanceText.color = Color.white; 
                foreach(Image image in openWindowsImages) image.color =  Color.white; 
                break;
            case 2:
                performanceText.text = PERFORMANCE_LABEL + "Fair";
                performanceText.color = new Color(1, .5f, 0, 1); 
                foreach(Image image in openWindowsImages) image.color =  new Color(1, .5f, 0, 1); 
                break;
            default:
                performanceText.text = PERFORMANCE_LABEL + "Slow";
                performanceText.color = Color.red; 
                foreach(Image image in openWindowsImages) image.color =  Color.red; 
                break;
        }

    }
}
