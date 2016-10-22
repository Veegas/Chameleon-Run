using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections.Generic;

public class StateManager : MonoBehaviour {
    private static StateManager instance;
    private int score = 0;
    public Color[] availableGameColors;
    public Queue<Color> gameColors;
    private Color currentColor;
    private int currentColorIndex;
    private bool isPaused = false;
    private int highScore = 0;
    private bool noDeath = true;

    public static StateManager Instance {
        get {
            if (instance == null) {
                instance = GameObject.FindObjectOfType<StateManager>();
            }
            return instance;
        }
    }

    //Awake is always called before any Start functions


    // Use this for initialization
    void Start () {
        changeColor(0);
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (!isPaused) {
                pauseGame();
                showPauseUI();
            } else {
                resumeGame();
            }
        }
    }

    public void addScore() {
        if (noDeath) {
            noDeath = false;
        }
        score+= 20;
        if (score > highScore) {
            highScore = score;
        }
    }

    public int getScore() {
        return score;
    }

    public void changeColor(int index) {
        currentColor = availableGameColors[index];

        PlanesManager.Instance.changePlanesLight(currentColor);
        PlayerScript.Instance.player.GetComponent<Renderer>().sharedMaterial.color = currentColor;
        GlobalLightsManager.Instance.changeLightColor(currentColor);
    }

    public void steppedOnWrongColor() {
        score = score / 2;
        if (score <= 0 && !noDeath) {
            gameOver();
        }
    }

    public int getHighscore() {
        return highScore;
    }

    void gameOver() {
        Time.timeScale = 0;
        PlayerScript.Instance.disablePlayerMovement();

        showGameOverUI();
    }

    public void pauseGame() {
        isPaused = !isPaused;
        showPauseUI();

        Time.timeScale = 0;
        PlayerScript.Instance.disablePlayerMovement();
    }
    public void resumeGame() {
        isPaused = !isPaused;
        showPlayUI();

        Time.timeScale = 1;
        PlayerScript.Instance.enablePlayerMovement();
    }

    public void restartGame() {
        Time.timeScale = 1;
        PlayerScript.Instance.enablePlayerMovement();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void quitGame() {
        Application.Quit();
    }

    public void showPauseUI() {
        GameObject parent = GameObject.FindGameObjectWithTag("UI Elements");
        GameObject playCanvas = parent.transform.Find("Play Canvas").gameObject;
        GameObject pauseCanvas = parent.transform.Find("Pause Canvas").gameObject;
        GameObject GameoverCanvas = parent.transform.Find("Gameover Canvas").gameObject;

        pauseCanvas.SetActive(true);
        playCanvas.SetActive(false);
        GameoverCanvas.SetActive(false);
    }

    public void showPlayUI() {
        GameObject parent = GameObject.FindGameObjectWithTag("UI Elements");
        GameObject playCanvas = parent.transform.Find("Play Canvas").gameObject;
        GameObject pauseCanvas = parent.transform.Find("Pause Canvas").gameObject;
        GameObject GameoverCanvas = parent.transform.Find("Gameover Canvas").gameObject;
        pauseCanvas.SetActive(false);
        playCanvas.SetActive(true);
        GameoverCanvas.SetActive(false);
    }

    public void showGameOverUI() {
        GameObject parent = GameObject.FindGameObjectWithTag("UI Elements");
        GameObject playCanvas = parent.transform.Find("Play Canvas").gameObject;
        GameObject pauseCanvas = parent.transform.Find("Pause Canvas").gameObject;
        GameObject GameoverCanvas = parent.transform.Find("Gameover Canvas").gameObject;
        GameoverCanvas.transform.Find("Score").GetComponent<Text>().text = "Score: " + highScore.ToString();
        GameoverCanvas.SetActive(true);
        playCanvas.SetActive(false);
        pauseCanvas.SetActive(false);
    }







}
