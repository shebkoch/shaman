using System;

public enum Direction
{
	Left,
	Right,
	Up,
	Down
}

public static class DirectionExtension
{
	public static String GetName(this Direction direction)
	{
		switch (direction)
		{
			case Direction.Left:
				return "left";
			case Direction.Right:
				return "right";
			case Direction.Up:
				return "up";
			case Direction.Down:
				return "down";
			default:
				throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
		}
	}

	public static Direction RandomDirection()
	{
		int rand = UnityEngine.Random.Range(0, 4);
		Direction randomDirection;
		switch (rand)
		{
			case 0:
				randomDirection = Direction.Down;
				break;
			case 1:
				randomDirection = Direction.Up;
				break;
			case 2:
				randomDirection = Direction.Left;
				break;
			case 3:
				randomDirection = Direction.Right;
				break;
			default: throw new ArgumentOutOfRangeException(nameof(randomDirection), rand, null);
		}

		return randomDirection;
	}

	public static Direction Reverse(this Direction direction)
	{
		switch (direction)
		{
			case Direction.Left:
				return Direction.Right;
			case Direction.Right:
				return Direction.Left;
			case Direction.Up:
				return Direction.Down;
			case Direction.Down:
				return Direction.Up;
			default:
				throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
		}
	}
}