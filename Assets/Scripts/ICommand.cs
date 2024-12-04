using UnityEngine;

public interface ICommand
{
	public static void ExecuteMove(string direction, GameObject peice)
	{
		switch (direction)
		{
			case "Left":
				peice.transform.position += Vector3.left;
				break;
			case "Right":
				peice.transform.position += Vector3.right;
				break;
		}
	}
}
