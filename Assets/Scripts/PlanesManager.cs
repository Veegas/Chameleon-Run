    using UnityEngine;
using System.Collections.Generic;

public class PlanesManager : MonoBehaviour {
    public GameObject currentPlane;
    public GameObject planesBase;
    public Material powerUpMaterial;


    private Queue<GameObject> visiblePlanes;

    private int numberOfPlanesPerScene = 1;




    public int powerUpDelay;
    private int planesTillPowerUp;


    public Material[] materials;

    private static PlanesManager instance;

    public static PlanesManager Instance {
        get {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<PlanesManager>();
            }
            return instance;
        }
    }

    // Use this for initialization
    void Start () {
        visiblePlanes = new Queue<GameObject>();
        visiblePlanes.Enqueue(currentPlane);
        for (int i = 0; i < 25; i++)  {
            createNewPlane();
        }

        planesTillPowerUp = powerUpDelay;


    }

    // Update is called once per frame
    void Update () {
	    
	}

    public void createNewPlane() {
        for (int i = 0; i < numberOfPlanesPerScene; i++) {
            currentPlane = (GameObject)Instantiate(planesBase, currentPlane.transform.GetChild(0).transform.GetChild(3).position, Quaternion.identity);
            visiblePlanes.Enqueue(currentPlane);

            int materialIndex = Random.Range(0, materials.Length);
            changePlaneColor(currentPlane, materials[materialIndex]);
            createPlaneItems();


            planesTillPowerUp--;    
        }
    }

    public void changePlaneColor(GameObject plane, Material material) {
        plane.transform.Find("Bottom Anchor").transform.Find("Left Plane").GetComponent<Renderer>().sharedMaterial = material;
        plane.transform.Find("Bottom Anchor").transform.Find("Center Plane").GetComponent<Renderer>().sharedMaterial = material;
        plane.transform.Find("Bottom Anchor").transform.Find("Right Plane").GetComponent<Renderer>().sharedMaterial = material;

    }
    public void createPlaneItems() {
        int bonusIndex = Random.Range(0, 3);
        if (planesTillPowerUp == 0) {
            createPowerUpItem(bonusIndex);
            planesTillPowerUp = powerUpDelay;
        } else {
            createBonusItem(bonusIndex);
        }

    }

    public void createBonusItem(int  bonusIndex) {
        Destroy(currentPlane.transform.Find("PowerUps").gameObject);
        for (int j = 0; j < 3; j++) {
            if (j == bonusIndex) {
                currentPlane.transform.Find("Bonuses").transform.GetChild(j).gameObject.SetActive(true);
            }
            else {
                Destroy(currentPlane.transform.Find("Bonuses").transform.GetChild(j).gameObject);
            }
        }
    }

    public void createPowerUpItem(int bonusIndex) {
        for (int j = 0; j < 3; j++) {
            if (j == bonusIndex) {
                currentPlane.transform.Find("PowerUps").transform.GetChild(j).gameObject.SetActive(true);
            }
            else {
                Destroy(currentPlane.transform.Find("PowerUps").transform.GetChild(j).gameObject);
            }
        }
    }
    public void DestroyPlaneFromQueue() {
        Destroy(visiblePlanes.Dequeue());
    }

    public GameObject getCurrentPlane() {
        return visiblePlanes.Peek();
    }

    public void changePlanesLight(Color color) {
        changeLightInPlane(planesBase, color);

        foreach (GameObject plane in visiblePlanes) {
            changeLightInPlane(plane, color);
        }
    }

    public void powerUpPlanes() {
        GameObject[] planes = visiblePlanes.ToArray();
        for (int i = 0; i < 10; i++) {
            powerUpPlane(planes[i]);
        }
    }

    void powerUpPlane(GameObject plane) {
        changePlaneColor(plane, powerUpMaterial);
    }

    void changeLightInPlane(GameObject plane, Color color) {
        plane.transform.Find("Lights").transform.Find("Left Front Lamp").transform.Find("Wall Light").GetComponent<Light>().color = color;
        plane.transform.Find("Lights").transform.Find("Left Back Lamp").transform.Find("Wall Light").GetComponent<Light>().color = color;
        plane.transform.Find("Lights").transform.Find("Right Front Lamp").transform.Find("Wall Light").GetComponent<Light>().color = color;
        plane.transform.Find("Lights").transform.Find("Right Back Lamp").transform.Find("Wall Light").GetComponent<Light>().color = color;

        plane.transform.Find("Lights").transform.Find("Center Up Light").GetComponent<Light>().color = color;
    }

}
