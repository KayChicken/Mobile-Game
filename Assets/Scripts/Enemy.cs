using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class Enemy : MonoBehaviour
{

    [SerializeField] public int health;
    [SerializeField] public int damage;
    [SerializeField] public float speedEnemy;
    [SerializeField] public float attackRange;
    [SerializeField] public float attackRadius;
    [SerializeField] public float timePerAttack;
    [SerializeField] public bool isAttack = false;
    [SerializeField] public Transform attackPoint;

    [SerializeField] public GameObject player;
    [SerializeField] public NavMeshAgent enemy;
    [SerializeField] private Vector3 moveDirection;
    [SerializeField] public Animator animator;
    [SerializeField] public LayerMask playerLayer;



    public void Start()
    {
        player = GameObject.Find("Player");
    }



    public void Move()
    {

        enemy.SetDestination(player.transform.position);
        Vector3 targetPosition = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
        transform.LookAt(targetPosition);
        float distance = Vector3.Distance(transform.position, player.transform.position);
        if (distance < attackRange)
        {
            if (!isAttack)
            {
                Attack();
            }

            else
            {
                animator.SetBool("isAttack", false);
            }


        }

        else
        {
            animator.SetBool("isAttack", false);
        }





    }



    public virtual void Attack()
    {

    }





    public IEnumerator TimeAttack()
    {
        yield return new WaitForSeconds(timePerAttack);
        isAttack = false;
    }



    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Death();
        }
    }


    public void Death()
    {
        Destroy(gameObject);
    }







}
