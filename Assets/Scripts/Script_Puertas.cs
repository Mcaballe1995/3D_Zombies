using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class Script_Puertas : MonoBehaviour
    {
        public Animation trigger1Here;
        public bool onTrigger;
        // Start is called before the first frame update
        void Start()
        {

        }

        void OnGUI()
        {

            if (onTrigger)
            {
                GUI.Box(new Rect(300, 300, 400, 25), "La puerta está cerrada, encuentra la llave");
            }
        }

        void OnTriggerEnter(Collider other)
        {
            //Debug.Log(other.gameObject.name);
            onTrigger = true;
        }

        void OnTriggerExit(Collider other)
        {
            onTrigger = false;
        }

        // Update is called once per frame
        void OnTriggerStay()
        {
            if (cogerLlave.openDoor)
            {

                if (Input.GetKeyDown(KeyCode.E))
                {
                Debug.Log("puerta abierta");
                    trigger1Here.Play();
                }
            }

        }


    }

