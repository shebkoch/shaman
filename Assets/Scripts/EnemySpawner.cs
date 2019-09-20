using System;
using System.Collections.Generic;
using UnityEngine;
using static DirectionExtension;
using Random = UnityEngine.Random;

public class EnemySpawner : UnityEngine.MonoBehaviour
{
	public int count;
	public float frequency;
	public float updateTime;

	public GameObject enemyPrefab;

	public Vector2 upPosition;
	public Vector2 downPosition;
	public Vector2 leftPosition;
	public Vector2 rightPosition;

	public Vector2 spread;

	public List<GameObject> list = new List<GameObject>();
	private int next = -1;

	public void Start()
	{
		for (int i = 0; i < count; i++)
		{
			GameObject spawn = Instantiate(enemyPrefab);
			list.Add(spawn);
			spawn.SetActive(false);
		}

		InvokeRepeating(nameof(Spawn), 0, updateTime);
	}

	private void Spawn()
	{
		int rand = Random.Range(0, 100);
		if (rand > frequency) return;

		Direction direction = RandomDirection();
		Vector2 position = GetPosition(direction);
		float xSpread = Random.Range(-spread.x, spread.x);
		float ySpread = Random.Range(-spread.y, spread.y);
		position.x += xSpread;
		position.y += ySpread;

		next++;
		if (next < list.Count)
		{
			GameObject spawn = list[next];
			spawn.transform.position = position;
			spawn.GetComponent<SpriteRenderer>().sortingOrder = next;
			spawn.SetActive(true);
			spawn.GetComponent<EnemyController>().direction = direction.Reverse();
		}
	}

	private Vector2 GetPosition(Direction direction)
	{
		switch (direction)
		{
			case Direction.Left:
				return leftPosition;
			case Direction.Right:
				return rightPosition;
			case Direction.Up:
				return upPosition;
			case Direction.Down:
				return downPosition;
			default:
				throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
		}
	}
}