using UnityEngine;
using System.Collections;

public class boundaryDestroy : MonoBehaviour {
    void OnTriggerExit(Collider c){
        Destroy(c.gameObject);
    }
}
