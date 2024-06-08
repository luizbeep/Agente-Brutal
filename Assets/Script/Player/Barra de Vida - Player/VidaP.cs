using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal.Internal;
using UnityEngine.SceneManagement;

public class VidaP : MonoBehaviour
{
    // Start is called before the first frame update

    private int vidaAtualP;
    public int vidaTotalP;
    public string cenaGameOver;
    public int danoMonstro;

    [SerializeField] private BarraDeVidaP barraDeVidaP;

    void Start()
    {
        vidaAtualP = vidaTotalP; // Atribuindo que quando iniciar o jogo o monstro terá vida completa

        barraDeVidaP.AlterarBarraDeVidaP(vidaAtualP, vidaTotalP); // função para diminuir a barra de vida

    }



    // Update is called once per frame
    void Update()
    {
        if (PlayerMovement.atingidoP == true) // condição para o monstro tomar dano, aqui no caso se apertado a tecla espaço ele recebe 10 de dano
        {
            AplicarDanoP(danoMonstro);
            PlayerMovement.atingidoP = false;
        }

        if (vidaAtualP <= 0) // condição para quando a vida se torne zero ou menos o monstro desapareça
        {
            Destroy(gameObject);
            SceneManager.LoadScene(cenaGameOver);

        }

    }

    private void AplicarDanoP(int dano) // aqui é para subtrair a vida atual do monstro aplicando o valor do método AplicarDano
    {
        vidaAtualP -= dano;

        barraDeVidaP.AlterarBarraDeVidaP(vidaAtualP, vidaTotalP); 

    }

    



}
