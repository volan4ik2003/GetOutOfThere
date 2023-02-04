using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Wave
{
    public string waveName;
    public int noOfEnemies;
    public GameObject[] typeOfEnemies;
    public float spawnInterval;
}

public class WaveContr : MonoBehaviour
{
    public Wave[] waves;
    public Transform[] spawnPoints;
    public GameObject[] Roots;

    private Wave currentWave;
    private int currentWaveNumber;
    private float nextSpawnTime;

    private bool canSpawn = true;


    private void Update()
    {   
        currentWave = waves[currentWaveNumber];
        SpawnWave();
    }

    void SpawnNextWave()
    {
        LeanTween.scale(Roots[currentWaveNumber], new Vector3(1, 1, 1), 5f);
        currentWaveNumber++;
        canSpawn = true;
    }


    void SpawnWave()
    {
        if (canSpawn && nextSpawnTime < Time.time)
        {
            GameObject randomEnemy = currentWave.typeOfEnemies[Random.Range(0, currentWave.typeOfEnemies.Length)];
            Transform randomPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            Instantiate(randomEnemy, randomPoint.position, Quaternion.identity);
            currentWave.noOfEnemies--;
            nextSpawnTime = Time.time + currentWave.spawnInterval;
            if (currentWave.noOfEnemies == 0)
            {            
                canSpawn = false;
                StartCoroutine(WaitForNewWave());
            }
        }

    }

    IEnumerator WaitForNewWave()
    {
        yield return new WaitForSeconds(5f);
        SpawnNextWave();
    }

}
