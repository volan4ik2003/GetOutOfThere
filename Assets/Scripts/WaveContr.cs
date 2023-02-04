using System.Collections;
using System.Collections.Generic;
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
    public GameObject[] MonsterParts, Roots;
    public float[] wavesDuration = new float[10];

    private Wave currentWave;
    private int currentWaveNumber;
    private float nextSpawnTime;

    private bool canSpawn = true;
    private List<GameObject> spawnedEnemies = new List<GameObject>();
    private float searchCountdown = 1f;
    private bool waveFinished = true;

    private void Start()
    {
        foreach (GameObject item in Roots)
        {
            item.GetComponent<Renderer>().sharedMaterial.SetFloat("_FadeAmount", 1);
            item.SetActive(false);
        }
    }

    private void Update()
    {
        Debug.Log(spawnedEnemies.Count);
        currentWave = waves[currentWaveNumber];
        SpawnWave();
    }

    void SpawnNextWave()
    {
        LeanTween.scale(MonsterParts[currentWaveNumber], new Vector3(1, 1, 1), 5f);
        currentWaveNumber++;
        Roots[currentWaveNumber].SetActive(true);
        LeanTween.value(1f, 0f, 1f).setOnUpdate(SetFloat);
        canSpawn = true;
    }

    void SetFloat(float value)
    {
        
        Roots[currentWaveNumber].GetComponent<LineRenderer>().material.SetFloat("_FadeAmount", value);
    }

    void SpawnWave()
    {
        if (canSpawn && nextSpawnTime < Time.time)
        {
            GameObject randomEnemy = currentWave.typeOfEnemies[Random.Range(0, currentWave.typeOfEnemies.Length)];
            Transform randomPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            spawnedEnemies.Add(Instantiate(randomEnemy, randomPoint.position, Quaternion.identity));
            currentWave.noOfEnemies--;
            nextSpawnTime = Time.time + currentWave.spawnInterval;
            Debug.Log(EnemyIsAlive(spawnedEnemies));
            if (currentWave.noOfEnemies == 0 && !EnemyIsAlive(spawnedEnemies))
            {            
                canSpawn = false;
                waveFinished = false;
                StartCoroutine(WaitForNewWave());
            }
        }

    }
    bool EnemyIsAlive(List<GameObject> wave)
    {
        wave.RemoveAll(GameObject => GameObject == null);
        if (currentWave.noOfEnemies <= 0)
        {
            waveFinished = true;
            return false;
        }
        else
        {
            return true;
        }
    }
    bool EnemyIsAlive()
    {
        if (GameObject.FindGameObjectWithTag("Enemy2") == null)
        {
            return false;
        }
        else {
            return true;
        }
        
    }

    bool CheckIfNotNull()
    {
        bool IsAllEnemieAlive = true;
        foreach (GameObject item in spawnedEnemies)
        {
            if (item != null)
            {
                IsAllEnemieAlive = true;
            }
            else {
                IsAllEnemieAlive = false;
            }

        }
        if (!IsAllEnemieAlive)
        {
            return true;
        }
        else {
            return false;
        }
    }

    IEnumerator WaitForNewWave()
    {    
        yield return new WaitForSeconds(wavesDuration[currentWaveNumber]);
        SpawnNextWave();
    }

}
