using UnityEngine;
using System.Collections.Generic;

public class PlayerScript : MonoBehaviour {
    private static PlayerScript instance;
    public GameObject player;
    private Rigidbody playerRigidBody;
    public float jumpForce;
    private float distanceToGround;
    private CharacterController playerController;
    private bool isJumping = false;
    private bool isMovingRight = false;
    private bool isMovingLeft = false;
    public float velocity;
    public float gravity;
    private int timeToLevelUp = 10;
    private float currentLevelUpTime;
    private Vector3 moveDirection = Vector3.zero;
    public static PlayerScript Instance {
        get {
            if (instance == null) {
                instance = GameObject.FindObjectOfType<PlayerScript>();
            }
            return instance;
        }
    }

    //Awake is always called before any Start functions

    void Start () {
        playerRigidBody = player.GetComponent<Rigidbody>();
        playerController = player.GetComponent<CharacterController>();
        distanceToGround = this.GetComponent<Collider>().bounds.extents.y;
        currentLevelUpTime = timeToLevelUp;
    }

    // Update is called once per frame
    void Update () {
        checkKeyboard();
        moveForward();
        manageLevelUp();
    }
    


    void checkKeyboard() {
        if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            moveLeft();
        }

        if (Input.GetKeyDown(KeyCode.RightArrow)) {
            moveRight();
        }

        if (Input.GetKeyDown(KeyCode.Space)) {
            isJumping = true;
        }

        if (Input.GetKeyDown(KeyCode.Q)) {
            changePlayerColor(2);
        }

        if (Input.GetKeyDown(KeyCode.W)) {
            changePlayerColor(0);
        }
        if (Input.GetKeyDown(KeyCode.E)) {
            changePlayerColor(1);
        }
    }

    void manageLevelUp() {
        if (currentLevelUpTime <= 0) {
            levelUp();
            currentLevelUpTime = timeToLevelUp;
        } else {
            currentLevelUpTime -= Time.deltaTime;
        }
    }

    void levelUp() {
        velocity += 0.05f;
    }

    void moveForward() {
        if (playerController.isGrounded) {
            moveDirection = new Vector3(0, 0, velocity);
            if (isJumping) {
                moveDirection.y = jumpForce;
                isJumping = false;
            }

            GameObject currentPlane = PlanesManager.Instance.getCurrentPlane();
            GameObject LeftLane = currentPlane.transform.Find("Bottom Anchor").transform.Find("Left Plane").gameObject;
            GameObject RightLane = currentPlane.transform.Find("Bottom Anchor").transform.Find("Right Plane").gameObject;
            GameObject CenterLane = currentPlane.transform.Find("Bottom Anchor").transform.Find("Center Plane").gameObject;

            if (isMovingRight) {
                moveDirection.x = RightLane.transform.position.x;
                isMovingRight = false;
            }
            if (isMovingLeft) {
                moveDirection.x = LeftLane.transform.position.x;
                isMovingLeft = false;
            }
        }

        moveDirection.y -= gravity * Time.deltaTime;
        playerController.Move(moveDirection);
    }

    void moveLeft() {
        GameObject currentPlane = PlanesManager.Instance.getCurrentPlane();
        GameObject LeftLane = currentPlane.transform.Find("Bottom Anchor").transform.Find("Left Plane").gameObject;
        GameObject RightLane = currentPlane.transform.Find("Bottom Anchor").transform.Find("Right Plane").gameObject;
        GameObject CenterLane = currentPlane.transform.Find("Bottom Anchor").transform.Find("Center Plane").gameObject;

        if (transform.position.x < RightLane.transform.position.x + 1 && transform.position.x > RightLane.transform.position.x - 1) {
            isMovingLeft = true;
            return;
        }

        if (transform.position.x < CenterLane.transform.position.x + 1 && transform.position.x > CenterLane.transform.position.x - 1) {
            isMovingLeft = true;
            return;
        }
        
    }

    void moveRight() {
        GameObject currentPlane = PlanesManager.Instance.getCurrentPlane();
        GameObject LeftLane = currentPlane.transform.Find("Bottom Anchor").transform.Find("Left Plane").gameObject;
        GameObject RightLane = currentPlane.transform.Find("Bottom Anchor").transform.Find("Right Plane").gameObject;
        GameObject CenterLane = currentPlane.transform.Find("Bottom Anchor").transform.Find("Center Plane").gameObject;

        
        if (transform.position.x < LeftLane.transform.position.x + 1 && transform.position.x > LeftLane.transform.position.x - 1) {
            //transform.position = new Vector3(CenterLane.transform.position.x, transform.position.y, transform.position.z);
            isMovingRight = true;
            return;
        } 

        if (transform.position.x < CenterLane.transform.position.x + 1 && transform.position.x > CenterLane.transform.position.x - 1) {
            //transform.position = new Vector3(RightLane.transform.position.x, transform.position.y, transform.position.z);
            isMovingRight = true;
            return;
        }
    }


    void changePlayerColor(int index) {
        StateManager.Instance.changeColor(index);
    }

    public void disablePlayerMovement() {
        playerController.GetComponent<CharacterController>().enabled = false;
    }

    public void enablePlayerMovement() {
        playerController.GetComponent<CharacterController>().enabled = true;
    }


}
