using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletDestroy : MonoBehaviour
{
     [SerializeField] private Sprite novoSprite; // Arraste o novo sprite aqui no Inspector
    private SpriteRenderer spriteRenderer;
    public int danoArma;
    // Start is called before the first frame update
    void Start()
    {
        atualizarDanoArma(danoArma);
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Enemy")
        {
            Vida danoMonstro = collision.gameObject.GetComponent<Vida>();
            if (danoMonstro != null)
            {
                if (danoMonstro.critico == 0)
                {
                    danoMonstro.AplicarDano(danoArma, danoMonstro.critico);
                }
                else
                {
                    int dano = danoArma * 2;
                    atualizarDanoArma(dano);
                    spriteRenderer = GetComponent<SpriteRenderer>();
                    spriteRenderer.sprite = novoSprite;
                    danoMonstro.AplicarDano(dano, danoMonstro.critico);
                }
            }
            Destroy(gameObject);
        }

        if(collision.gameObject.tag == "EnemyF3")
        {
            VidaF3 danoMonstro = collision.gameObject.GetComponent<VidaF3>();
            if (danoMonstro != null)
            {
                if (danoMonstro.critico == 0)
                {
                    danoMonstro.AplicarDano(danoArma, danoMonstro.critico);
                }


                else
                {
                    print(danoArma * 2);
                    spriteRenderer = GetComponent<SpriteRenderer>();
                    spriteRenderer.sprite = novoSprite;
                    danoMonstro.AplicarDano(danoArma, danoMonstro.critico);
                }
            }
            Destroy(gameObject);
        }        

    }
    public void atualizarDanoArma(int dano)
    {
        Shooting arma = GameObject.FindGameObjectWithTag("heroi").GetComponent<Shooting>();
        arma.danoArma = dano;
        danoArma = arma.danoArma;
    }
}