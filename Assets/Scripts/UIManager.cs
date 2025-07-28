using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject titlePanel;
    public GameObject settingsPanel;

    void Start()
    {
        GameManager.Instance.OnGameOver += HandleGameOver;
    }

    void HandleGameOver(string winner)
    {
        Debug.Log("Game Over! Winner: " + winner);
        // Add Game Over panel or sound here if needed
    }

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
