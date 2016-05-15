using UnityEngine;
using System.Collections;

public class gameController : MonoBehaviour {
    public GameObject hazard;
    public int hazardCount;
    public Vector3 defaultSpawnPoint;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    private Vector3 position;
    private Quaternion rotation;
    private int i;

    void Start () {
        StartCoroutine(waves());
    }

    IEnumerator waves() {
        yield return new WaitForSeconds(startWait);
        i = 0;
        while(true) {
            position = new Vector3(Random.Range(-defaultSpawnPoint.x, defaultSpawnPoint.x),
                               defaultSpawnPoint.y,
                               defaultSpawnPoint.z);
            rotation = Quaternion.identity;

            Instantiate(hazard, position, rotation);
            i++;

            if (i >= hazardCount){
                i = 0;
                yield return new WaitForSeconds(waveWait);
            } else {
                yield return new WaitForSeconds(spawnWait);
            }
        }
    }

}
