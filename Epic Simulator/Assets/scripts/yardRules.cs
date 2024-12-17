using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class yardRules : MonoBehaviour
{
    GameObject[] grass;
    public float grassNum = 0f;
    public float grassTot = 0f;
    public float grassPercent = 100f;
    private int grassDisplay = 100;
    private KeyCode enterKey = KeyCode.Return;
    private bool enterPressed = false;
    public int strikes;
    public float grassValue;
    
    [SerializeField] GameObject hRequest;
    [SerializeField] GameObject payText;
    
    [SerializeField] GameObject paymentText;
    [SerializeField] Text paymentAmount;

    [SerializeField] GameObject enterComplete;
    [SerializeField] GameObject noPayment;
   
    //LEVEL RULES
    private int desiredHeight = 2;
    private float pay = 80f;
    private float tip = 20f;
    


    public int getPercent()
    {
        return grassDisplay;
    }
    public int getDesired()
    {
        return desiredHeight;
    }

    public void grassRemoval()
    {
        grassNum = grassNum - 1;
        //Debug.Log("removed grass from array " + grassNum);
    }

    private int calculateStrikes()
    {
        int height;
        foreach (GameObject i in grass)
        {
            height = i.GetComponent<grassDetect>().getGrassHeight();
            if (height != desiredHeight)
            {
                strikes += 1;
            }
        }
        return strikes;
    }

    // Start is called before the first frame update
    void Start()
    {
        grass = GameObject.FindGameObjectsWithTag("grass");
        grassTot = grass.Length;
        grassNum = grassTot;
        grassValue = (100 / grassTot);
        Debug.Log("Total: " + grassTot);
        Debug.Log("Desired Height: " + desiredHeight);

        hRequest.SetActive(true);
        payText.SetActive(true);
        paymentText.SetActive(false);
        enterComplete.SetActive(true);
        noPayment.SetActive(false);
        paymentAmount.text = (" ");

        Update();
    }
    
    // Update is called once per frame
    void Update()
    {
        grassPercent = (100 - ((grassNum / grassTot) * 100f));

        grassDisplay = (int)grassPercent;
        //Debug.Log("Grass Remaining: " + grassDisplay + "%");
        if (Input.GetKeyDown(enterKey) && !enterPressed)
        {
            Debug.Log("Enter Pressed");
            enterPressed = true;
            enterComplete.SetActive(false);
            calculateStrikes();

            pay = ((pay * grassPercent) - (strikes * grassValue))/100;
            if (pay < 20)
            {
                pay = 0;
                noPayment.SetActive(true);
            }
            if (grassPercent <= 100 && pay >= 20)
            {
                pay += tip;
                paymentText.SetActive(true);
                paymentAmount.text = pay.ToString("n2");
            }
            Debug.Log("Pay: " + pay.ToString("n2"));
        }
    }
}
