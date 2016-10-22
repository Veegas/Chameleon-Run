using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreUIManager : MonoBehaviour {
    Text scoreText;
    // Use this for initialization
    void Start () {
        scoreText = GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
        int score = StateManager.Instance.getScore();
        scoreText.text = "Score: " + score; 
        
	}
}
