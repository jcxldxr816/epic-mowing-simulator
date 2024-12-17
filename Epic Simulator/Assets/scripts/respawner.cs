using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class respawner : MonoBehaviour
{
    public Transform player;
    public Transform respawnPoint;
    public GameObject text;

    private void Start()
    {
        text.SetActive(false);
    }
    public void OnTriggerEnter(Collider other)
    {
        player.transform.position = respawnPoint.transform.position;
        StartCoroutine(timer());
        IEnumerator timer()
        {
            text.SetActive(true);
            yield return new WaitForSecondsRealtime(5);
            text.SetActive(false);
        }
    }
}
