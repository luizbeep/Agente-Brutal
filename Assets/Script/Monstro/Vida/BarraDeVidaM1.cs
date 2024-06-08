using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraDeVida : MonoBehaviour
{ 
    // Start is called before the first frame update

    [SerializeField]private Image barraDeVidaImage;

    public void AlterarBarraDeVida(int vidaAtual, int vidaMaxima) // aqui é a função usada para diminuir o sprite da barra de vida
    {
        barraDeVidaImage.fillAmount = (float) vidaAtual / vidaMaxima;
    }
}
