using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Goal : MonoBehaviour
{
    public Text textGoal;

    public Oxygen oxygen;

    public bool keyPad1Touched;
    public bool keyPad2Touched;
    public bool keyPad3Touched;
    public bool keyPad4Touched;

    
     void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

        if (keyPad1Touched == true)
        {
            PlayerPrefs.SetInt("KeyPad1", 1);

        }
        if (keyPad2Touched == true)
        {
            PlayerPrefs.SetInt("KeyPad2", 1);

        }
        if (keyPad3Touched == true)
        {
            PlayerPrefs.SetInt("KeyPad3", 1);

        }
        if (keyPad4Touched == true)
        {
            PlayerPrefs.SetInt("KeyPad4", 1);

        }






        UpdateText();

    }

    private void UpdateText()
    {
        if (keyPad1Touched == true)
        {
            textGoal.text = "1/4";
        }
        if (keyPad2Touched == true)
        {
            textGoal.text = "2/4";
        }
        if (keyPad3Touched == true)
        {
            textGoal.text = "3/4";
        }
        if (keyPad4Touched == true)
        {
            textGoal.text = "4/4";
        }
    }
}
