using System;
using UnityEngine;

public class Defesa : MonoBehaviour
{
    public bool ativo;
    public GameObject ativar;

    // Referências para os materiais
    public Material maskMaterial;
    public Material defaultMaterial;

    // Referência para o Renderer do GameObject atual
    private Renderer objRenderer;

    void Start()
    {
        ativo = true;
        // Inicialize o Renderer
        objRenderer = GetComponent<Renderer>();

        // Certifique-se de que os materiais estão atribuídos
        if (maskMaterial == null || defaultMaterial == null)
        {
            Debug.LogError("Os materiais não estão atribuídos.");
            return;
        }

        // Iniciar com o material mask
        objRenderer.material = maskMaterial;
    }

    void Update()
    {
        ativo = ativar.GetComponent<ProjetilSpawnF3>().dano;

        // Alterar o material do GameObject com base no valor de 'ativo'
        if (ativo)
        {
            objRenderer.material = maskMaterial;
        }
        else
        {
            objRenderer.material = defaultMaterial;
        }
    }
}