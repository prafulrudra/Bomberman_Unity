using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleWall : MonoBehaviour {

    #region PRIVATE_VARIABLES
    #endregion
    #region PUBLIC_VATIABLE
    #endregion
    #region UNITY_MONOBEHAVIOUR_METHODS

    private void OnTriggerEnter ( Collider other )
    {
        GetComponent<MeshRenderer> ().enabled = false;
        GetComponent<BoxCollider> ().enabled = false;
    }

    #endregion
    #region PRIVATE_METHODS
    #endregion
    #region PUBLIC_METHODS
    #endregion
    #region PRIVATE_IENUMERATORS
    #endregion

}
