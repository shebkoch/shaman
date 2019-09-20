using System;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
	public Vector2 target;
	public float speed = 1.0f;
	public float distance;

	[HideInInspector] public Direction direction;

	private AnimController animController;

	public void Awake()
	{
		animController = GetComponent<AnimController>();
	}

	public void Update()
	{
		if (Vector3.Distance(transform.position, target) > distance)
		{
			animController.Walk(direction);
			float step = speed * Time.deltaTime;
			transform.position = Vector3.MoveTowards(transform.position, target, step);
		}
		else
		{
			animController.Attack(direction);
		}
	}
}