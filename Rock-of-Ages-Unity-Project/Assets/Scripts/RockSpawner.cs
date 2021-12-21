using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A rock spawner
/// </summary>
public class RockSpawner : MonoBehaviour
{   // serialize field 
	// needed for spawning
	[SerializeField]
	GameObject prefabRock;

	// saved for efficiency
	[SerializeField]
	Sprite rockSprite0;
	[SerializeField]
	Sprite rockSprite1;
	[SerializeField]
	Sprite rockSprite2;

	// spawn control
	const float SpawnDelaySeconds = 1;
	Timer spawnTimer;


	/// <summary>
	/// Use this for initialization
	/// </summary>
	void Start()
	{
		// create and start timer
		spawnTimer = gameObject.AddComponent<Timer>();
		spawnTimer.Duration = SpawnDelaySeconds;
		spawnTimer.Run();
	}

	/// <summary>
	/// Update is called once per frame
	/// </summary>
	void Update()
	{
		// check for time to spawn a new rock
		if (spawnTimer.Finished &&
			GameObject.FindGameObjectsWithTag("RockTag").Length < 3)
		{
			SpawnRock();

			// restart spawn timer
			spawnTimer.Run();
		}
	}

	/// <summary>
	/// Spawns a new rock at a random location
	/// </summary>
	void SpawnRock()
	{
		// create new rock
		GameObject Rock = Instantiate(prefabRock) as GameObject;
		Rock.transform.position = Vector3.zero;

		// set random sprite for new rock
		SpriteRenderer spriteRenderer = Rock.GetComponent<SpriteRenderer>();
		int spriteNumber = Random.Range(0, 3);
		if (spriteNumber == 0)
		{
			spriteRenderer.sprite = rockSprite0;
		}
		else if (spriteNumber == 1)
		{
			spriteRenderer.sprite = rockSprite1;
		}
		else
		{
			spriteRenderer.sprite = rockSprite2;
		}
	}
}
