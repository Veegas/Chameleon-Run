using UnityEngine;
using System.Collections;

public class BonusManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
    }

    void OnTriggerEnter(Collider other) {
        collectedBonus();
    }   

    void collectedBonus() {
        Destroy(gameObject);
        AudioManager.Instance.playPickupBonus();
        StateManager.Instance.addScore();
    }
}
