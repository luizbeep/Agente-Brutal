using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraDeVidaP : MonoBehaviour
{ 
    // Start is called before the first frame update

    [SerializeField]private Image barraDeVidaImageP;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AlterarBarraDeVidaP(int vidaAtualP, int vidaMaximaP) // aqui é a função usada para diminuir o sprite da barra de vida
    {
        barraDeVidaImageP.fillAmount = (float) vidaAtualP / vidaMaximaP;
    }
}
