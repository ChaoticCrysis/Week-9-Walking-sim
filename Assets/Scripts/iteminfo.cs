using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Allows Use of PLAYER script
public class iteminfo : MonoBehaviour
{

    public string itemName;
    public int itemValue;

    playerControl playerScript;


    // ?
    void Start()
    {
        playerScript = GameObject.Find("Player").GetComponent<playerControl>();
    }

    //DISPLAYS Text Over "KEY" Object
    void OnMouseOver()
    {
        Debug.Log(itemName);
        playerScript.itemText.text = itemName;
    }

    //Player PICKS "key" UP
    void OnMouseDown()
    {
        if (gameObject.name == "RedKey")
        {
            playerScript.hasRedKey = true;
        }
        else if(gameObject.name == "PurpleKey")
        {
            playerScript.hasPurpleKey = true;
        }
        else if(gameObject.name == "BlueKey")
        {
            playerScript.hasBlueKey = true;
        }
        Destroy(gameObject);
    }

    void Update()
    {
        
    }
}
