using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VidaP : MonoBehaviour
{
    // Variáveis de vida
    private int vidaAtualP;
    public int vidaTotalP;
    public string cenaGameOver;
    public int danoMonstro;

    // Referência ao Canvas e à BarraDeVidaP
    private BarraDeVidaP barraDeVidaP;

    void Start()
    {
        vidaAtualP = vidaTotalP; // Atribuindo que a vida inicial é o valor total

        // Encontrar o Canvas na cena e a BarraDeVidaP dentro dele
        Canvas canvas = FindObjectOfType<Canvas>(); // Encontrar o Canvas na cena
        if (canvas != null)
        {
            barraDeVidaP = canvas.GetComponentInChildren<BarraDeVidaP>(); // Encontrar BarraDeVidaP dentro do Canvas
            if (barraDeVidaP != null)
            {
                barraDeVidaP.AlterarBarraDeVidaP(vidaAtualP, vidaTotalP); // Atualizar a barra de vida
            }
            else
            {
                Debug.LogError("BarraDeVidaP não encontrada no Canvas!");
            }
        }
        else
        {
            Debug.LogError("Canvas não encontrado na cena!");
        }
    }

    void Update()
    {
        // Verificar se o personagem foi atingido
        if (PlayerMovement.atingidoP == true)
        {
            AplicarDanoP(danoMonstro);
            PlayerMovement.atingidoP = false;
        }

        // Verificar se a vida do herói acabou
        if (vidaAtualP <= 0)
        {
            Destroy(gameObject); // Destruir o personagem
            SceneManager.LoadScene(cenaGameOver); // Carregar a cena de Game Over
        }
    }

    private void AplicarDanoP(int dano)
    {
        vidaAtualP -= dano; // Subtrair o dano da vida atual

        // Atualizar a barra de vida se a referência à barra de vida for válida
        if (barraDeVidaP != null)
        {
            barraDeVidaP.AlterarBarraDeVidaP(vidaAtualP, vidaTotalP);
        }
    }
}
