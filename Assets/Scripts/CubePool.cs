using UnityEngine;
using UnityEngine.Pool;

public class CubePool : MonoBehaviour
{
	[SerializeField] private int MaxPoolSize = 100;
	[SerializeField] private int StackCap = 100;
	[SerializeField] private GameObject cube;

	public IObjectPool<Cube> Pool
	{
		get
		{
			if (_pool == null)
			{
				_pool = new ObjectPool<Cube>(
					CreatePooledItems,
					OnTakeFromPool,
					OnReturnedToPool,
					OnDestroyCube, true,
					StackCap,
					MaxPoolSize
				);
			}
			return _pool;
		}
	}
	private IObjectPool<Cube> _pool;
	private Cube CreatePooledItems()
	{
		var tempCube = Instantiate(cube, transform);
		tempCube.GetComponent<Cube>().Pool = Pool;
		return tempCube.GetComponent<Cube>();
	}
	private void OnReturnedToPool(Cube cube)
	{
		cube.gameObject.SetActive(false);
	}
	private void OnTakeFromPool(Cube cube)
	{
		cube.gameObject.SetActive(true);
	}
	private void OnDestroyCube(Cube cube)
	{
		Destroy(cube.gameObject);
	}
	public void Spawn(Vector3 spawnPoint)
	{
		var tempCube = Pool.Get();
		tempCube.transform.position = spawnPoint;
		PlayerControls.Instance.activePeice = tempCube.gameObject;
	}
}
