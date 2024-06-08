using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ProjetilSpawn : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject monstroProjetil;
    public float spawnTimer;
    public float spawnMax = 7;
    public float spawnMin = 4;
    void Start()
    {
        spawnTimer = Random.Range(spawnMin, spawnMax);
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0)
        {
            Instantiate(monstroProjetil, transform.position, Quaternion.identity);
            spawnTimer = Random.Range(spawnMin, spawnMax);
        }

    }
}
