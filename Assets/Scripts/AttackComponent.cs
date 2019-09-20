using System;
using UnityEngine;
using UnityEngine.UI;

public class AttackComponent : MonoBehaviour
{
	public AnimController playerAnim;
	public AnimController waveUpAnim;
	public AnimController waveLeftAnim;
	public AnimController waveRightAnim;
	public AnimController waveDownAnim;
	public AnimController waveAOE;

	public GameObject waveUp;
	public GameObject waveDown;
	public GameObject waveLeft;
	public GameObject waveRight;

	public bool isAlive;
	public float mana;
	public float maxMana;
	public float manaPerAttack;
	public float manaPerAoeAttack;
	public float manaGain;

	public Image bar;

	public static AttackComponent Instance;

	private void Awake()
	{
		playerAnim = GetComponent<AnimController>();
		Instance = this;
	}

	public void ManaGain()
	{
		mana += manaGain;
	}

	public void Update()
	{
		bar.fillAmount = mana / (float) maxMana;
	}

	public void Attack(Direction direction)
	{
		if (mana - manaPerAttack < 0) return;

		mana -= manaPerAttack;
		if (!isAlive) return;
		Wave(direction);
		playerAnim.Attack(direction);
		WaveAnim(direction);
	}

	public void AOEAttack()
	{
		if (mana - manaPerAoeAttack < 0) return;

		mana -= manaPerAoeAttack;
		if (!isAlive) return;
		AOE();

		waveAOE.Attack(Direction.Up, true);
	}

	public void DelayAnim()
	{
		if (!isAlive) return;
		playerAnim.AOE();
	}

	private void WaveAnim(Direction direction)
	{
		switch (direction)
		{
			case Direction.Left:
				waveLeftAnim.Attack(direction, true);
				break;
			case Direction.Right:
				waveRightAnim.Attack(direction, true);
				break;
			case Direction.Up:
				waveUpAnim.Attack(direction, true);
				break;
			case Direction.Down:
				waveDownAnim.Attack(direction, true);
				break;
			default:
				throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
		}
	}

	private void AOE()
	{
		Wave(Direction.Down);
		Wave(Direction.Right);
		Wave(Direction.Up);
		Wave(Direction.Left);
	}

	private void Wave(Direction direction)
	{
		switch (direction)
		{
			case Direction.Left:
				waveLeft.SetActive(true);
				break;
			case Direction.Right:
				waveRight.SetActive(true);
				break;
			case Direction.Up:
				waveUp.SetActive(true);
				break;
			case Direction.Down:
				waveDown.SetActive(true);
				break;
			default:
				throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
		}
	}
}