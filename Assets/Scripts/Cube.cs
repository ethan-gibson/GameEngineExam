using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

public class Cube : MonoBehaviour
{
	private bool isMoving;
	private bool grounded;
	public IObjectPool<Cube> Pool;
	public void ReturnToPool()
	{
		Pool.Release(this);
	}

	void FixedUpdate()
	{
		if (!Physics.Raycast(transform.position, Vector3.down, 0.5f) && !isMoving)
		{
			StartCoroutine(moveDown());
		}
		if (Physics.Raycast(transform.position, Vector3.down, 0.5f) && !grounded)
		{
			Debug.Log("Grounded");
			grounded = true;
			noLongerControlable();
		}
	}

	private void noLongerControlable()
	{
		GameBoard.Instance.SpawnCube();
	}

	private IEnumerator moveDown()
	{
		isMoving = true;
		yield return new WaitForSeconds(1);
		transform.position += Vector3.down;
		isMoving = false;
	}
}
