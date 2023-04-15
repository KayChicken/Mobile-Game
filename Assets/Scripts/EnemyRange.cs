using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRange : Enemy
{
    


    public GameObject ammo;








    private void Update()
    {
        if (player != null)
        {
            Move();
        }
       
    }


    public override void Attack()
    {
        
        isAttack = true;
        animator.SetBool("isAttack", true);
        StartCoroutine(TimeAttack());

    }


    public void Shoot()
    {
        GameObject bullet = Instantiate(ammo, attackPoint.transform.position, attackPoint.transform.rotation);
        bullet.GetComponent<BulletControll>().damage = damage;
        Destroy(bullet, 1.5f);
   
    }



}
