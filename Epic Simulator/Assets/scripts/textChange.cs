using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textChange : MonoBehaviour
{
    public Text remainingText;

    GameObject plotObj;

    private void Start()
    {
        plotObj = GameObject.FindGameObjectWithTag("grassPlot");
    }

    // Update is called once per frame
    void Update()
    {
        remainingText.text = ("Yard Mowed: " + plotObj.GetComponent<yardRules>().getPercent().ToString() + "%");
    }
}
