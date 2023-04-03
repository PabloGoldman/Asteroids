using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidsSpawner : MonoBehaviour
{
    [SerializeField] Asteroid asteroidPrefab;

    [SerializeField] float spawnRate = 2.0f;

    [SerializeField] int asteroidsPerSpawn = 1;

    [SerializeField] float spawnDistance = 15.0f;

    float rotationTrajectoryVariance = 15.0f;

    bool isSpawning = true;

    void Start()
    {
        StartCoroutine(SpawnAsteroidsCoroutine());
    }

    void SpawnAsteroids()
    {
        for (int i = 0; i < asteroidsPerSpawn; i++)
        {
            Vector3 spawnDirection = Random.insideUnitCircle.normalized * spawnDistance;
            Vector3 spawnPoint = transform.position + spawnDirection;

            float variance = Random.Range(-rotationTrajectoryVariance, rotationTrajectoryVariance);
            Quaternion rotation = Quaternion.AngleAxis(variance, Vector3.forward);

            Asteroid asteroid = Instantiate(asteroidPrefab, spawnPoint, rotation);
            asteroid.size = Random.Range(asteroid.minSize, asteroid.maxSize);
            asteroid.SetVectorDirection(rotation * -spawnDirection);
        }
    }

    IEnumerator SpawnAsteroidsCoroutine()
    {
        while (isSpawning)
        {
            SpawnAsteroids();
            yield return new WaitForSeconds(spawnRate);
        }
    }
}
