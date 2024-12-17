using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grassDetect : MonoBehaviour
{
    GameObject plotObj;
    public GameObject capText;
    public int currentCap = 0;

    [SerializeField] private Material full;
    [SerializeField] private Material half;
    [SerializeField] private Material empty;

    [SerializeField] private GameObject player;
    [SerializeField] private GameObject plot;
    //[SerializeField] private Collider cubeBlade;
    private int currentHeight = 3;
    //private int desiredHeight;
    private bool mowed = false;
   
    public int getGrassHeight()
    {
        return currentHeight;
    }

    public void Start()
    {
        //desiredHeight = plot.GetComponent<yardRules>().getDesired();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "cubeBlade")
        {
            //bladeLogic bL = other.GetComponent<bladeLogic>();
            //bL.PartMowerEnabled();

            //Debug.Log("grass player object: " + player.GetInstanceID());
            int height = player.GetComponent<PlayerMovement>().getHeight();
            //Debug.Log("After getter: " + height);
            int diff = currentHeight - height;

            if (height == 2 && currentHeight > height)
            {
                Transform a = gameObject.transform.GetChild(0);
                Transform b = gameObject.transform.GetChild(1);
                Transform c = gameObject.transform.GetChild(2);
                Transform d = gameObject.transform.GetChild(3);

                a.gameObject.GetComponent<MeshRenderer>().material = half;
                b.gameObject.GetComponent<MeshRenderer>().material = half;
                c.gameObject.GetComponent<MeshRenderer>().material = half;
                d.gameObject.GetComponent<MeshRenderer>().material = half;
            }
            if (height == 1 && currentHeight > height)
            {
                Transform a = gameObject.transform.GetChild(0);
                Transform b = gameObject.transform.GetChild(1);
                Transform c = gameObject.transform.GetChild(2);
                Transform d = gameObject.transform.GetChild(3);

                a.gameObject.GetComponent<MeshRenderer>().material = empty;
                b.gameObject.GetComponent<MeshRenderer>().material = empty;
                c.gameObject.GetComponent<MeshRenderer>().material = empty;
                d.gameObject.GetComponent<MeshRenderer>().material = empty;
            }
            if (height == 0 && currentHeight > height)
            {
                gameObject.SetActive(false);
            }

            if (diff > 0)
            {
                capText.GetComponent<bagCapacity>().capChanger(diff);
            }

            if (!mowed)
            {
                plot.GetComponent<yardRules>().grassRemoval();
            }

            if (height < currentHeight)
            {
                currentHeight = height;
                //Debug.Log("Mowed At Height: " + currentHeight);
            }
            
            mowed = true;
            //Debug.Log("Mowed At: " + height);

        }
    }
}
