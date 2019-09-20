using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class MapGenerator : UnityEngine.MonoBehaviour
{
	public Transform parent;

	public GameObject path;
	public GameObject pathDots;
	public GameObject grass;
	public GameObject grassDots;
	public GameObject grassDots2;

	public float step;
	public float radius;
	public float radius2;
	public float chance;
	public float chanceGrass;
	public float chanceGrass2;

	public GameObject toSprite;
	public Texture2D texture2D;

	public void Start()
	{
		for (int x = -100; x < 100; x++)
		{
			for (int y = -100; y < 100; y++)
			{
				if (x * x + y * y < radius || x * x < radius2 || y * y < radius2)
				{
					int rand = Random.Range(0, 100);
					if (rand < chance)
						Create(pathDots, x, y);
					else
						Create(path, x, y);
				}
				else
				{
					int rand = Random.Range(0, 100);
					if (rand < chanceGrass)
						Create(grassDots, x, y);
					else if (rand < chanceGrass + chanceGrass2)
						Create(grassDots2, x, y);
					else
						Create(grass, x, y);
				}
			}
		}

//		Test.Create(Vector2Int.one, parent);
	}

	public void Update()
	{
		if (Input.GetKey(KeyCode.R)) Application.LoadLevel(0);
		if (Input.GetKey(KeyCode.I))
		{
//			Test.SaveSpriteToEditorPath(test1, "Assets/Sprites/Complete.png");
		}
	}

	private void Create(GameObject obj, int x, int y)
	{
		Instantiate(obj, new Vector3(x * step, y * step, 0), Quaternion.identity, parent);
	}
}