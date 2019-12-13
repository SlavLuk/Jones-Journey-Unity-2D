using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    [System.Serializable]
    public class Wave
    {
        public Enemy[] enemies;
        public int count;
        public float timeBetweenSpawns;

    }
    public Wave[] waves;
    public Transform[] spawnPoints;
    public float timeBetweenWaves;
    private Wave currentWave;
    private int currentWaveIndex;
    private Transform player;
    private bool finishedSpawning;
    private float currentTime = 1f;
    private float startTime = 4f;
    [SerializeField]
    private Text countDown;


    private void Start()
    {
        
        currentTime = startTime;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(StartNextWave(currentWaveIndex));
    }

    IEnumerator CountDown()
    {
        currentTime = startTime;
        yield return countDown.color = Color.white;


    }

    IEnumerator StartNextWave(int index)
    {

        StartCoroutine(CountDown());
      

        yield return new WaitForSeconds(timeBetweenWaves);
        StartCoroutine(SpawnWave(index));
    }

    IEnumerator SpawnWave(int index)
    {
        currentWave = waves[index];
        for(int i = 0; i < currentWave.count; i++)
        {
            if (player == null)
            {
                yield break;
            }
            else
            {
                Enemy randomEnemy = currentWave.enemies[Random.Range(0, currentWave.enemies.Length)];
                Transform randomSpot = spawnPoints[Random.Range(0, spawnPoints.Length)];
                Instantiate(randomEnemy, randomSpot.position, randomSpot.rotation);
            }

            if(i == currentWave.count - 1)
            {
                finishedSpawning = true;
            }
            else
            {
                finishedSpawning = false;
            }
           

            yield return new WaitForSeconds(currentWave.timeBetweenSpawns);
        }
    }

    private void Update()
    {

        currentTime -= 1 * Time.deltaTime;
        if (countDown != null)
        {
            countDown.text = ((int)currentTime).ToString();
        }
       


        if (currentTime <= 0)
        {
            currentTime = 0;

            countDown.color = Color.clear;
        }

        if(finishedSpawning == true && GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            finishedSpawning = false;
            if (currentWaveIndex + 1 < waves.Length)
            {
                currentWaveIndex++;
                StartCoroutine(StartNextWave(currentWaveIndex));
            }
            else
            {
                Debug.Log("Game finished!!!!");
            }
        }
    }
}




