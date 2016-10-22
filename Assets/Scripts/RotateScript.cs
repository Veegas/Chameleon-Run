using UnityEngine;
using System.Collections.Generic;

public class RotateScript : MonoBehaviour {

    
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<Transform>().Rotate(0, 5, 0);
	}
}
