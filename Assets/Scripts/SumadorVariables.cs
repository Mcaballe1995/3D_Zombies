using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SumadorVariables : MonoBehaviour
{

    public static Text textElement;



    // Update is called once per frame
    void Update()
    {
        textElement.text = "Zombies muertos:  "+General.zombiesMuertos.ToString()+ " / 12";
    }
}
