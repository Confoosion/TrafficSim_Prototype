using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Move : MonoBehaviour
{
    public GameObject car;
    public GameObject carShield;
    private float shieldBuffer;
    Rigidbody carRB;
    public Camera carCam;

    private bool isCarCrashed;

    public float defaultSpeed;
    private float jumpCooldown;

    [Space]
    [SerializeField] GameObject lostText;
    [SerializeField] GameObject restartButton;

    // Start is called before the first frame update
    void Start()
    {
        carRB = GetComponent<Rigidbody>();
        GlobalVariables.isDriving = true;
        carShield.SetActive(false);
        GlobalVariables.isShielded = false;
        shieldBuffer = 0f;
        GlobalVariables.jumps = 1;
        jumpCooldown = 0f;
        GlobalVariables.carSpeed = 0.2f;
        GlobalVariables.distance = 0;
        GlobalVariables.points = 0;
        GlobalVariables.multiplier = 1;
    }

    void Update()
    {
        // CHECK IF CAR IS NOT FALLING
        if(car.transform.position.y <= -1f)
        {
            GlobalVariables.isDriving = false;
        }
        // JUMP COOLDOWN
        if(jumpCooldown > 0f)
        {
            jumpCooldown -= Time.deltaTime;
            UI_Script.instance.jumpsCooldown.value = jumpCooldown;
        }
        if(GlobalVariables.isShielded)
        {
            carShield.SetActive(true);
        }
        if(shieldBuffer > 0f)
        {
            shieldBuffer -= Time.deltaTime;
        }
    }
    void FixedUpdate()
    {
        // STEER LEFT
        if(Input.GetKey(KeyCode.A))
        {
            carRotate(-0.1f);
        }
        
        // STEER RIGHT
        else if(Input.GetKey(KeyCode.D))
        {
            carRotate(0.1f);
        }
        
        // JUMP
        if(Input.GetKey(KeyCode.Space) && GlobalVariables.jumps != 0)
        {
            if(jumpCooldown <= 0f)
            {
                carRB.AddForce(Vector3.up * 400f);
                jumpCooldown = 5f;
                GlobalVariables.AddJumps(-1);
            }
        }
        // MOVE THE CAR
        car.transform.position = car.transform.position + new Vector3(car.transform.rotation.y * defaultSpeed, 0f, 0f);

        // CHECK IF CAR HAS CRASHED
        if(GlobalVariables.isDriving)
        {
            carCam.transform.position = new Vector3(car.transform.position.x, car.transform.position.y + 2.72f, car.transform.position.z - 7f);
        }
        else
        {
            carCam.transform.LookAt(car.transform);
        }

        // RESET SCENE
        if(Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    // STEERING FUNCTION
    void carRotate(float rotation)
    {
        // ROTATE CAR
        car.transform.Rotate(0f, rotation * 10f, 0f);

        // CAR CAM SWAY
        carCam.transform.Rotate(0f, rotation, 0f);

        //carRB.AddForce(rotation, 0f, 0f, ForceMode.VelocityChange);
    }

    // COLLISION CHECKING (FIX)
    void OnCollisionEnter(Collision collision)
    {
        // HITTING A CAR
        if(collision.gameObject.tag == "Car")
        {
            // WHEN SHIELDED
            if(GlobalVariables.isShielded)
            {
                //collision.rigidbody.AddForce(Vector3.up * 1000f);
                Destroy(collision.gameObject);
                RemoveShield();
                shieldBuffer = 0.25f;
            }
            // WHEN NOT SHIELDED AND BUFFER IS OVER
            else if(shieldBuffer <= 0f)
            {
                GlobalVariables.isDriving = false;
                carRB.AddForce(Vector3.up * 1000f);
                LostGame();
            }
        }
    }

    // REMOVES SHIELD AND SETS SHIELD VARIABLES TO DEFAULT
    void RemoveShield()
    {
        GlobalVariables.isShielded = false;
        carShield.SetActive(false);
    }

    void LostGame()
    {
        lostText.SetActive(true);
        restartButton.SetActive(true);
    }
}
