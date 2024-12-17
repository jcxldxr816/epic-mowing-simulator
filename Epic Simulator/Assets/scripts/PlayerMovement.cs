using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController controller;

    public float speed = 18f;
    public float gravity = -15f;
    public float jumpHeight = 3f;
    public bool strafe = true;
    public bool shiftHeld = false;

    [SerializeField] private Transform groundCheck;
    public float groundDistance = 2f;
    private LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    bool mowerMode = false;
    private KeyCode mowerKey = KeyCode.Q;
    private KeyCode liftMowerKey = KeyCode.LeftShift;
    private KeyCode emptyKey = KeyCode.G;

    private GameObject[] mowerModel;

    public GameObject camera;

    public GameObject mowerParent;
    public bool hilled = false;

    public Transform playerTransform;
    private Vector3 playerPos;
    private Quaternion currentRot;

    public GameObject[] hill;
    float dist;
    float tempDist = 9999999f;

    public GameObject canvas;

    public bool mowerFull = false;
    private bool inBinZone = false;
    public GameObject capacity;
    public GameObject fullText;

    private bool inHouse = false;

    [SerializeField] private KeyCode heightKey = KeyCode.H;
    private int height = 2;
    //[SerializeField] private GameObject grass;

    [SerializeField] private GameObject door;
    [SerializeField] private GameObject grassBag;
    [SerializeField] private Slider heightSlider;

    public void yardBinLogic(bool x)
    {
        if (x == true)
        {
            inBinZone = true;
        }
        else
        {
            inBinZone = false;
        }
    }

    public void hillLogic(float x, float z)
    {
        if (hilled == false)
        {
            mowerParent.transform.Rotate(x, 0, z, Space.World);
            hilled = true;
            //Debug.Log("hillLogic called (playerMovement side)");
        }
    }

    public void hillLeave(float x, float z)
    {
        if (hilled == true)
        {
            mowerParent.transform.Rotate(-x, 0, -z, Space.World);
            hilled = false;
            //Debug.Log("hillLeave called (playerMovement side)");
        }
    }

    public void controllerMoveToMower()
    {
        controller.center = new Vector3(0, 0, 5);
        controller.radius = 1.5f;
    }

    public void controllerMoveToPlayer()
    {
        controller.center = new Vector3(0, 0, 0);
        controller.radius = .6f;
    }

    public void stopPlayer()
    {
        mowerFull = true;
    }

    public void houseLogic(int x)
    {
        if (x == 0)
        {
            inHouse = true;
        }
        else
        {
            inHouse = false;
        }
    }

    public int getHeight()
    {
        //Debug.Log("getter object: " + gameObject.GetInstanceID());
        //Debug.Log("true getter: " + height);
        return height;
    }

    public void Start()
    {
        mowerModel = GameObject.FindGameObjectsWithTag("Mower");
        hill = GameObject.FindGameObjectsWithTag("hill");
        fullText.SetActive(false);

        currentRot = playerTransform.transform.rotation;
        //Debug.Log("current: " + playerPos);
        //Debug.Log("saved: " + savedPos);
        //Debug.Log("current rotation: " + currentRot);

        controller = GetComponent<CharacterController>();

        //Debug.Log("start object: " + gameObject.GetInstanceID());
    }
    
    // Update is called once per frame
    void Update()
    {
        playerPos = transform.position;
        tempDist = 9999999f;
        //Debug.Log("Height: " + height);
        //Debug.Log("update object: " + gameObject.GetInstanceID());

        if (Input.GetKeyUp(heightKey) && mowerMode == true && !Input.GetKeyDown(KeyCode.W) && !Input.GetKeyDown(KeyCode.S))
        {
            if (height == 0)
            {
                height = 2;
                // ui update to height stat
                heightSlider.value = 1;
            }
            else if (height == 1)
            {
                height = 0;
                // ui update to height stat
                heightSlider.value = 0;
            }
            else if (height == 2)
            {
                height = 1;
                // ui update to height stat
                heightSlider.value = .5f;
            }
            //Debug.Log("changed to: " + height);
        }

        foreach (GameObject i in hill)
        {
            //Debug.Log("Hill Pos: " + i.transform.position);
            dist = Vector3.Distance(i.transform.position, playerPos);
            //Debug.Log("Distance from hill to player " + dist);
            
            if (tempDist > dist)
            {
                tempDist = dist;
                //Debug.Log("tempDist after comparison: " + tempDist);
            }
        }

        if (hilled == true)
        {
            mowerKey = KeyCode.None;
            //Debug.Log("hilled");
        }
        else
        {
            mowerKey = KeyCode.Q;
        }

        if (Input.GetKeyDown(mowerKey) && !mowerFull && !inHouse)
        {
            if(mowerMode == false)
            {
                mowerMode = true;
                canvas.GetComponent<canvasStuff>().StatusChanger(1, 0, 0, 0);
                door.GetComponent<doorLogic>().isMower(true);
                controllerMoveToMower();
            }
            else
            {
                if (shiftHeld == false)
                {
                    mowerMode = false;
                    canvas.GetComponent<canvasStuff>().StatusChanger(0, 0, 1, 0);
                    door.GetComponent<doorLogic>().isMower(false);
                    controllerMoveToPlayer();
                }
            }
        }
        
        if (mowerMode == true)
        {
            if (Input.GetKeyDown(liftMowerKey) && hilled == false && !inHouse)
            {
                if (shiftHeld == false)
                {
                    shiftHeld = true;
                    canvas.GetComponent<canvasStuff>().StatusChanger(0, 1, 0, 0);
                    //Debug.Log("shift toggled");
                }
                else
                {
                    shiftHeld = false;
                    canvas.GetComponent<canvasStuff>().StatusChanger(0, 0, 0, 1);
                }
            }

            if (shiftHeld == true)
            {
                //Debug.Log("Shift Held");
                speed = 3f;
                jumpHeight = 0f;
                camera.GetComponent<mouselook>().mowerLookOff();
                camera.GetComponent<mouselook>().mowerLookShift(true);
                strafe = true;
                mowerKey = KeyCode.None;
            }
            else
            {
                speed = 12f; //MOWER SPEED LOCATED HERE *WINK WINK*
                jumpHeight = 0f;
                foreach (GameObject wi in mowerModel)
                {
                    wi.SetActive(true);
                }
                camera.GetComponent<mouselook>().mowerLook();
                camera.GetComponent<mouselook>().mowerLookShift(false);
                strafe = false;
                mowerKey = KeyCode.Q;
            }
        }

        if (mowerMode == false)
        {
            speed = 18f;
            jumpHeight = 3f;
            foreach (GameObject wi in mowerModel)
            {
                wi.SetActive(false);
            }
            camera.GetComponent<mouselook>().mowerLookOff();
            strafe = true;
        }


        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }


        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        if (strafe == false)
        {
            x = 0f;
        }

        if (mowerFull == true)
        {
            fullText.SetActive(true);
            mowerMode = false;
            shiftHeld = false;
            grassBag.SetActive(true);
            controllerMoveToPlayer();
            if (inBinZone == true)
            {
                if (Input.GetKeyDown(emptyKey))
                {
                    capacity.GetComponent<bagCapacity>().capEmpty();
                    //add timer here and emptying sound/animation.            also spawn in mower to replace disappearing playerModel mower------------------------------
                    mowerFull = false;
                    fullText.SetActive(false);
                }
            }
        }
        else
        {
            grassBag.SetActive(false);
        }

        if (inHouse == true)
        {
            mowerMode = false;
            shiftHeld = false;
        }

        Vector3 move = transform.right * x + transform.forward * z;

        //yt comment code
        if (move.magnitude > 1)
        {
            move /= move.magnitude;
        }

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);


    }
}
