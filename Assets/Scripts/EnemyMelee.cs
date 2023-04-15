using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMelee : Enemy
{

    
    



    


    


    public override void Attack()
    {
        isAttack = true;
        animator.SetBool("isAttack", true);
        player.GetComponent<PlayerController>().TakeDamage(damage);
        StartCoroutine(TimeAttack());
        
    }


    private void Update()
    {
        if (player != null)
        {
            Move();
        }
        
    }



    




}
