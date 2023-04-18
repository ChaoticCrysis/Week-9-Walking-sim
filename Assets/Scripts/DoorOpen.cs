using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DoorOpen : MonoBehaviour
{
    playerControl playerScript;

    public bool RedKey;


    public bool PurpleKey;

    public bool BlueKey;


    // Allows Interaction between DOOR and PLAYER
    void Start()
    {
        playerScript = GameObject.Find("Player").GetComponent<playerControl>();
    }

    //Allows Player to OPEN door with KEY "destroyed"
    void OnMouseDown()
    {
        if(RedKey && playerScript.hasRedKey)
        {
            Destroy(gameObject);
        }

        else if(PurpleKey && playerScript.hasPurpleKey)
        {
            Destroy(gameObject);
        } 
        else if(BlueKey && playerScript.hasBlueKey)
        {
            Destroy(gameObject);
        }
        
       
    }


    void Update()
    {
        
    }
}
