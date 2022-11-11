using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class HitBoss : MonoBehaviour
{
    private float damage;

    private void Start()
    {
        damage = 1.0f;
    }
    private void Update()
    {
        damage -= Time.deltaTime;
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player" && damage < 0)
        {
            Debug.Log(General.Get_hpMin());
            damage = 1.0f;
            General.Set_hpMin(50);
        }
    }
}

