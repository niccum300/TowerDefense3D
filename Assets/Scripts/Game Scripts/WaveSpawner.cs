using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;

    public Transform spawnPoint;

    public float timeBetweenWaves = 5f;
    private float countdown = 0f;

    public Text waveCountdownText;

    private int waveIndex = 0;

    void Update()
    {
        if (GameManager.gameEnded)
            return;

        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            waveCountdownText.text = waveIndex.ToString();
            countdown = timeBetweenWaves;
        }

        countdown -= Time.deltaTime;
    }

    IEnumerator SpawnWave()
    {
        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }

        waveIndex++;
        PlayerStats.Rounds++;
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}