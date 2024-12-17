using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canvasStuff : MonoBehaviour
{
    public GameObject stand;
    public GameObject mow;
    public GameObject lift;

    

    // Start is called before the first frame update
    void Start()
    {
        stand.SetActive(true);
        mow.SetActive(false);
        lift.SetActive(false);
    }

    public void StatusChanger(int a, int b, int c, int d)
    {
        if (a > 0)
        {
            stand.SetActive(false);
            mow.SetActive(true);
        }

        if (b > 0)
        {
            mow.SetActive(false);
            lift.SetActive(true);
        }

        if (c > 0)
        {
            mow.SetActive(false);
            stand.SetActive(true);
        }

        if (d > 0)
        {
            lift.SetActive(false);
            mow.SetActive(true);
        }

        a = 0;
        b = 0;
        c = 0;
        d = 0;
    }
}
