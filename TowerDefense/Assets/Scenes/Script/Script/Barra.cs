using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Barra : MonoBehaviour
{
    // Start is called before the first frame update
    public Image h1;
    public Image h2;
    public Image h3;
    public Image roxo;
    public Image gelo;

    void Start()
    {
        GlobalPath.Barra_vermelha = h1;
        GlobalPath.Barra_verde = h2;
        GlobalPath.Barra_preta = h3;
        GlobalPath.Barra_roxa = roxo;
        GlobalPath.gelo = gelo;
    }

    // Update is called once per frame

}
