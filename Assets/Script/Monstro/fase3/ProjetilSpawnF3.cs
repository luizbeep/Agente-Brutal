using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class ProjetilSpawnF3 : MonoBehaviour
{
    public GameObject monstroProjetil;
    public string mAtual;
    public Sprite ataqueMonstro;

    public Sprite monstroAtual;

    public float spawnTimer;
    public float randomAttack;
    public float spawnMax = 1;
    public float spawnMin = 3;
    public GameObject tiro;
    public string tiroAtual;

    public bool dano;

    private bool canSwitchAttack = true;

    public IconeMonstro iconeMonstro;

    void Start()
    {
        dano = true;
        spawnTimer = Random.Range(spawnMin, spawnMax);
        ataqueMonstro = Resources.Load<Sprite>("ProjetilsMonstro/ataqueMonstro");
        monstroProjetil = Resources.Load<GameObject>("ProjetilsMonstro/ataqueMonstro");


        if (iconeMonstro == null)
        {
            iconeMonstro = GetComponent<IconeMonstro>();
        }
    }

    void Update()
    {
        spawnTimer -= Time.deltaTime;
        randomAttack = Random.Range(0, 3); // definindo uma variável para randomizar os ataques do monstro 
        iconeMonstro.icone.sprite = monstroAtual;

        tiroAtual = tiro.GetComponent<Shooting>().arma;

        if (spawnTimer <= 0)
        {
            Instantiate(monstroProjetil, transform.position, Quaternion.identity);
            spawnTimer = Random.Range(spawnMin, spawnMax);
        }

        if (canSwitchAttack)
        {

            // condicionando o ataque do monstro, para que ele alterne entre atacar com efeitos da primeira fase e segunda

            if (randomAttack == 0)
            {
                mAtual = "fumasferico";
                // alternando o sprite dos icones de acordo com o ataque do monstro
                ataqueMonstro = Resources.Load<Sprite>("ProjetilsMonstro/ataqueMonstro");
                monstroProjetil = Resources.Load<GameObject>("ProjetilsMonstro/ataqueMonstro");
                monstroAtual = Resources.Load<Sprite>("icones/Monstro");
                iconeMonstro.icone.sprite = monstroAtual;
                Debug.Log("o sprite atual é: " + randomAttack);

            }
            else if (randomAttack == 1)
            {
                mAtual = "petrolino";
                ataqueMonstro = Resources.Load<Sprite>("ProjetilsMonstro/ataqueMonstroF2");
                monstroProjetil = Resources.Load<GameObject>("ProjetilsMonstro/ataqueMonstroF2");
                monstroAtual = Resources.Load<Sprite>("icones/Monstro2");
                iconeMonstro.icone.sprite = monstroAtual;
                Debug.Log("o sprite atual é: " + randomAttack);

            }

            else if (randomAttack == 2)
            {
                mAtual = "megax";
                ataqueMonstro = Resources.Load<Sprite>("ProjetilsMonstro/ataqueMonstro2"); 
                monstroProjetil = Resources.Load<GameObject>("ProjetilsMonstro/ataqueMonstro2");
                monstroAtual = Resources.Load<Sprite>("icones/Monstro3");
                iconeMonstro.icone.sprite = monstroAtual;


            }
             
            // Alterar o ícone na interface do usuário


            StartCoroutine(SwitchAttackCooldown());
        }
            if (mAtual == "fumasferico" & tiroAtual == "sementes3" || tiroAtual == "laser3")
            {
                dano = true;
            } 
            else if (mAtual == "fumasferico" & tiroAtual != "sementes3" )
            {
                dano = false;
            }


            if (mAtual == "petrolino" & tiroAtual == "dispersante3" || tiroAtual == "laser3")
            {
                dano = true;
            }
            else if (mAtual == "petrolino" & tiroAtual != "dispersante3" )
            {
                dano = false;
            }

          
            if (mAtual == "megax" & tiroAtual == "ultrajato3" || tiroAtual == "laser3")
            {
                dano = true;
            }
            else if (mAtual == "megax" & tiroAtual != "ultrajato3")
            {
                dano = false;
            }
    }

    // criando um método para que o ataque alterne só depois de dois segundos
    IEnumerator SwitchAttackCooldown()
    {
        canSwitchAttack = false;
        yield return new WaitForSeconds(6f);
        canSwitchAttack = true;
    }

}