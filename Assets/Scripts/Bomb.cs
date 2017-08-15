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
        GetComponent<SphereCollider> ().enabled = false;    //  Disabling the bomb collider at start so that player can move through it for a short dutaration
        Invoke ("AddCollision" , .5f);                      // Enable after half second delay
    }
    private void OnTriggerEnter ( Collider other )
    {
        if(other.tag == "Explosion")
            Explode (other.GetComponent<Explosion> ().explosionRadius , 0); // Call explode method instantly
    }
   
    #endregion

    #region PRIVATE_METHODS
    private void AddCollision ()
    {
        GetComponent<SphereCollider> ().enabled = true; // Enables the player collider
    }


    #endregion

    #region PUBLIC_METHODS
    public void Explode ( int explosionRadius , int timer ) // Gets explosionRadius and timer from player script and passes them on in Corourtines.
    {

        if (!hasExploded)                                   // Starts enumarator in different directions if no exploded already.
        {
            StartCoroutine (CreateExplosions (Vector3.forward , explosionRadius , timer ));  //  Forward
            StartCoroutine (CreateExplosions (Vector3.right , explosionRadius , timer ));    //  Right
            StartCoroutine (CreateExplosions (Vector3.back , explosionRadius , timer ));     //  Back
            StartCoroutine (CreateExplosions (Vector3.left , explosionRadius , timer ));     //  Left
            
        }
    }

    #endregion

    #region PRIVATE_IENUMERATORS

    private IEnumerator CreateExplosions ( Vector3 direction , int explosionRadius , int timer  ) // Instantiates explosion prefabs in given direction for given lenght after dalay set by timer.
    {


        yield return new WaitForSeconds (timer); //Waits for 'timer' seconds before exploding

        for (int i = 0; i < explosionRadius; i++) // Iterates every tile until explosion radius is reached
        {

            RaycastHit hit;
            Physics.Raycast (transform.position + new Vector3 (0 , .5f , 0) , direction , out hit , i , maskedLayer);   // To ignore explosions on Non Destructible Walls.

            if (!hit.collider)
            {
                GameObject explosionObj = Instantiate (explosionPrefab , transform.position + ( i * direction ) , explosionPrefab.transform.rotation);
                explosionObj.GetComponent<Explosion> ().explosionRadius = explosionRadius;  //Sets explosion radius of this bomb to all explosions so that they can trigger other bombs at same radius.
                
                hasExploded = true; 
            }
            else
            {
                break;
            }

            yield return new WaitForSeconds (.01f); // Waits for .01 seconds before exploding others so that explosion loos like its growing outwards.
            
            Destroy (gameObject , .1f); //Destroys the Bomb object
        }
    }
    #endregion

}
