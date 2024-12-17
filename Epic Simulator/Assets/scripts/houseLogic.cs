using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class houseLogic : MonoBehaviour
{
    public GameObject player;

    private void OnTriggerEnter(Collider other)
    {
        player.GetComponent<PlayerMovement>().houseLogic(0);
    }
    private void OnTriggerExit(Collider other)
    {
        player.GetComponent<PlayerMovement>().houseLogic(1);
    }

}
