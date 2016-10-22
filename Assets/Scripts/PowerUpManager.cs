using UnityEngine;
using System.Collections;

public class PowerUpManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other ) {
        Destroy(gameObject);
        PlanesManager.Instance.powerUpPlanes();
    }
}
