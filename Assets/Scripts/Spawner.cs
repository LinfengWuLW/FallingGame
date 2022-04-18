using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject fallingBlockPrefab;
    public GameObject BonusPrefab;

    public Vector2 secondsBetweenSpawnMinMax = new Vector2(0.3f,1f);
    float nextSpawnTime;
    float nextSpawnTime2=5;

    public Vector2 spawnSizeMinMax=new Vector2(0.3f,1.3f);
    public float spawnAngleMax = 15;

    Vector2 screenHalfSizeWorldUnits;

    float cameraAspect = 3 / 5f;

    void Start()
    {
        //screenHalfSizeWorldUnits = new Vector2 (Camera.main.aspect * Camera.main.orthographicSize,Camera.main.orthographicSize);
        //screenHalfSizeWorldUnits = new Vector2(cameraAspect* Screen.height, Camera.main.orthographicSize);
        screenHalfSizeWorldUnits = new Vector2 (cameraAspect * Camera.main.orthographicSize,Camera.main.orthographicSize);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawnTime)
        {
            float secondsBetweenSpawn = Mathf.Lerp(secondsBetweenSpawnMinMax.y, secondsBetweenSpawnMinMax.x, Difficulty.GetDifficultyPercent());
            nextSpawnTime = Time.time + secondsBetweenSpawn;

            float spawnSize = Random.Range(spawnSizeMinMax.x, spawnSizeMinMax.y);
            float spawnAngle = Random.Range(-spawnAngleMax, spawnAngleMax);

            Vector2 spawnPosition = new Vector2(Random.Range(-screenHalfSizeWorldUnits.x, screenHalfSizeWorldUnits.x), screenHalfSizeWorldUnits.y+spawnSize);
            GameObject newBlock= Instantiate(fallingBlockPrefab, spawnPosition, Quaternion.Euler(Vector3.forward*spawnAngle));
            newBlock.transform.localScale = Vector2.one * spawnSize;
            
        }

        if (Time.time > nextSpawnTime2)
        {
            float secondsBetweenSpawn2 = Mathf.Lerp(secondsBetweenSpawnMinMax.y, secondsBetweenSpawnMinMax.x, Difficulty.GetDifficultyPercent());
            nextSpawnTime2 = Time.time + secondsBetweenSpawn2;

            float spawnSize2 = Random.Range(spawnSizeMinMax.x, spawnSizeMinMax.y);
            float spawnAngle2 = Random.Range(-spawnAngleMax, spawnAngleMax);

            Vector2 spawnPosition2 = new Vector2(Random.Range(-screenHalfSizeWorldUnits.x, screenHalfSizeWorldUnits.x), screenHalfSizeWorldUnits.y + spawnSize2);
            GameObject newBonus = Instantiate(BonusPrefab, spawnPosition2, Quaternion.Euler(Vector3.forward * spawnAngle2));
            newBonus.transform.localScale = Vector2.one * spawnSize2;
        }
    }

    
}
