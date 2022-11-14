using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keypad_script : MonoBehaviour
{

    public string correctPassword = "1234";
    public string input;
    public bool onTrigger;
    public bool doorOpen;
    public bool keypadScreen;
    public Transform doorTrigger;
    public Transform doorTrigger2;

    void OnTriggerEnter(Collider other)
    {
        onTrigger = true;
    }

    void OnTriggerExit(Collider other)
    {
        onTrigger = false;
        keypadScreen = false;
        input = "";
    }

    void Update()
    {
        if (input == correctPassword)
        {
            doorOpen = true;
        }

        //this if makes the rotation of the doors and don't need the animation
        if (doorOpen)
        {
            Time.timeScale = 1f;
            var newRot = Quaternion.RotateTowards(doorTrigger.rotation, Quaternion.Euler(0.0f, -180.0f, 0.0f), Time.deltaTime * 150);
            doorTrigger.rotation = newRot;
            var newRot2 = Quaternion.RotateTowards(doorTrigger2.rotation, Quaternion.Euler(0.0f, 360.0f, 0.0f), Time.deltaTime * 150);
            doorTrigger2.rotation = newRot2;
        }
    }

    void OnGUI()
    {
        if (!doorOpen)
        {
            if (onTrigger)
            {
                GUI.Box(new Rect(300, 300, 400, 25), "Presiona 'E' para abrir el panel y introduce 4 numeros");

                if (Input.GetKeyDown(KeyCode.E))
                {
                    keypadScreen = true;
                    Time.timeScale = 0f;
                    onTrigger = false;
                }
            }

            if (keypadScreen)
            {
                GUI.Box(new Rect(0, 0, 320, 455), "");
                GUI.Box(new Rect(5, 5, 310, 45), input);

                if (GUI.Button(new Rect(5, 35, 100, 100), "1"))
                {
                    input = input + "1";
                }

                if (GUI.Button(new Rect(110, 35, 100, 100), "2"))
                {
                    input = input + "2";
                }

                if (GUI.Button(new Rect(215, 35, 100, 100), "3"))
                {
                    input = input + "3";
                }

                if (GUI.Button(new Rect(5, 140, 100, 100), "4"))
                {
                    input = input + "4";
                }

                if (GUI.Button(new Rect(110, 140, 100, 100), "5"))
                {
                    input = input + "5";
                }

                if (GUI.Button(new Rect(215, 140, 100, 100), "6"))
                {
                    input = input + "6";
                }

                if (GUI.Button(new Rect(5, 245, 100, 100), "7"))
                {
                    input = input + "7";
                }

                if (GUI.Button(new Rect(110, 245, 100, 100), "8"))
                {
                    input = input + "8";
                }

                if (GUI.Button(new Rect(215, 245, 100, 100), "9"))
                {
                    input = input + "9";
                }

                if (GUI.Button(new Rect(110, 350, 100, 100), "0"))
                {
                    input = input + "0";
                }
            }
        }
    }
}
