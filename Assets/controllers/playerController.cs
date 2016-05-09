using UnityEngine;
using System.Collections;

using helpers;

public class playerController : MonoBehaviour {
    public BoundaryLimit boundary;
    public float tilt;
    public int speed;

    public GameObject shot;
    public Transform shotSpawn;
    public float rate;

    private Rigidbody rb;
    private float horiz;
    private float vert;
    private float nextShot;

    void Start () {
        rb = GetComponent<Rigidbody>();
    }

    void Update () {
        if ( Input.GetButton("Fire1") && Time.time > nextShot ){
            nextShot = Time.time + rate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        }
    }

    void FixedUpdate () {
        horiz = Input.GetAxis("Horizontal");
        vert = Input.GetAxis("Vertical");

        rb.velocity = new Vector3(horiz, 0.0f, vert) * speed;

        rb.position = new Vector3(Mathf.Clamp(rb.position.x,
                                              boundary.xMin,
                                              boundary.xMax),
                                  0.0f,
                                  Mathf.Clamp(rb.position.z,
                                              boundary.zMin,
                                              boundary.zMax)
                                  );
        rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * -tilt);
    }
}
