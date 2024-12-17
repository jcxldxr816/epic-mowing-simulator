using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class doorLogic : MonoBehaviour
{
    private bool openable = false;
    private bool opened = false;
    private bool mowerMode = false;

    [SerializeField] private Transform doorHinge;
    [SerializeField] private Transform door;
    [SerializeField] private GameObject ePrompt;
    [SerializeField] private GameObject player;
    private AudioSource doorAudio;


    // Start is called before the first frame update
    void Start()
    {
        ePrompt.SetActive(false);
        doorAudio = (AudioSource)gameObject.GetComponentInChildren(typeof(AudioSource));
        doorAudio.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if(!mowerMode)
        {
            if (openable == true)
            {
                ePrompt.SetActive(true);
                player.GetComponent<PlayerMovement>().houseLogic(0);
            }
            else
            {
                ePrompt.SetActive(false);
                player.GetComponent<PlayerMovement>().houseLogic(1);
            }

            if (openable == true && Input.GetKeyDown(KeyCode.E) && opened == false)
            {
                doorAudio.Stop();
                door.RotateAround(doorHinge.transform.position, Vector3.up, -90);
                opened = true;
                doorAudio.Play();
            }
            else if (openable == true && Input.GetKeyDown(KeyCode.E) && opened == true)
            {
                doorAudio.Stop();
                door.RotateAround(doorHinge.transform.position, Vector3.up, 90);
                opened = false;
                doorAudio.Play();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        openable = true;
    }
    private void OnTriggerExit(Collider other)
    {
        openable = false;
    }

    public void isMower(bool x)
    {
        if (x == true)
        {
            mowerMode = true;
        }
        else
        {
            mowerMode = false;
        }
    }
}
