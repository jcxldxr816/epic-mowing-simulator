using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class secretTextTrigger : MonoBehaviour
{
    public GameObject trigger;
    public GameObject text;

    private void Start()
    {
        text.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        text.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        text.SetActive(false);
    }
}
