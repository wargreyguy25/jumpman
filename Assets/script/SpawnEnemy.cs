using UnityEngine;
using System.Collections;

public class SpawnEnemy : MonoBehaviour {

	public float spawnTime;        // The amount of time between each spawn.
	public float spawnDelay;       // The amount of time before spawning starts.
	public GameObject[] enemies;        // Array of enemy prefabs.

	public int maxDistance;
	public Transform target;
	public Transform myTransform;

	void Awake()
	{
		myTransform = transform;
	}

	void Start()
	{
		GameObject stop = GameObject.FindGameObjectWithTag("Player");

		target = stop.transform;

		maxDistance = 7;
	}

	void FixedUpdate()
	{
		if (Vector3.Distance(target.position, myTransform.position) < maxDistance)
		{
			InvokeRepeating("Spawn", spawnDelay, spawnTime);
		}
	}

	void Spawn()
	{
		// Instantiate a random enemy.
		int ZombieIndex = Random.Range(0, enemies.Length);
		Instantiate(enemies[ZombieIndex], transform.position, transform.rotation);   
	}
}