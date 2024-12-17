using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class iAmHill : MonoBehaviour
{
    public GameObject player;
    public GameObject hill;

    public float hillangleX;
    public float hillangleZ;


    // Start is called before the first frame update
    void Start()
    {
        hillangleX = hill.transform.localRotation.eulerAngles.x;
        hillangleZ = hill.transform.localRotation.eulerAngles.z;
        Debug.Log("y: " + hillangleX + " z: " + hillangleZ);
    }

    public void OnCollisionEnter(Collision other)
    {
        Debug.Log("Collision w hill");
        if (hillangleX > 0 || hillangleZ > 0)
        {
            player.GetComponent<PlayerMovement>().hillLogic(hillangleX, hillangleZ); //replaced player with other
        }
    }

    public void OnCollisionExit(Collision other)
    {
        Debug.Log("Collision w hill ended");
        player.GetComponent<PlayerMovement>().hillLeave(hillangleX, hillangleZ);
    }
    
}
