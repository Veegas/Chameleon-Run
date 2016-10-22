using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
    public float cameraDistOffset = 20;
    public float cameraHeightOffset = 20;
    private Camera mainCamera;
    private GameObject player;

    // Use this for initialization
    void Start()
    {
        mainCamera = GetComponent<Camera>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerInfo = player.transform.transform.position;
        mainCamera.transform.position = new Vector3(0, playerInfo.y + cameraHeightOffset, playerInfo.z - cameraDistOffset);
    }

    
}
