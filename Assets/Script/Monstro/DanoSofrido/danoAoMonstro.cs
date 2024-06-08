using Assets.Script.Monstro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal.Internal;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using System;

public class Vida : MonoBehaviour
{
    // Start is called before the first frame update
    public int vidaAtual;
    public int vidaTotal = 100;
    public int critico = 0;
    public string cenaWin;
    public GameObject itemColetado;
    Boolean itemColeta;
    [SerializeField] private BarraDeVida barraDeVida;
    void Start()
    {

        vidaAtual = vidaTotal; // Atribuindo que quando iniciar o jogo o monstro terá vida completa
        barraDeVida.AlterarBarraDeVida(vidaAtual, vidaTotal); // função para diminuir a barra de vida

    }

    // Update is called once per frame
    void Update()
    {

        itemColeta = itemColetado.GetComponent<Shooting>().itemColetado;

        if (itemColeta == true)
        {
            critico = 1;
        }
        else
        {
            critico = 0;
        }        


        if (vidaAtual <= 0) // condição para quando a vida se torne zero ou menos o monstro desapareça
        {
            Destroy(gameObject);
            SceneManager.LoadScene(cenaWin);
        }

    }

    public void AplicarDano(int dano, int critico) // aqui é para subtrair a vida atual do monstro aplicando o valor do método AplicarDano
    {
        vidaAtual -= dano;
        barraDeVida.AlterarBarraDeVida(vidaAtual, vidaTotal); ;
    }


}