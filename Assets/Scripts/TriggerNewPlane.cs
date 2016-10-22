using UnityEngine;
using System.Collections;

public class TriggerNewPlane : MonoBehaviour {



    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

        void OnTriggerExit(Collider collider) {
            if (collider.tag == "Player") {
                PlanesManager.Instance.createNewPlane();
                PlanesManager.Instance.DestroyPlaneFromQueue();
            } 
    }

}

