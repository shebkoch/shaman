using System;
using System.Collections.Generic;
using UnityEngine;

public class AnimController : MonoBehaviour
{
	[SerializeField] private String attackAnimationName;
	[SerializeField] private String walkAnimationName;
	[SerializeField] private String deathAnimationName;
	[SerializeField] private String aoeAnimationName;


	private Animator animator;

	public void Awake()
	{
		animator = GetComponent<Animator>();
	}

	public void Attack(Direction direction, bool replay = false)
	{
		Play(attackAnimationName + direction.GetName(), replay);
	}

	public void Walk(Direction direction)
	{
		Play(walkAnimationName + direction.GetName());
	}

	public void Death()
	{
		Play(deathAnimationName);
	}

	public void AOE()
	{
		Play(aoeAnimationName);
	}

	public void Play(String animation, bool replay = false)
	{
		if (replay)
			animator.Play(animation, -1, 0f);
		animator.Play(animation);
	}
}