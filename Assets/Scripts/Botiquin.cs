using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

    public class Botiquin : MonoBehaviour
    {

        void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player")
            {
            General.hp_min += 250;
            Destroy(this.gameObject);
            }

        }

    }


