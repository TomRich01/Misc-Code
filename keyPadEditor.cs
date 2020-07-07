using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "KeyPad", menuName = "Logic/Item/KeyPad", order = 0)]
public class keyPadEditor : ScriptableObject
{
    public KeyPadType KeyPad;
    public enum KeyPadType
    {
        keyPad1 = 0,
        keyPad2 = 1,
        keyPad3 = 2,
        keyPad4 = 3
    }
}
