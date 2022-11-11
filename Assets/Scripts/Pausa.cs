using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pausa : MonoBehaviour
{
    private GameObject panelPausa;


    private int estadoPausa;
    private int estadoPanelPausa;

    private void Awake()
    {
        estadoPausa = 0;
        panelPausa = (GameObject)GameObject.FindGameObjectWithTag("PanelPausa");


        estadoPanelPausa = 0;

        if (panelPausa != null)
        {
            panelPausa.SetActive(false);
        }

    }

    public void Reanudar()
    {
        //panelPausa.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        panelPausa.SetActive(false);
        estadoPanelPausa = 0;
        Time.timeScale = 1.0f;
    }

    private void Update()
    {
            if (Input.GetKeyDown(KeyCode.Escape))
             {
                if (estadoPanelPausa == 0)
                {
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.None;
                    estadoPanelPausa = 1;
                    Time.timeScale = 0;
                    panelPausa.SetActive(true);
                                
                  }
                else
                {
                    Cursor.visible = false;
                    Cursor.lockState = CursorLockMode.Locked;
                    panelPausa.SetActive(false);
                    estadoPanelPausa = 0;
                    Time.timeScale = 1.0f;
                }
                //MostrarPanelPausa(estadoPanelPausa);
        }
    }

    public void Reintentar()
    {
        SceneManager.LoadScene("Nivel3");
    }

    

    public void SalirJuego()
    {
            SceneManager.LoadScene("Menu");
    }
}
