using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class binTriggerLogic : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private void OnTriggerEnter(Collider other)
    {
        player.GetComponent<PlayerMovement>().yardBinLogic(true);
        Debug.Log("Bin Zone entered");
    }
    private void OnTriggerExit(Collider other)
    {
        player.GetComponent<PlayerMovement>().yardBinLogic(false);
        Debug.Log("Bin Zone exit");
    }
}
