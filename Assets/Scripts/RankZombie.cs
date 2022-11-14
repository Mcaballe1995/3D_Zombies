using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankZombie : MonoBehaviour
{
    public Animator ani;
    public ZombieMovement zombie;
    public int melee;

    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            melee = Random.Range(0, 2);
            switch (melee)
            {
                case 0:
                    //hit1
                    ani.SetFloat("skills", 0);
                    if (zombie) { 
                        zombie.hit_select = 0;
                    }
                    break;

                case 1:
                    //hit2
                    ani.SetFloat("skills", 0.2f);
                    if(zombie) {
                        zombie.hit_select = 1;
                    }
                    break;

            }
            ani.SetBool("walk", false);
            ani.SetBool("run", false);
            ani.SetBool("attack", true);
            zombie.isAttacking = true;
            GetComponent<CapsuleCollider>().enabled = false;
        }
    }
}
