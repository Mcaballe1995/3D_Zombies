using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMenuFromFinal : MonoBehaviour
{
    void Start()
    {
        //Start the coroutine we define below named ChangeAfter2SecondsCoroutine().
        StartCoroutine(ChangeAfter18SecondsCoroutine());
    }

    IEnumerator ChangeAfter18SecondsCoroutine()
    {
        
        yield return new WaitForSeconds(18);
        SceneManager.LoadScene("Menu");


    }
}
