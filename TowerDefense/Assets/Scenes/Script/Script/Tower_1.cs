using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower_1 : MonoBehaviour
{
    float time = 2f;
    float aux = 0f;

    public Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        animator.enabled = true;
        animator.SetTrigger("PlayAnim");
        aux += Time.deltaTime;  
    }
    void Update()
    {

        if (aux == 0f && GlobalPath.enemies != null && GlobalPath.enemies.Count > 0)
        {
            animator.enabled = true;
            animator.SetTrigger("PlayAnim");
            
        }
        if(GlobalPath.lifes == 0 ){

            if(GlobalPath.enemies.Count == 0){
                if (animator.GetCurrentAnimatorStateInfo(0).IsName("Idle_0"))
                {
                    animator.enabled = false; 
                }
            }

        }
        if(GlobalPath.HasKilledfst == false  && GlobalPath.lifes < 3 ){

            if(GlobalPath.enemies.Count == 0){
                if (animator.GetCurrentAnimatorStateInfo(0).IsName("Idle_0"))
                {
                    animator.enabled = false; 
                }
            }
        }
        if(GlobalPath.nenemys == 5&& GlobalPath.lifes > 0 ){
            if(GlobalPath.enemies.Count == 0){
                if (animator.GetCurrentAnimatorStateInfo(0).IsName("Idle_0"))
                {
                    animator.enabled = false; 
                }

            }
        }
        
        aux += Time.deltaTime;

        if (aux >= time && GlobalPath.enemies != null && GlobalPath.enemies.Count > 0)
        {


            GameObject bullet = Instantiate(GlobalPath.bullet);
            bullet.name = "Bullet";
            bullet.transform.position = transform.position;
            Destroy(bullet.GetComponent<Bullet>());
            bullet.AddComponent<Bullet_mov>();

            aux = 0f;
            
        }
        
    }
}