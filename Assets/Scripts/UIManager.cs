using System;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject titlePanel;
    public GameObject settingsPanel;

    
public void ShowSettings()
    {
       
        titlePanel.SetActive(false);
        settingsPanel.SetActive(true);
    }

    public void ShowTitle()
    {
        settingsPanel.SetActive(false);
        titlePanel.SetActive(true);
    }
}