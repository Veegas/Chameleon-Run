using UnityEngine;
using System.Collections;

public class ColorColliderManager : MonoBehaviour {
    private GameObject plane;
    public Material powerUpMaterial;
    public bool penalty = false;
    // Use this for initialization
	void Start () {
        plane = transform.Find("Center Plane").gameObject;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerStay(Collider other) {
        Color playerColor = PlayerScript.Instance.player.GetComponent<Renderer>().sharedMaterial.color;
        Material planeMaterial = plane.GetComponent<Renderer>().sharedMaterial;
        Color planeColor = planeMaterial.color;
        if (penalty) {
            return;
        }
        if (playerColor != planeColor && planeMaterial != powerUpMaterial) {
            StateManager.Instance.steppedOnWrongColor();
            AudioManager.Instance.playWrongColor();
            penalty = true;
        }
            
    }
}
