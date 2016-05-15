using UnityEngine;
using System.Collections;

public class triggerDestroy : MonoBehaviour {
    public GameObject defaultExplosion;
    public GameObject playerExplosion;

    private GameObject explosion;

    void OnTriggerEnter(Collider c){
        if (c.tag == "isBoundary") {
            return;
        }

        explosion = setExplosion(c.tag);
        Instantiate(explosion, transform.position, transform.rotation);

        Destroy(gameObject);
        Destroy(c.gameObject);
    }

    GameObject setExplosion(string tag){
        if ( tag == null || tag == string.Empty || tag == "isAsteroid" ) {
            return defaultExplosion;
        } else if ( tag == "Player" ) {
            return playerExplosion;
        }

        // catch all
        return defaultExplosion;
    }
}
