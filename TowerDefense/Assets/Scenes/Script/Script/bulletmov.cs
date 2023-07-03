using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bullet_mov : MonoBehaviour
{
    // Start is called before the first frame update
    int i = 0;
    public float speed = 40f;
    GameObject g1;
    GameObject aux;

    void Start()
    {
        speed += GlobalPath.speed;
        if (i < GlobalPath.nenemys && GlobalPath.enemies != null && GlobalPath.enemies.Count > 0)
        {
            aux = GlobalPath.enemies[0];
            g1 = GlobalPath.enemies[0];
            Vector3 proximo = g1.transform.position;
            transform.position = Vector3.MoveTowards(transform.position,proximo, speed * Time.deltaTime);
            if (transform.position == proximo)
            {
                i++;
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(aux != g1)
        {
            
            Destroy(gameObject);
            GlobalPath.enemytokill++;



        }
        else if (i < GlobalPath.nenemys && GlobalPath.enemies != null && GlobalPath.enemies.Count > 0)
        {
            g1 = GlobalPath.enemies[0];
            Vector3 proximo = g1.transform.position;
            transform.position = Vector3.MoveTowards(transform.position,proximo, speed * Time.deltaTime);
            if (transform.position == proximo)
            {
                i++;
            }
        }
        else
        {
            Destroy(gameObject);
        }

        
    }
}
