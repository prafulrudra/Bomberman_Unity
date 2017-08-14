using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    #region PRIVATE_VARIABLES

    private Rigidbody playerRigid;

    #endregion

    #region PUBLIC_VATIABLE

    public int playerNum;       // Player number to differntiate between two players.
    public float moveSpeed;   // Player movement Speed, so that we can change it based on Pickups.

    #endregion


    #region UNITY_MONOBEHAVIOUR_METHODS

    private void Start ()
    {
        playerRigid = GetComponent<Rigidbody> (); // So that we can add velocity to player's rigid body 
                                                  // to move them from one place to another.
    }
    private void Update ()
    {
        if (playerNum == 1) // Player 1 Controls. Player 1 Will use WASD keys to move and space to Place Bomb
        {
            if (Input.GetKey (KeyCode.W))       // Up Movement 
            {
                playerRigid.velocity = new Vector3 (0 , 0 , moveSpeed ); // Adding 'moveSpeed' velocity 
                                                                        // in the direction of Z (Forward) of Player

                playerRigid.rotation = Quaternion.Euler (0 , 0 , 0);    // Aligning player direction (rotation) 
                                                                        // along with move direction

            }
            if (Input.GetKey (KeyCode.A))       // Left Movement 
            {
                playerRigid.velocity = new Vector3 (- moveSpeed  , 0 , 0 ); // Adding 'moveSpeed' velocity 
                                                                        // in the direction of Z (Forward) of Player

                playerRigid.rotation = Quaternion.Euler (0 , 270 , 0);    // Aligning player direction (rotation) 
                                                                        // along with move direction

            }
            if (Input.GetKey (KeyCode.S))       // Back Movement 
            {
                playerRigid.velocity = new Vector3 (0 , 0 , - moveSpeed ); // Adding 'moveSpeed' velocity 
                                                                        // in the direction of Z (Forward) of Player

                playerRigid.rotation = Quaternion.Euler (0 , 180 , 0);    // Aligning player direction (rotation) 
                                                                        // along with move direction

            }
            if (Input.GetKey (KeyCode.D))       // Right Movement 
            {
                playerRigid.velocity = new Vector3 (moveSpeed , 0 , 0); // Adding 'moveSpeed' velocity 
                                                                        // in the direction of Z (Forward) of Player

                playerRigid.rotation = Quaternion.Euler (0 , 90 , 0);    // Aligning player direction (rotation) 
                                                                        // along with move direction

            }
        }


    }

    #endregion
}
