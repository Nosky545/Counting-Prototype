using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : MonoBehaviour
{
    private float zRange = 15f;
    private float ySpawnPos = 25f;

    private GameManager gameManager;

    // Start is called before the first frame update
    void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        transform.position = RandomSpawnPos();
    }

    void Update()
    {
        if (transform.position.y < 0 )
        {
            gameManager.UpdateLives();
            Destroy(gameObject);
        }
    }

    Vector3 RandomSpawnPos()
    {
        return new Vector3(0, ySpawnPos, Random.Range(-zRange, zRange));
    }
}
