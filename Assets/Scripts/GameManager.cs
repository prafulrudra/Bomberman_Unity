using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region PRIVATE_VARIABLES
    private int deadPlayers;
    private int deadPlayerNum;
    private float timeLeft;
    #endregion

    #region PUBLIC_VATIABLE
    public Text winnerNameText;
    public Text timerText;
    public Canvas gameOverMenu;
    #endregion

    #region UNITY_MONOBEHAVIOUR_METHODS
    private void Start ()
    {
        gameOverMenu.enabled = false;
        timeLeft = 50;  // Total time will be 50 seconds

    }
    private void Update ()
    {
        
        timeLeft -= Time.deltaTime;
        timerText.text = "Time Left :" + timeLeft.ToString("F2");
        if (timeLeft <= 0)  // If timer hits zero we call CheckDeaths (), which is equivalent to GameOver function
        {
            CheckDeaths ();
        }
    }
    #endregion


    #region PUBLIC_METHODS
    public void PlayerDied ( int playerNum )
    {
        Debug.Log (playerNum);
        deadPlayers++;
        deadPlayerNum = playerNum;
        Invoke ("CheckDeaths" , .5f); // Check if both players are dead within .5 seconds of each other
        
    }
    public void OnReplayButton ()
    {
        SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
        Time.timeScale = 1;
    }
    #endregion
    #region PRIVATE_METHODS
    private void CheckDeaths ()
    {
        Time.timeScale = 0;             // Pauses the game setting timescale to 0 so no physics actions will happen after player death
        gameOverMenu.enabled = true;    // Enable Game Over Menu canvas 
        if (deadPlayers == 1)           // If there is only one dead player after .5 sec the first player deid then we declare surviving player as winner.
        {
            if (deadPlayerNum == 1)
                winnerNameText.text = "Player 2 Wins"; 

            else if (deadPlayerNum == 2)
                winnerNameText.text = "Player 1 Wins";
        }
        else                            // Since if both are dead or none are dead when time runs out we call Draw
            winnerNameText.text = "Draw";
    }
    #endregion



}
