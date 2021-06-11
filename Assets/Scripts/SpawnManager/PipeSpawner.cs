using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{    
    public GameObject pipeUpPrefab;
    public GameObject pipeDownPrefab;
    public float secondsBetweenSpawns;
    public float distanceBetweenPipes;
    float nextSpawnTime;

    Vector2 pipeUpSize;
    Vector2 pipeDownSize;
    public float pipeSpeed;

    Vector2 screenHalfSizeWorldUnits;

    Player player;

    // Start is called before the first frame update
    void Start()
    {
        screenHalfSizeWorldUnits = new Vector2(Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);
        pipeUpSize = pipeUpPrefab.transform.localScale;
        pipeDownSize = pipeDownPrefab.transform.localScale;

        player = FindObjectOfType<Player>();
        player.OnPlayerDeath += GameOver;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawnTime)
        {
            nextSpawnTime = Time.time + secondsBetweenSpawns;
            Vector2 spawnPositionPipeUp = new Vector2(screenHalfSizeWorldUnits.x + 2, Random.Range(-screenHalfSizeWorldUnits.y - (pipeUpSize.y / 2) + 1f, -screenHalfSizeWorldUnits.y + (pipeUpSize.y / 2) - 1f));
            Vector2 spawnPositionPipeDown = new Vector2(spawnPositionPipeUp.x, spawnPositionPipeUp.y + pipeDownSize.y + distanceBetweenPipes);
            
            Instantiate(pipeUpPrefab, spawnPositionPipeUp, Quaternion.identity);
            Instantiate(pipeDownPrefab, spawnPositionPipeDown, Quaternion.identity);
        }
    }

    void GameOver()
    {
        GetComponent<PipeSpawner>().enabled = false;
    }
}
