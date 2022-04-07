using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggersScript : MonoBehaviour
{
    



    private void OnTriggerStay(Collider other)
    {

        var glref = other.GetComponent<LogicScript>();


        if (Input.GetKey(KeyCode.E) )
        {
                        Debug.Log("e is pressed");

            glref.minesLocation(name);

            Debug.Log("This square value is : " + glref.squaresValue(name));

            Array.Clear(glref.Zeros,0,glref.Zeros.Length);
            glref.ZerosIndex = 1;
            glref.itemIndex = 0;
            glref.Zeros[0] = name;
            glref.zerosCheck(glref.Zeros);
        }
    }

    



}
