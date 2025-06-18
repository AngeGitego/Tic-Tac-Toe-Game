using UnityEngine;
using TMPro; // Import TMP namespace

public class GameManager : MonoBehaviour
{
    public TMP_Text[] gridTexts; // Use TMP_Text instead of Text
    public TMP_Text turnDisplay;
    public GameObject[] strikeOutLines;


    private string currentPlayer = "X";
    private bool gameOver = false;

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
    }
    public void ResetGame()
    {
        gameOver = false;
        currentPlayer = "X";
        turnDisplay.text = "Next Turn: " + currentPlayer;

        // Clear grid text
        foreach (TMP_Text text in gridTexts)
        {
            text.text = "";
            text.color = Color.black;
        }

        // Hide all strike lines
        foreach (GameObject line in strikeOutLines)
        {
            line.SetActive(false);
        }
    }


    void CheckWinCondition()
    {
        int[,] winPatterns = new int[,] {
        {0,1,2}, {3,4,5}, {6,7,8},    // Horizontal
        {0,3,6}, {1,4,7}, {2,5,8},    // Vertical
        {0,4,8}, {2,4,6}              // Diagonal
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

                return;
            }
        }
    }

}