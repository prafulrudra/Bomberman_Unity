using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour {

    #region PRIVATE_VARIABLES

    #endregion
    #region PUBLIC_VATIABLE
    #endregion
    #region UNITY_MONOBEHAVIOUR_METHODS
    private void Start ()
    {
        GetComponent<SphereCollider> ().enabled = false; // Disabling the bomb collider at start so that
                //player can move through it for a short dutaration
        Invoke ("AddCollision" , .5f); // Enable it after 0.5 sec   
    }
    #endregion
    #region PRIVATE_METHODS
    private void AddCollision ()
    {
        GetComponent<SphereCollider> ().enabled = true; // Enables the player collider
    }
    #endregion
}
