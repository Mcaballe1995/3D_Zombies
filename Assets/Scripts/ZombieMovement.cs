using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ZombieMovement : MonoBehaviour
{
    public int rutine;
    public float crono;
    public float time_rutines;
    public Animator ani;
    public Quaternion angle;
    public float grade;
    public GameObject target;
    public bool isAttacking;
    public RankZombie rank;
    public float speed;
    public GameObject[] hit;
    public int hit_select;
    public bool estoyMuerto = false;
    
    public bool direction_skill;

    //public Text textZombie;

    internal List<ZombieMovement> ToList()
    {
        throw new System.NotImplementedException();
    }

    public GameObject point;
    [SerializeField] float health = 10.0f, maxhealth = 10.0f;
    public static event System.Action<ZombieMovement> OnEnemyKilled;
    

    public bool death;
    // Start is called before the first frame update

    private void Awake()
    {
        
    }

    void Start()
    {
        ani = GetComponent<Animator>();
        target = GameObject.Find("Player");
        health = maxhealth;
    }

    public void Zombie_Behaviour()
    {
        //if the distance between boss and player is < 15 
        if (Vector3.Distance(transform.position, target.transform.position) < 200)
        {
            //zombie will rotate to the player position
            var lookPos = target.transform.position - transform.position;
            lookPos.y = 0;
            var rotation = Quaternion.LookRotation(lookPos);
            point.transform.LookAt(target.transform.position);


            if (Vector3.Distance(transform.position, target.transform.position) > 1 && !isAttacking)
            {
                switch (rutine)
                {
                    case 0:
                        //walk
                        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 2);
                        ani.SetBool("walk", true);
                        ani.SetBool("run", false);

                        if (transform.rotation == rotation)
                        {
                            transform.Translate(Vector3.forward * speed * Time.deltaTime);
                        }

                        ani.SetBool("attack", false);
                        crono += 1 * Time.deltaTime;
                        if (crono > time_rutines)
                        {
                            rutine = Random.Range(0, 2);
                            crono = 0;
                        }
                        break;

                    case 1:
                        //run
                        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 1);
                        ani.SetBool("walk", false);
                        ani.SetBool("run", true);

                        if (transform.rotation == rotation)
                        {
                            transform.Translate(Vector3.forward * speed * 2 * Time.deltaTime);
                        }

                        ani.SetBool("attack", false);

                        break;
                }
            }
        }
    }

    public void Final_Ani()
    {
        rutine = 0;
        ani.SetBool("attack", false);
        isAttacking = false;
        rank.GetComponent<CapsuleCollider>().enabled = true;
        direction_skill = false;
    }
    public void Direction_Attack_Start()
    {
        direction_skill = true;
    }

    public void Direction_Attack_Final()
    {
        direction_skill = false;
    }

    
    //melee
    public void ColliderWeaponTrue()
    {
        hit[hit_select].GetComponent<SphereCollider>().enabled = true;
    }

    public void ColliderWeaponFalse()
    {
        hit[hit_select].GetComponent<SphereCollider>().enabled = false;
    }

    public void Alive()
    {
        Zombie_Behaviour();
    }

    public void TakeDamage(float damageAmount)
    {
        if (!estoyMuerto)
        {
            health -= damageAmount;
            if (health <= 0)
            {
                estoyMuerto = true;
                OnEnemyKilled?.Invoke(this);
                General.zombiesMuertos += 1;
                /*if (textZombie.CompareTag("numMuertos"))
                    
                {
                    Debug.Log("gfsdgsdfgsd");
                    textZombie.GetComponent<Text>().text = General.zombiesMuertos.ToString();
                }*/
                
                //this.GetComponent<ZombieMovement>().enabled = false;
                Destroy(this.gameObject, 1.0f);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Weapon"))
        {
            TakeDamage(1);
            health -= 1;
            Destroy(other.gameObject, 3.0f);
        }
    }

    void Update()
    {


        if (health > 0)
        {
            Alive();
        } else {
            if (!death)
            {
                ani.SetBool("attack", true);
                ani.SetBool("run", true);

                ani.SetBool("attack", false);
                ani.SetBool("run", false);
                ani.SetBool("walk", false);
                ani.SetTrigger("dead");
                death = true;


            }

        }
    }
}


