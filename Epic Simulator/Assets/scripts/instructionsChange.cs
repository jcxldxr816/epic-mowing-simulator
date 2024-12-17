using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instructionsChange : MonoBehaviour
{
    public GameObject instructions;
    
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(timer());
        IEnumerator timer()
        {
            instructions.SetActive(true);
            yield return new WaitForSecondsRealtime(45);
            instructions.SetActive(false);
            //Debug.Log("instructions gone");
        }
    }
}
