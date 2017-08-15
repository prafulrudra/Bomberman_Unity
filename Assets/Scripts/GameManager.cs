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
    #endregion

    #region PUBLIC_VATIABLE
    public Text winnerNameText;
    public Canvas gameOverMenu;
    #endregion

    #region UNITY_MONOBEHAVIOUR_METHODS
    private void Start ()
    {
        gameOverMenu.enabled = false;
    }
    #endregion


    #region PUBLIC_METHODS
    public void PlayerDied ( int playerNum )
    {
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
        gameOverMenu.enabled = true;    // Enable Game Over Menu Canvas when 
        if (deadPlayers == 1)           // If there is only one dead player after .5 sec the first player deid then we declare surviving player as winner.
        {
            if (deadPlayerNum == 1)
                winnerNameText.text = "Player 2 Wins"; 

            else if (deadPlayerNum == 2)
                winnerNameText.text = "Player 1 Wins";
        }
        else
            winnerNameText.text = "Draw - Both players dead";
    }
    #endregion



}
