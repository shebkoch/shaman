using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public float speed;
	private AnimController animController;
	private DeathComponent deathComponent;

	public void Start()
	{
		animController = GetComponent<AnimController>();
		deathComponent = GetComponent<DeathComponent>();
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Enemy"))
		{
			deathComponent.Death();
		}
	}

	
}