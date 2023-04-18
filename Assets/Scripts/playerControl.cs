using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;




public class playerControl : MonoBehaviour
{
   
    //Camara base
    public float speed;



    public float upRotation;
    public float downRotation;



    CharacterController characterControl;
    public Transform playerCam;


    Vector3 vel;





    //Camara Senstivity
    public float lookSensitivity;

    float xRotation = 0;





    //Bullet Object
    public GameObject bulletPrefab;

    List<GameObject> bulletPool = new List<GameObject>();
    public int bulletNum;

    int bulletIndex = 0;


    //Makes Text appear on screen when camara is on object
    public TMP_Text itemText;
    public string lookingAt = "nothing";

    public bool hasKey = false;

    public bool hasRedKey;

    public bool hasPurpleKey;

    public bool hasBlueKey;



    playerControl playerScript;




    //Sprint 

    public bool isSprinting = false;
    public float sprintingMultiplier;





    // ?
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        characterControl = GetComponent<CharacterController>();
        itemText.text = lookingAt;
        CreateBulletPool();


    }





    // PLAYER Camara MOVEMENT
    void Update()
    {
        transform.Rotate(0, Input.GetAxis("Mouse X") * lookSensitivity, 0);
        xRotation -= Input.GetAxis("Mouse Y") * lookSensitivity;
        xRotation = Mathf.Clamp(xRotation, -upRotation, downRotation);
        playerCam.localRotation = Quaternion.Euler(xRotation, 0, 0);

        vel.z = Input.GetAxis("Vertical") * speed;
        vel.x = Input.GetAxis("Horizontal") * speed;

        vel = transform.TransformDirection(vel);
        characterControl.Move(vel * Time.deltaTime);

        if (Input.GetMouseButtonDown(0))
        {
            GameObject currentBullet = bulletPool[bulletIndex];
            currentBullet.SetActive(true);
            currentBullet.transform.position = transform.position;
            currentBullet.GetComponent<Rigidbody>().velocity = 2 * transform.forward;
            bulletIndex++;
            if (bulletIndex >= bulletPool.Count)
            {
                bulletIndex = 0;
            }



        }


        //Sprinting code pressing shift
        

        if (Input.GetKey(KeyCode.Space))
        {
            isSprinting= true;
        }
        else
        {
            isSprinting= false;
        }


        if (isSprinting == true)
        {
            speed = 20;
        }
        else
        {
            speed = 10;
        }



    }


    //group for bullets 
    void CreateBulletPool()
    {
        for (int i = 0; i < bulletNum; i++)
        {
            GameObject newBullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            newBullet.SetActive(false);
            bulletPool.Add(newBullet);
        }


    }
}