using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMovement : MonoBehaviour
{
    PipeSpawner pipeSpawner;

    Player player;
    bool isAlive = true;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        player.OnPlayerDeath += GameOver;

        pipeSpawner = FindObjectOfType<PipeSpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveAmount = Vector3.left * pipeSpawner.pipeSpeed;

        transform.position += moveAmount * Time.deltaTime * System.Convert.ToInt32(isAlive);

        if (transform.position.x <= -10)
        {
            Destroy(this.gameObject);
        }
    }

    void GameOver()
    {
        isAlive = false;
    }
}
