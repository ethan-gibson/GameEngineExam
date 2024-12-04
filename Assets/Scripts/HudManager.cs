using TMPro;
using UnityEngine;

public class HudManager : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI ScoreText;
	private int score;
	private int awardedPoints = 1000;
	void OnEnable()
	{
		ScoreText.text = "Score: " + 0;
		GameBoard.RowComplete += UpdateScore;
	}

	private void UpdateScore()
	{
		score += awardedPoints;
		ScoreText.text = "Score: " + score;
	}
}
