using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class DeathComponent : UnityEngine.MonoBehaviour
{
	private AnimController animController;

	[SerializeField] private float deathTime;

	public float manaChance;
	public GameObject manaObj;

	private void Awake()
	{
		animController = GetComponent<AnimController>();
	}

	public void Death()
	{
		var attackComponent = GetComponent<AttackComponent>();
		if (attackComponent)
			attackComponent.isAlive = false;
		DisableComponent<EnemyController>();
		DisableComponent<PlayerController>();
		DisableComponent<AttackComponent>();
		DisableComponent<Collider2D>();

		animController.Death();
		Invoke(nameof(RealDeath), deathTime);
		if (Random.Range(0, 100) < manaChance)
			Instantiate(manaObj, transform.position, Quaternion.identity);
		if (gameObject.CompareTag("Player"))
		{
			Invoke(nameof(Show), 3f);
		}
	}
	public void Show()
	{
		GameContoller.instanse.Show();
	}

	private void DisableComponent<T>() where T : Behaviour
	{
		T component = GetComponent<T>();
		if (component) Destroy(component);
	}

	private void RealDeath()
	{
		gameObject.SetActive(false);
	}
}