using System;
using UnityEngine;
using TMPro;

public class DefesaText : MonoBehaviour
{
    public bool ativo;
    public GameObject ativar;

    // Referência para o componente TMP_Text do GameObject atual
    private TMP_Text tmpText;

    void Start()
    {
        ativo = true;
        // Inicialize o TMP_Text
        tmpText = GetComponent<TMP_Text>();

        // Certifique-se de que o componente TMP_Text está presente
        if (tmpText == null)
        {
            Debug.LogError("O componente TMP_Text não está presente no GameObject.");
            return;
        }

    }

    void Update()
    {
        ativo = ativar.GetComponent<ProjetilSpawnF3>().dano;

        // Alterar o tamanho da fonte com base no valor de 'ativo'
        if (ativo)
        {
            tmpText.fontSize = 0;
        }
        else
        {
            tmpText.fontSize = 525;
        }
    }
}