using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierAI : MonoBehaviour
{
 

    public Transform Target;
    public float TargetDistance;
    public float ShootDistance = 20f;
    public float DistanceLimit = 30f;
    public float SoldierHealth = 100f;

    public int SoldierAmmo = 200;
    public int SoldierClips = 8;

    public int SoldierGrenades = 8;
    public int GibType; //Type of Gib(Gore) to generate

    public int SoldierState;  //1 Idle 2 Agressive 3 Bombastic 4 Alerting 5 Hiding 6 Retreating
    public string SoldierVerb;

    public bool isShooting;
    public bool isReloading;
    public bool isDying;


    public GameObject bullet;
    public GameObject[] gib;

    public GameObject hole;
    public GameObject Torso;

    private Animator animator;

    private int SoldierTimer;
    
    
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {

        HealthCheck();
        DistanceCheck();
        SoldierStateCheck();

        if (isShooting)
        {
            SoldierTimer++;
            if (SoldierTimer == 125)
            {
                Shoot();
            }

            if (SoldierTimer >= 200)
            {
                SoldierTimer = 0;
                isShooting = false;
            }

        }

    }

    private void SoldierStateCheck()
    {

    }

    private void HealthCheck()
    {

    }

    private void DistanceCheck()
    {
        TargetDistance = Vector3.Distance(Target.position, transform.position);
        UnityEngine.AI.NavMeshAgent agent = GetComponent<UnityEngine.AI.NavMeshAgent>();

        if (SoldierAmmo <= 0)
        {
           
            animator.SetBool("IsReloading", true);
            animator.SetBool("IsRunning", false);
            animator.SetBool("IsFiring", false);
            if (isReloading)
            {
               
SoldierAmmo = 200;
            }
            isReloading = true;
        }




        if  (TargetDistance < ShootDistance && TargetDistance < DistanceLimit && SoldierAmmo > 0)
        {
            agent.destination = transform.position;
            animator.SetBool("IsRunning", false);
            animator.SetBool("IsFiring", true);
            isShooting = true;
           
            transform.LookAt(Target.position);
            Torso.transform.LookAt(Target.position);
            hole.transform.LookAt(Target.position);
            SoldierAmmo--;
        }

        if (TargetDistance < DistanceLimit && TargetDistance > ShootDistance)
        {
            agent.destination = Target.position;
            animator.SetBool("IsRunning", true);
            animator.SetBool("IsFiring", false);
            animator.SetBool("IsIdle", false);
            isShooting = false;
            
        }

        if (TargetDistance > DistanceLimit)
        {
            agent.destination = transform.position;
            animator.SetBool("IsRunning", false);
            animator.SetBool("IsFiring", false);
            isShooting = false;
          
        }

        if (SoldierAmmo > 1)
        {
            animator.SetBool("IsReloading", false);
            isReloading = false;
            
        }




    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "9mm")
        {
            SoldierHealth = SoldierHealth - 1;
            GibType = 1;
        }

        if (other.tag == "50cal")
        {
            SoldierHealth = SoldierHealth - 10;
            GibType = 2;
        }

        if (other.tag == "point41")
        {
            SoldierHealth = SoldierHealth - 50;
            GibType = 3;
        }


        if (other.tag == "12guage")
        {
            SoldierHealth = SoldierHealth - 20;
            GibType = 3;
        }


        if (other.tag == "Grenade")
        {
            SoldierHealth = SoldierHealth - 45;
            GibType = 4;
        }


        if (!isDying && SoldierHealth <= 0)
        {
            isDying = true;
            MakeGibs(); 
        }
    }

    private void MakeGibs()// When Solider is dying how to kill them
    {
        GameObject gib1 = Instantiate(gib[GibType], hole.GetComponent<Transform>().position, hole.GetComponent<Transform>().rotation);
        Destroy(gameObject);
    }

    private void Shoot()
    {
        GameObject ball = Instantiate(bullet, hole.GetComponent<Transform>().position, hole.GetComponent<Transform>().rotation);
        //ball.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, 50f, 0));
        ball.GetComponent<Rigidbody>().velocity = hole.GetComponent<Transform>().transform.TransformDirection(Vector3.forward * 15 * Random.Range(1,10));
        ball.GetComponent<SelfDestruct>().isOriginal = false;
        isShooting = false;
    }

    private void AmmoCheck()
    {

    }




}


