using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;



public class BossMov : MonoBehaviour
{
    // Start is called before the first frame update
    int i = 0;
    public float speed = 10f;
    public float life = 20;
    public Image b_p;
    public Image b_roxo;
    public Image b_r;
    public Image gelo;
    public float maxlife = 20;

    void Start()
    {
        
        
        transform.position = new Vector3(3, 55, -1);
        life = GlobalPath.enemylife * 3;
        maxlife = GlobalPath.enemylife * 3;

        b_p = Instantiate(GlobalPath.Barra_preta);
        b_r = Instantiate(GlobalPath.Barra_vermelha);
        b_roxo = Instantiate(GlobalPath.Barra_roxa);
        gelo = Instantiate(GlobalPath.gelo);
        
        b_p.transform.SetParent(GameObject.Find("Canvas").transform);    
        b_r.transform.SetParent(GameObject.Find("Canvas").transform);
        b_roxo.transform.SetParent(GameObject.Find("Canvas").transform);
        gelo.transform.SetParent(GameObject.Find("Canvas").transform);
        gelo.transform.localScale = new Vector3(2, 2, 2);
            

        
        b_roxo.transform.position = new Vector3((transform.position.x)*10, (transform.position.y + 1.5f)*10, transform.position.z);
        b_r.transform.position = new Vector3((transform.position.x)*10, (transform.position.y + 1.5f)*10, transform.position.z);
        b_p.transform.position = new Vector3((transform.position.x)*10, (transform.position.y + 1.5f)*10, transform.position.z);


    }

    // Update is called once per frame
    void Update()
    {
        speed = GlobalPath.speed_enemy;
        Move();
        b_roxo.fillAmount = life / maxlife;    
        b_roxo.transform.position = new Vector3((transform.position.x), (transform.position.y+2), transform.position.z);
        b_r.transform.position = new Vector3((transform.position.x), (transform.position.y+2), transform.position.z);
        b_p.transform.position = new Vector3((transform.position.x), (transform.position.y+2), transform.position.z);
        if(speed == 0){
            gelo.transform.position = new Vector3((transform.position.x), (transform.position.y-3), -2);
        }
        else{
            gelo.transform.position = new Vector3(1000, 1000, -2);
        }


    }
    void Move(){
        if (i == GlobalPath.coord.Count)
        {
            GlobalPath.lifes--;
            GlobalPath.enemies.Remove(gameObject);
            Destroy(gameObject);
            Destroy(b_p);
            Destroy(b_r);
            Destroy(b_roxo);
            Destroy(gelo);
        }
        if (i < GlobalPath.coord.Count)
        {
            int[,] aux = GlobalPath.coord[i];
            Vector3 proximo = new Vector3((aux[0, 0] * 10), (aux[0, 1] * 10) + 20, -1);
            transform.position = Vector3.MoveTowards(transform.position, proximo, speed * Time.deltaTime);
            if (transform.position == proximo)
            {
                i++;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
    
        if (other.gameObject.name == "Bullet")
        {

            life -= GlobalPath.damage;

            if (life <= 0)
            {            

                GlobalPath.enemies.Remove(gameObject);
                Destroy(gameObject);
                GlobalPath.enemycount++;
                GlobalPath.money += 200;
                GlobalPath.HasKilledfst = true;
                GlobalPath.ondestroyparticle.transform.position = new Vector3(transform.position.x, transform.position.y, -20);
                GlobalPath.ondestroyparticle.Play();
                Destroy(b_p);
                Destroy(b_r);
                Destroy(b_roxo);
                Destroy(gelo);


            }
            Destroy(other.gameObject);
        }
    }

}

