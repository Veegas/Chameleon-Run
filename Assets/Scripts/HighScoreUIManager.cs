using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HighScoreUIManager : MonoBehaviour {
    Text highScoreText;
    // Use this for initialization
    void Start () {
        highScoreText = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        int score = StateManager.Instance.getHighscore();
        highScoreText.text = "Highscore: " + score;
    }
}
