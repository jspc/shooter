using UnityEngine;
using System.Collections;

public class timeDestroy : MonoBehaviour {
    public float lifetime;

    void Start () {
        Destroy(gameObject, lifetime);
    }
}
