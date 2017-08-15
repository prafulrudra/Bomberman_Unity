using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Player : MonoBehaviour {

    // Using region helps organize codes and also helps with code folding

    #region PRIVATE_VARIABLES 

    private Rigidbody playerRigid;  // Reference to to player's rigidbody component.
    private int explosionRadius = 3;    //Bomb explosion radius i.e, number of tiles linearly that are going to explode.
    private int maxBombs ;  // Max num of bombs player can have
    private List<GameObject> bombsList = new List<GameObject>(); // List to store temp dropped bombs
    private int bombCount;
    #endregion

    #region PUBLIC_VATIABLE

    public int playerNum;               // Player number to differntiate between two players.
    public float moveSpeed;             // Player movement Speed, so that we can change it based on Pickups.
    public GameObject bombPrefab;       // Reference to bomb prefab.
    public int bombTimer;               // Time after which bomb explodes. We will stick to int here.
    public bool isDead;
    public GameManager gameManager;

    #endregion


    #region UNITY_MONOBEHAVIOUR_METHODS

    private void Start ()
    {
        isDead = false;
        bombCount = 1; //Inititally just one bomb
        maxBombs = 1;
        playerRigid = GetComponent<Rigidbody> (); // So that we can add velocity to player's rigid body to move them from one place to another.
        
    }
    private void Update ()
    {
        if (playerNum == 1) // Player 1 Controls. Player 1 Will use WASD keys to move and space to Place Bomb
        {
            if (Input.GetKey (KeyCode.W))       // Up Movement 
            {
                playerRigid.velocity = new Vector3 (0 , 0 , moveSpeed );// Adding 'moveSpeed' velocity in the direction of (Z or Forward) Player's rotation
                playerRigid.rotation = Quaternion.Euler (0 , 0 , 0);    // Aligning player direction (rotation)  along with move direction

            }
            if (Input.GetKey (KeyCode.A))       // Left Movement 
            {
                playerRigid.velocity = new Vector3 (- moveSpeed  , 0 , 0 );

                playerRigid.rotation = Quaternion.Euler (0 , 270 , 0);    

            }
            if (Input.GetKey (KeyCode.S))       // Back Movement 
            {
                playerRigid.velocity = new Vector3 (0 , 0 , - moveSpeed ); 
                playerRigid.rotation = Quaternion.Euler (0 , 180 , 0);    
            }
            if (Input.GetKey (KeyCode.D))       // Right Movement 
            {
                playerRigid.velocity = new Vector3 (moveSpeed , 0 , 0);  
                playerRigid.rotation = Quaternion.Euler (0 , 90 , 0);    
            }
            if (Input.GetKeyDown (KeyCode.Space))
                DropBombs ();
        }

        if (playerNum == 2) // Player 2 Controls. Player 2 Will use arrow keys to move and numberpad enter button to Place Bomb.
        {
            if (Input.GetKey (KeyCode.UpArrow))       // Up Movement 
            {
                playerRigid.velocity = new Vector3 (0 , 0 , moveSpeed); 
                playerRigid.rotation = Quaternion.Euler (0 , 0 , 0);    

            }
            if (Input.GetKey (KeyCode.LeftArrow))       // Left Movement 
            {
                playerRigid.velocity = new Vector3 (-moveSpeed , 0 , 0); 
                playerRigid.rotation = Quaternion.Euler (0 , 270 , 0);    
            }
            if (Input.GetKey (KeyCode.DownArrow))       // Back Movement 
            {
                playerRigid.velocity = new Vector3 (0 , 0 , -moveSpeed); 
                playerRigid.rotation = Quaternion.Euler (0 , 180 , 0);    
            }
            if (Input.GetKey (KeyCode.RightArrow))       // Right Movement 
            {
                playerRigid.velocity = new Vector3 (moveSpeed , 0 , 0);
                playerRigid.rotation = Quaternion.Euler (0 , 90 , 0);   
            }
            if (Input.GetKeyDown (KeyCode.KeypadEnter))
               DropBombs ();
        }

        CheckExplosion ();                       // Checks if the bombs that were placed exploded or not.
    }
    private void OnTriggerEnter ( Collider other )
    {
        if (other.tag == "Explosion" && !isDead)           // If the trigger hit the player is tagged "Explosion" then player is dead.
        {
            isDead = true;
            gameManager.PlayerDied (this.playerNum);
            Destroy (gameObject, 0.01f);
        }
    }
    #endregion

    #region PRIVATE_METHODS
    public void DropBombs ()
    {
        if (bombCount > 0 && bombCount <= maxBombs) // Check if we have bombs 
        {
            
            GameObject bombClone =  Instantiate (bombPrefab , new Vector3 (( Mathf.RoundToInt (transform.position.x) ) , .5f , ( Mathf.RoundToInt (transform.position.z) )) , transform.rotation);               // Instantiates a bomb prefab right below player position.
            bombsList.Add (bombClone);  // We add the dropped bomb to a list to check if it exploded later on                                 
            bombClone.GetComponent<Bomb> ().Explode (explosionRadius , bombTimer);  // Calls Bomb Script's Explode method, along with explosion radius and time data for each bomb based on powerup.
            bombCount--;    // Remove one from count.
           
        }
    }

    public void CheckExplosion ()
    {
        
        if (bombCount != maxBombs)
        {

            foreach (var bomb in bombsList.ToList<GameObject>()) //We copy the list since we cant iterate through and modify the list at same time
                if (bomb.GetComponent<Bomb> ().hasExploded)
                {
                    bombCount++;    // Add one from count.
                    bombsList.Remove (bomb);    // But remove on from list since it exploded.
                }
        }

    }
    #endregion

}
