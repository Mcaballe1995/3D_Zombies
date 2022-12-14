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
    public int muertos;
    // Start is called before the first frame update
    void Start()
    {
        waveCount = 2 ; //cantidade e enemigos que aumenta cada oleada
        wave = 0;
        General.zombiesMuertos = 0;
        General.oleadasZombies = 0;
        spawning = false;
        enemiesSpawned = 0;
        gameManager = GameObject.Find("GameManager").GetComponent<General>();
    }

    // Update is called once per frame
    void Update()
    {
        if (spawning == false && enemiesSpawned == General.zombiesMuertos)
        {
            spawning = true;
            StartCoroutine(SpawnWave(waveCount));
        }
        muertos = General.zombiesMuertos;
    }

    IEnumerator SpawnWave(int waveC)
    {
        if (wave == 3)
        {
            //SumadorVariables.CanviColor();
            yield return new WaitForSeconds(2);
            SceneManager.LoadScene("FinalIglesia");
        }
        else
        {
            General.oleadasZombies += 1;
        }


        yield return new WaitForSeconds(4);
        for (int i = 0; i < waveC; i++)
        {
            SpawnEnemy(wave);
            yield return new WaitForSeconds(2);
        }
        wave += 1;
        //General.oleadasZombies += 1;
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
