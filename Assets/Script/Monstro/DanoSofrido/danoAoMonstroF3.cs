using Assets.Script.Monstro;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal.Internal;
using UnityEngine.SceneManagement;

public class VidaF3 : MonoBehaviour
{
    // Start is called before the first frame update
    public int vidaAtual;
    public int vidaTotal = 100;
    public int critico = 0;
    public string cenaWin;


    public Boolean tomarDano;
    public GameObject dano;

    [SerializeField] private BarraDeVida barraDeVida;

    void Start()
    {
        
        vidaAtual = vidaTotal; // Atribuindo que quando iniciar o jogo o monstro terá vida completa
        barraDeVida.AlterarBarraDeVida(vidaAtual, vidaTotal); // função para diminuir a barra de vida

    }



    // Update is called once per frame
    void Update()
    {

        tomarDano = dano.GetComponent<ProjetilSpawnF3>().dano;


        if (vidaAtual <= 0) // condição para quando a vida se torne zero ou menos o monstro desapareça
        {
            Destroy(gameObject);
            SceneManager.LoadScene(cenaWin);

        }

    }

    public void AplicarDano(int dano, int critico) // aqui é para subtrair a vida atual do monstro aplicando o valor do método AplicarDano
    {
        if (tomarDano == true)
        {
        vidaAtual -= dano;
        barraDeVida.AlterarBarraDeVida(vidaAtual, vidaTotal);
        }
    }


}
