using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour {
    private AudioSource BackgroundMusic;
    private AudioSource PickupBonus;
    private AudioSource PickupPowerUp;
    private AudioSource WrongColor;

    private static AudioManager instance;

    public static AudioManager Instance {
        get {
            return instance;
        }
    }

    //Awake is always called before any Start functions
    void Awake() {
        //Check if instance already exists
        if (instance == null)

            //if not, set instance to this
            instance = this;

        //If instance already exists and it's not this:
        else if (instance != this)

            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);

        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);
    }
    // Use this for initialization
    void Start () {
        BackgroundMusic = gameObject.transform.Find("Background Music").GetComponent<AudioSource>();
        PickupBonus = gameObject.transform.Find("Pickup Bonus").GetComponent<AudioSource>();
        WrongColor = gameObject.transform.Find("Wrong Color").GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void playBackgroundMusic() {
        BackgroundMusic.Play();
    }

    public void playPickupBonus() {
        PickupBonus.Play();
    }
    public void playWrongColor() {
        WrongColor.Play();
    }
}
