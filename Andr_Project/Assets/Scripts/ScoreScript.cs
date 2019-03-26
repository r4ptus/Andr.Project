using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

/** Script Zaehlen der erzielten Tore */
public class ScoreScript : MonoBehaviour {
    /** Zum Unterscheiden, wer das Tor erzielt hat */
    public enum Score
    {
        AiScore, PlayerScore
    }

    public TextMeshProUGUI AiScoreTxt, PlayerScoreTxt,WinTxt; //**Textanzeige der Tore */
    public GameObject WinMenu;

    //public UiManager uiManager;

    public int MaxScore; /**Anzahl benoetigten Tore zum Gewinnen */


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
                Time.timeScale = 0;
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
                Time.timeScale = 0;
            }
            
        }
    }
    #endregion
     /** Methode zum erhoehen der Tore */
    public void Increment(Score whichScore)
    {
        //goal animation
        if (whichScore == Score.AiScore)
            AiScoreTxt.text = (++AiScore).ToString();
        else
            PlayerScoreTxt.text = (++PlayerScore).ToString();
    }

    /** Setzt die Anzahl der Tore auf 0 zurück */
    public void ResetScores()
    {
        AiScore = PlayerScore = 0;
        AiScoreTxt.text = PlayerScoreTxt.text = "0";
    }
}
