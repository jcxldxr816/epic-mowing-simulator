using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bagCapacity : MonoBehaviour
{
    public Text text;
    public int number;
    public GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        number = 0;
    }

    // Update is called once per frame
    void Update()
    {
        text.text = ("Capacity: " + number + "/300");
        if (number >= 300)
        {
            player.GetComponent<PlayerMovement>().stopPlayer();
        }
    }


    public void capChanger(int x)
    {
        number += x;
    }

    public void capEmpty()
    {
        number = 0;
    }
}
