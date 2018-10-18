using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour {


    public GameObject enemy;
    public float spawnTime;
    public Transform[] spawnPoints;

	// Use this for initialization
	void Start () {
        InvokeRepeating("Spawn", spawnTime, spawnTime);
	}

	// Update is called once per frame
	void Update () {
		
	}

    void Spawn()
    {
        Transform _spawnP = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Instantiate(enemy, _spawnP.position, _spawnP.rotation);
    }
}
