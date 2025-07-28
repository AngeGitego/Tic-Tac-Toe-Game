using System;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    // Singleton pattern
    public static GameManager Instance { get; private set; }

    // Observer pattern
    public event Action<string> OnGameOver;

    public TMP_Text[] gridTexts;
    public TMP_Text turnDisplay;
    public GameObject[] strikeOutLines;

    private string currentPlayer = "X";
    private bool gameOver = false;

    private PlayerController playerX;
    private PlayerController playerO;

    void Awake()
    {
        // Singleton setup
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // Strategy setup
        playerX = new GameObject("PlayerX").AddComponent<PlayerController>();
        playerX.SetStrategy(new HumanStrategy());

        playerO = new GameObject("PlayerO").AddComponent<PlayerController>();
        playerO.SetStrategy(new AIStrategy());

        turnDisplay.text = "Next Turn: " + currentPlayer;

        // Let Player X start
        playerX.MakeMove();
    }

    public void OnGridClick(int index)
    {
        if (gridTexts[index].text == "" && !gameOver)
        {
            gridTexts[index].text = currentPlayer;
            CheckWinCondition();

            if (!gameOver)
                SwitchPlayer();
        }
    }

    void SwitchPlayer()
    {
        currentPlayer = (currentPlayer == "X") ? "O" : "X";
        turnDisplay.text = "Next Turn: " + currentPlayer;

        if (currentPlayer == "X")
            playerX.MakeMove();
        else
            playerO.MakeMove();
    }

    public void ResetGame()
    {
        gameOver = false;
        currentPlayer = "X";
        turnDisplay.text = "Next Turn: " + currentPlayer;

        foreach (TMP_Text text in gridTexts)
        {
            text.text = "";
            text.color = Color.black;
        }

        foreach (GameObject line in strikeOutLines)
        {
            line.SetActive(false);
        }

        playerX.MakeMove();
    }

    void CheckWinCondition()
    {
        int[,] winPatterns = new int[,]
        {
            {0,1,2}, {3,4,5}, {6,7,8},
            {0,3,6}, {1,4,7}, {2,5,8},
            {0,4,8}, {2,4,6}
        };

        for (int i = 0; i < winPatterns.GetLength(0); i++)
        {
            int a = winPatterns[i, 0];
            int b = winPatterns[i, 1];
            int c = winPatterns[i, 2];

            if (gridTexts[a].text != "" &&
                gridTexts[a].text == gridTexts[b].text &&
                gridTexts[b].text == gridTexts[c].text)
            {
                gridTexts[a].color = Color.green;
                gridTexts[b].color = Color.green;
                gridTexts[c].color = Color.green;

                turnDisplay.text = currentPlayer + " Wins!";
                gameOver = true;

                if (i < strikeOutLines.Length)
                    strikeOutLines[i].SetActive(true);

                OnGameOver?.Invoke(currentPlayer); // Notify UI
                return;
            }
        }
    }

    public bool IsCellEmpty(int index)
    {
        return gridTexts[index].text == "";
    }
}
