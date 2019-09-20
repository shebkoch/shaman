using System;
using UnityEngine;

public class ManaBall : UnityEngine.MonoBehaviour
{
	public Vector3 position;
	public float autoTime;
	public float distance;
	public float speed;

	private bool isCollect = false;

	public void OnEnable()
	{
		Invoke(nameof(Collect), autoTime);
	}

	public void OnMouseDown()
	{
		SwipeController.isAoeNeed = false;
		SwipeController.isAttackNeed = false;
		Collect();
	}

	private void Collect()
	{
		isCollect = true;
	}

	public void Update()
	{
		if (!isCollect) return;

		if (Vector3.Distance(transform.position, position) > distance)
		{
			float step = speed * Time.deltaTime;
			transform.position = Vector3.MoveTowards(transform.position, position, step);
		}
		else
		{
			AttackComponent.Instance.ManaGain();
			gameObject.SetActive(false);
		}
	}
}