using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour {

    #region PRIVATE_VARIABLES
    private bool hasExploded;
    #endregion

    #region PUBLIC_VATIABLE

    public GameObject explosionPrefab;
    public LayerMask maskedLayer;

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

    #region PUBLIC_METHODS
    public void Explode ( int explosionRadius , int timer )
    {

        if (!hasExploded)
        {
            StartCoroutine (CreateExplosions (Vector3.forward , explosionRadius , timer));
            StartCoroutine (CreateExplosions (Vector3.right , explosionRadius , timer));
            StartCoroutine (CreateExplosions (Vector3.back , explosionRadius , timer));
            StartCoroutine (CreateExplosions (Vector3.left , explosionRadius , timer));
        }
    }

    #endregion
    #region PRIVATE_IENUMERATORS
    private IEnumerator CreateExplosions ( Vector3 direction , int explosionRadius , int timer )
    {


        yield return new WaitForSeconds (timer);

        for (int i = 0; i < explosionRadius; i++)
        {

            RaycastHit hit;
            Physics.Raycast (transform.position + new Vector3 (0 , .5f , 0) , direction , out hit , i , maskedLayer);

            if (!hit.collider)
            {
                GameObject explosionObj = Instantiate (explosionPrefab , transform.position + ( i * direction ) , explosionPrefab.transform.rotation);
                explosionObj.GetComponent<Explosion> ().explosionRadius = explosionRadius;
                hasExploded = true;
            }
            else
            {
                break;
            }

            yield return new WaitForSeconds (.01f);

            Destroy (gameObject , .2f);
        }
    }
    #endregion

}
