using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Oxygen : MonoBehaviour
{
    public Goal goal;


    public float OxyLevel;
    public Text OxyText;
    public float MaxOxy = 300;
    public float OxyLost = 0;
    
    public int roomNum;
    // Start is called before the first frame update
    void Start()
    {
        OxyLevel = MaxOxy;    
    }

    // Update is called once per frame
    void Update()
    {

       

        if (goal.keyPad1Touched == true)
        {
            OxyLevel += 4 * Time.deltaTime;

        }
        if (goal.keyPad2Touched == true)
        {
            OxyLevel += 5 * Time.deltaTime;
        }
        if (goal.keyPad3Touched == true)
        {
            OxyLevel += 5 * Time.deltaTime;
        }
        if (goal.keyPad4Touched == true)
        {
            OxyLevel += 6 * Time.deltaTime;
        }

        if (OxyLevel <= 0)
        {
            Application.Quit();
        }
        else
        {
            OxyLevel -= 21 * Time.deltaTime;
        }

        
    OxyText.text = Mathf.RoundToInt(OxyLevel).ToString();


    }
}
