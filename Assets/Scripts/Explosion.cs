using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {

    
    #region PUBLIC_VATIABLE
    public int explosionRadius;
    #endregion
    #region UNITY_MONOBEHAVIOUR_METHODS
    private void Start ()
    {
        Invoke ("DestroyExplosion" , 1f);
    }
    #endregion
    #region PRIVATE_METHODS
    private void DestroyExplosion ()
    {
        Destroy (gameObject);
    }
    #endregion
    
}
