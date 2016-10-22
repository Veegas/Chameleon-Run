using UnityEngine;
using System.Collections.Generic;

public class GlobalLightsManager : MonoBehaviour {
    private static GlobalLightsManager instance;

    public static GlobalLightsManager Instance {
        get {
            if (instance == null) {
                instance = GameObject.FindObjectOfType<GlobalLightsManager>();
            }
            return instance;
        }
    }


    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void changeLightColor(Color color) {
        Light light = GetComponent<Light>();
        light.color = color;
    }
}
