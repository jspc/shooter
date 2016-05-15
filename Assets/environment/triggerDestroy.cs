using UnityEngine;
using System;
using System.Collections;

public class triggerDestroy : MonoBehaviour {
    public GameObject defaultExplosion;
    public GameObject playerExplosion;
    public int scoreValue;

    private GameObject explosion;
    private GameObject controllerObj;
    private gameController controller;

    void Start() {
        controllerObj = GameObject.FindWithTag("GameController");
        if (controllerObj == null){
            throw new Exception("No game controller");
        } else {
            controller = controllerObj.GetComponent<gameController>();
        }
    }

    void OnTriggerEnter(Collider c){
        if (c.tag == "isBoundary") {
            return;
        }

        explosion = setExplosion(c.tag);
        Instantiate(explosion, transform.position, transform.rotation);

        if (c.tag == "Player") {
            controller.GameOver();
        } else {
            controller.IncrementScore(scoreValue);
        }

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
