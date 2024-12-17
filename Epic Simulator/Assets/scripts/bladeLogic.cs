using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bladeLogic : MonoBehaviour
{
    public GameObject mower;

    public ParticleSystem grassShavings;



    public void Start()
    {
        grassShavings = GetComponent<ParticleSystem>();
        grassShavings.Stop();


        //em = ps.emission;
        //em.enabled = false;

    }

    public void PartMowerEnabled()
    {
        //Debug.Log("particles enabled");
        grassShavings.Play();
        //new WaitForSecondsRealtime(2);
        //Debug.Log("waiting");
        //grassShavings.Stop();
        //Debug.Log("Particles disabled");
    }

}
