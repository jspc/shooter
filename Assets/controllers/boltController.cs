using UnityEngine;
using System.Collections;

public class boltController : MonoBehaviour {
    public int speed;

    private Rigidbody rb;

    void Start () {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;
    }
}
