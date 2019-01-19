using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreScript : MonoBehaviour {
    public enum Score
    {
        AiScore, PlayerScore
    }

    public TextMeshProUGUI AiScoreTxt, PlayerScoreTxt,WinTxt;
    public GameObject WinMenu;

    //public UiManager uiManager;

    public int MaxScore;

    #region Scores
    private int aiScore, playerScore;

    private int AiScore
    {
        get { return aiScore; }
        set
        {
            aiScore = value;
            if (value == MaxScore)
            {
                //lose screen
                WinTxt.text = "Blue Player Wins!";
                WinMenu.SetActive(true);
            }
        }
    }

    private int PlayerScore
    {
        get { return playerScore; }
        set
        {
            playerScore = value;
            if (value == MaxScore)
            {
                //win screen
                WinTxt.text = "Red Player Wins!";
                WinMenu.SetActive(true);
            }
            
        }
    }
    #endregion

    public void Increment(Score whichScore)
    {
        //goal animation
        if (whichScore == Score.AiScore)
            AiScoreTxt.text = (++AiScore).ToString();
        else
            PlayerScoreTxt.text = (++PlayerScore).ToString();
    }

    public void ResetScores()
    {
        AiScore = PlayerScore = 0;
        AiScoreTxt.text = PlayerScoreTxt.text = "0";
    }
}
