using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {

    
    #region PUBLIC_VATIABLES
    public int explosionRadius; // Lets store explosion radius here so it can be called by other bombs to same radius.
    #endregion

    #region UNITY_MONOBEHAVIOUR_METHODS
    private void Start ()
    {
        Invoke ("DestroyExplosion" , .3f); // Destroy Explosion after .3 seconds so that it has sufficient time play particles sim. 
    }
    #endregion

    #region PRIVATE_METHODS
    private void DestroyExplosion ()
    {
        Destroy (gameObject); //Destorys current(this) GameObject
    }
    #endregion
    
}
