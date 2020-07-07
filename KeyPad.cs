using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPad : MonoBehaviour
{
    public BoxCollider boxCollider;
    public keyPadEditor correctKeyPad;
    public GameObject gameObjectModel;
    public Goal goal;

     void Start()
    {
        
    }
    void Update()
    {
        int getKeyPad1 = PlayerPrefs.GetInt("KeyPad1");
        if (getKeyPad1 == 1)
        {
            goal.keyPad1Touched = true;
            gameObjectModel.gameObject.SetActive(false);
        }
        int getKeyPad2 = PlayerPrefs.GetInt("KeyPad2");
        if (getKeyPad2 == 1)
        {
            goal.keyPad2Touched = true;
            gameObjectModel.gameObject.SetActive(false);
        }
        int getKeyPad3 = PlayerPrefs.GetInt("KeyPad3");
        if (getKeyPad3 == 1)
        {
            goal.keyPad3Touched = true;
            gameObjectModel.gameObject.SetActive(false);
        }
        int getKeyPad4 = PlayerPrefs.GetInt("KeyPad4");
        if (getKeyPad4 == 1)
        {
            goal.keyPad4Touched = true;
            gameObjectModel.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider player)
    {
        usekeyPad(player);
    }

    private void usekeyPad(Collider player)
    {
        if (player)
        {
            switch (correctKeyPad.KeyPad)
            {
                case keyPadEditor.KeyPadType.keyPad1:
                    {
                        goal.keyPad1Touched = true;
                        gameObjectModel.gameObject.SetActive(false);
                    }
                    break;
                case keyPadEditor.KeyPadType.keyPad2:
                    {
                        goal.keyPad2Touched = true;
                        gameObjectModel.gameObject.SetActive(false);
                    }
                    break;
                case keyPadEditor.KeyPadType.keyPad3:
                    {
                        goal.keyPad3Touched = true;
                        gameObjectModel.gameObject.SetActive(false);
                    }
                    break;
                case keyPadEditor.KeyPadType.keyPad4:
                    {
                        goal.keyPad4Touched = true;
                        gameObjectModel.gameObject.SetActive(false);
                    }
                    break;
            }
        }
    }
}