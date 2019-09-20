using System;
using UnityEngine;

public class SwipeController : UnityEngine.MonoBehaviour
{
	public AttackComponent attackComponent;

	public float timeToAoe;
	public float timeToAoeCast;

	private float startTime;
	private Vector3 startPosition;

	public static bool isAoeNeed;
	public static bool isAttackNeed;

	void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			startPosition = Input.mousePosition;
			startTime = Time.realtimeSinceStartup;
			isAoeNeed = true;
			isAttackNeed = true;
		}

		if (isAoeNeed && Time.realtimeSinceStartup - startTime > timeToAoeCast)
		{
			attackComponent.DelayAnim();
		}

		if (isAoeNeed && Time.realtimeSinceStartup - startTime > timeToAoe)
		{
			attackComponent.AOEAttack();
			isAoeNeed = false;
			isAttackNeed = false;
		}

		Vector3 direction = Vector3.zero;
		if (isAttackNeed && Input.GetMouseButtonUp(0))
		{
			direction = startPosition - Input.mousePosition;
			isAoeNeed = false;
		}

		if (direction != Vector3.zero)
		{
			bool isHorizontal = Mathf.Abs(direction.x) > Mathf.Abs(direction.y);
			if (isHorizontal)
			{
				attackComponent.Attack(direction.x < 0 ? Direction.Right : Direction.Left);
			}
			else
			{
				attackComponent.Attack(direction.y < 0 ? Direction.Up : Direction.Down);
			}
		}
	}
}