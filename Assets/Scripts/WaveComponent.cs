using System;
using UnityEngine;

public class WaveComponent : UnityEngine.MonoBehaviour
{
	public float existTime;

	public void OnEnable()
	{
		Invoke(nameof(Disable), existTime);
	}

	public void Disable()
	{
		gameObject.SetActive(false);
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Enemy"))
		{
			DeathComponent deathComponent = other.GetComponent<DeathComponent>();
			if (deathComponent) deathComponent.Death();
		}
	}
}