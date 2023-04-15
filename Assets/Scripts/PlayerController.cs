using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{


    [SerializeField] private int health;
    [SerializeField] private float _playerSpeed = 1.0f;
    [SerializeField] private int damage;
    [SerializeField] private float timePerFire;
    [SerializeField] private bool isAttack = false;

    [SerializeField] private Joystick _joystick;
    [SerializeField] private GameObject enemyFocus;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject playerBullet;
    [SerializeField] private HealthBar healthBar;
    



    private CharacterController _controller;

    

    void Start()
    {
        healthBar.SetMaxHealth(health);
        _controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        var direction = new Vector3(_joystick.Direction.x, 0, _joystick.Direction.y);
        if (direction != Vector3.zero)
        {
            transform.forward = direction;
            _controller.Move(direction * Time.deltaTime * _playerSpeed);
            
        }
        FindClosestEnemy();








    }



    public void TakeDamage(int damage)
    {
        Material material = GetComponent<Renderer>().material;
        material.DOColor(Color.red, 0.5f).SetLoops(2,LoopType.Yoyo).Play();
        health -= damage;
        healthBar.SetHealth(health);
        if (health <= 0)
        {
            Death();
        }

    }



    public void Death()
    {

        Destroy(gameObject);
        healthBar.DestroyHealthBar();
        DeathScript.DeathMenu();
    }


    public void FindClosestEnemy()
    {

        float leastDistance = Mathf.Infinity;
        Enemy[] allEnemies = GameObject.FindObjectsOfType<Enemy>();
        if (allEnemies.Length > 0)
        {
            foreach (Enemy enemy in allEnemies)
            {
                float distanceHere = Vector3.Distance(transform.position, enemy.transform.position);

                if (distanceHere < leastDistance)
                {
                    leastDistance = distanceHere;
                    enemyFocus = enemy.gameObject;
                    
                }
            }

            Shoot(enemyFocus);
            

        }

        
        

    }


    public void Shoot(GameObject enemy)
    {
        transform.LookAt(enemy.transform);
        if (!isAttack)
        {
            isAttack = true;
            GameObject bullet = Instantiate(playerBullet, firePoint.transform.position, firePoint.rotation);
            bullet.GetComponent<PlayerBullet>().damage = damage;
            Destroy(bullet, 1.5f);
            StartCoroutine(TimeAttack());
        }
        
        

    }




    public IEnumerator TimeAttack()
    {
        yield return new WaitForSeconds(timePerFire);
        isAttack = false;
    }


   

    
}
