using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollidersGradas : MonoBehaviour
{
    public GameObject col1;
    public GameObject col2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Boss")
        {
            col1.GetComponent<BoxCollider>().isTrigger = false;
            col2.GetComponent<BoxCollider>().isTrigger = false;
        }
    }
}
