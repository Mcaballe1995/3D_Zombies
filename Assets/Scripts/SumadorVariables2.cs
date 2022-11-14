using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SumadorVariables2 : MonoBehaviour
{

    public Text textElement;




    // Update is called once per frame
    void Update()
    {
        textElement.text = "Oleada:  " + General.oleadasZombies.ToString();
        textElement.color = Color.yellow;
    }

}