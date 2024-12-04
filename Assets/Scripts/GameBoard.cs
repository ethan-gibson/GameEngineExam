using System.Collections.Generic;
using UnityEngine;

public class GameBoard : MonoBehaviour
{
	public delegate void RowCompleteDelegate();
	public static RowCompleteDelegate RowComplete;
	private List<GameObject> objectsInRow = new();
	[SerializeField] private List<GameObject> firingPoints = new();
	[SerializeField] private List<GameObject> spawnPoints = new();
	private CubePool cubePool;
	public static GameBoard Instance;
	void Awake()
	{
		if (Instance != null && Instance != this)
		{
			Destroy(this);
		}
		Instance = this;
	}

	private void Start()
	{
		cubePool = GetComponent<CubePool>();
		SpawnCube();
	}

	// Update is called once per frame
	void Update()
	{
		CheckRow();
	}

	public void SpawnCube()
	{
		cubePool.Spawn(spawnPoints[Random.Range(0, spawnPoints.Count)].transform.position);
	}

	private void CheckRow()
	{
		int hitCount = 0;
		foreach (GameObject obj in firingPoints)
		{
			Debug.DrawRay(obj.transform.position, Vector3.forward * 10);
			if (Physics.Raycast(obj.transform.position, Vector3.forward, 10))
			{
				hitCount++;
			}
		}

		if (hitCount == 2)
		{
			CompleteRow();
		}
	}
	private void CompleteRow()
	{
		foreach (GameObject obj in objectsInRow)
		{
			var tempObj = obj;
			objectsInRow.Remove(tempObj);
			tempObj.GetComponent<Cube>().ReturnToPool();
		}
		RowComplete?.Invoke();
	}
}


