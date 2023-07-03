using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
  
        Camera.main.orthographicSize = 45;
        Camera.main.transform.position = new Vector3(80, 45,-50);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
