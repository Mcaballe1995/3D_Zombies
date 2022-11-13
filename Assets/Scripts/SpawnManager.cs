using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] spawnPoints;
    public GameObject[] enemigos;
    public int waveCount;
    public int wave;
    public bool spawning;
    private int enemiesSpawned;
    private int enemyType;
    private General gameManager;
    // Start is called before the first frame update
    void Start()
    {
        waveCount = 2 ; //cantidade e enemigos que aumenta cada oleada
        wave = 0;
        spawning = false;
        enemiesSpawned = 0;
        gameManager = GameObject.Find("GameManager").GetComponent<General>();
    }

    // Update is called once per frame
    void Update()
    {
        if(spawning == false && enemiesSpawned == General.defeatedEnemies)
        {
            StartCoroutine(SpawnWave(waveCount));
        }
        if( wave == 3)
        {
                SceneManager.LoadScene("FinalIglesia"); 
        }
    }

    IEnumerator SpawnWave(int waveC)
    {
        spawning = true;
        yield return new WaitForSeconds(4);
        for (int i = 0; i < waveC; i++)
        {
            SpawnEnemy(wave);
            yield return new WaitForSeconds(2);
        }
        wave += 1;
        waveCount += 2;
        spawning = false;
        yield break;
    }

    void SpawnEnemy(int wave)
    {
        int spawnPos = Random.Range(0, 4);
        Instantiate(enemigos[enemyType], spawnPoints[spawnPos].transform.position, spawnPoints[spawnPos].transform.rotation);
        enemiesSpawned += 1;
    }
}
