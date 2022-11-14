using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


    public class cogerLlave : MonoBehaviour
    {
        public Text pressE;
        public static bool openDoor = false;
        public GameObject KeyGone;
        public static bool keyTaken = false;
    // Start is called before the first frame update
    void Start()
        {
            pressE.enabled = false;
        }

        // Update is called once per frame
        void OnTriggerStay()
        {
            pressE.enabled = true;

            if (Input.GetKeyDown(KeyCode.E))
            {
                openDoor = true;
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                KeyGone.SetActive(false);
                keyTaken = true;
                pressE.enabled = false;
            }


        }

    }

