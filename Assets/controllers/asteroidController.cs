using UnityEngine;
using System.Collections;

public class asteroidController : MonoBehaviour {
    public float tumbleRate;
    public float speed;

    private Rigidbody rb;

    void Start () {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;
        rb.angularVelocity = Random.insideUnitSphere * tumbleRate;
    }

}
