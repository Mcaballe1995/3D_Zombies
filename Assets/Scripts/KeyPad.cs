using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyPad : MonoBehaviour
{
    public GameObject player;
    public GameObject keypadOB;
    public GameObject hud;
    public GameObject inv;

    public GameObject animateOB;
    public Animator ani;
    public Text textOB;
    public string answear = "12345";

    public AudioSource button;
    public AudioSource correct;
    public AudioSource wrong;
    public bool animate;

    // Start is called before the first frame update
    void Start()
    {
        keypadOB.SetActive(false);
    }

    public void Number(int number)
    {
        textOB.text += number.ToString();
        button.Play();
    }

    public void Execute()
    {
        if(textOB.text == answear)
        {
            correct.Play();
            textOB.text = "Right";
        }
        else
        {
            wrong.Play();
            textOB.text = "Wrong";

        }
    }

    public void Clear()
    {
        {
            textOB.text = "";
            button.Play();
        }
    }

    public void Exit()
    {
        keypadOB.SetActive(false);
        inv.SetActive(true);
        hud.SetActive(true);
        player.GetComponent<PlayerMovementScript>().enabled = true;
        player.GetComponent<GunScript>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(textOB.text == "Right" && animate)
        {
            ani.SetBool("animate", true);
            Debug.Log("it's open");
        }
        if(keypadOB.activeInHierarchy)
        {
            inv.SetActive(false);
            hud.SetActive(false);
            player.GetComponent<PlayerMovementScript>().enabled = false;
            player.GetComponent<GunScript>().enabled = false;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
