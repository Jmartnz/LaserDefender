using UnityEngine;
using TMPro;

public class ScoreDisplay : MonoBehaviour {

	private TextMeshProUGUI scoreText;
	private LevelManager levelManager;

	// Use this for initialization
	void Start () {
		scoreText = GetComponent<TextMeshProUGUI>();
        levelManager = FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
        scoreText.SetText(levelManager.GetScore().ToString());
	}
}
