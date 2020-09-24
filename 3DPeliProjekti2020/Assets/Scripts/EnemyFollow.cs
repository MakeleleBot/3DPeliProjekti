using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public GameObject thePlayer;
    public float TargetDistance;
    public float AllowedRange = 10f;
    public GameObject theEnemy;
    public float enemySpeed;
    public int attackTrigger;
    public RaycastHit shot;
    Animator EnemyAnim;
    
    Enemy EHealth;

    

    public void Start()
    {
        EnemyAnim = GetComponent<Animator>();
        EHealth = GetComponent<Enemy>();
    }

    private void Update()
    {
        transform.LookAt(thePlayer.transform);
        if (Physics.Raycast (transform.position, transform.TransformDirection(Vector3.forward), out shot))
        {
            TargetDistance = shot.distance;
            if (TargetDistance < AllowedRange)
            {
                enemySpeed = 0.01f;
                if (attackTrigger == 0)
                {
                    // theEnemy.GetComponent<Animation>().Play("Walking");  // Animaatio viholliselle
                    transform.position = Vector3.MoveTowards(transform.position, thePlayer.transform.position, enemySpeed);
                    //EnemyAnim.SetFloat("Move", Mathf.Abs(enemySpeed));
                    EnemyAnim.SetBool("Walking", true);
                }
            }
            else
            {
                enemySpeed = 0;
                //EnemyAnim.SetFloat("Move", Mathf.Abs(enemySpeed));
                EnemyAnim.SetBool("Walking", false);
                // theEnemy.GetComponent<Animation>().Play("Idle"); // Vihollisen idle-animaatio tähän
            }
        }

        if (attackTrigger == 1)
        {
            enemySpeed = 0;
            EnemyAnim.SetBool("Attacking", true);
            //      theEnemy.GetComponent<Animation>().Play("Attacking"); // Attack-animaatio
        }

        if(EHealth.CurrentHealth < 0)
        {
            EnemyAnim.SetBool("Die", true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        attackTrigger = 1;
       
    }

    private void OnTriggerExit(Collider other)
    {
        attackTrigger = 0;
    }
}
