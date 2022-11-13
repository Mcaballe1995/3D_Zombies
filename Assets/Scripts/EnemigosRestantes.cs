using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class EnemigosRestantes : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI enemiesRestantesTexto;
    List<ZombieMovement> zombies = new List<ZombieMovement>();

    private void OnEnable()
    {
        ZombieMovement.OnEnemyKilled += HandleEnemyDefeated;
    }

    private void OnDisable()
    {
        ZombieMovement.OnEnemyKilled -= HandleEnemyDefeated;
    }
    private void Awake()
    {
        zombies = GameObject.FindObjectOfType<ZombieMovement>().ToList();
        UpdateZombiesRestantesText();
    }
    void HandleEnemyDefeated(ZombieMovement zombieMovement)
    {
        if(zombies.Remove(zombieMovement))
        {
            UpdateZombiesRestantesText();
        }
        
    }
    void UpdateZombiesRestantesText()
    {
        enemiesRestantesTexto.text = $"Enemigos restantes:  {zombies.Count}";
    }
}
