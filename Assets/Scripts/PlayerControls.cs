using UnityEngine;

public class PlayerControls : MonoBehaviour
{
	public GameObject activePeice;
	public static PlayerControls Instance;
	void Awake()
	{
		if (Instance != null && Instance != this)
		{
			Destroy(this);
		}
		Instance = this;
	}
	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.A) && activePeice.transform.position.x > -4)
		{
			ICommand.ExecuteMove("Left", activePeice);
		}
		if (Input.GetKeyDown(KeyCode.D)&& activePeice.transform.position.x < 3)
		{
			ICommand.ExecuteMove("Right", activePeice);
		}
	}
	public void SetActivePeice(GameObject obj)
	{
		activePeice = obj;
	}

}
