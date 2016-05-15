using UnityEngine;
using System.Collections;

public class gameController : MonoBehaviour {
    public GUIText gameoverline;
    public GUIText levelline;
    public GUIText restartline;
    public GUIText scoreline;

    public GameObject hazard;
    public Vector3 defaultSpawnPoint;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    public int initialHazardCount;

    private int score;
    private int level;
    private bool restart;
    private bool gameover;

    private Vector3 position;
    private Quaternion rotation;
    private int i;

    void Start () {
        score = 0;
        level = 0;
        restart = false;
        gameover = false;

        IncrementScore(0);
        incrementLevel();

        gameoverline.text = "";
        restartline.text = "";

        StartCoroutine(waves());
    }

    void Update() {
        if (restart){
            if (Input.GetKeyDown(KeyCode.R)){
                Application.LoadLevel( Application.loadedLevel );
            }
        }
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

            if (i >= hazards()){
                if (gameover) {
                    restart = true;
                    restartline.text = "press [R] to restart";
                    break;
                }
                i = 0;
                incrementLevel();

                yield return new WaitForSeconds(waveWait);
            } else {
                yield return new WaitForSeconds(spawnWait);
            }
        }
    }

    int hazards(){
        return initialHazardCount +  Mathf.CeilToInt(level / 1.5F);
    }

    void incrementLevel() {
        level++;
        levelline.text = "level: " + level;
    }

    public void IncrementScore(int adder) {
        score += adder*level;
        scoreline.text = "score: " + score;
    }

    public void GameOver() {
        gameover = true;
        gameoverline.text = "Game over dickhead";
    }
}
