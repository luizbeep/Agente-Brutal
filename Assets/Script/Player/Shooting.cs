using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject armaPadrao;
    public GameObject armaEspecial;
    public int danoArma;
    public bool itemColetado = false;
    public GameObject armaAtual;

    // Prefab do projetil
    public GameObject projectilePrefab;


    // Ponto de origem do projetil
    public Transform spawnPoint;

    // Taxa do disparo
    public float fireRate = 0f;

    // Proximo momento de disparo
    private float nextFireTime = 0f;

    // Força do projetil
    public float force = 30f;

    // Tempo de destruir projetil
    public float destroy = 20f;

    public string arma = "laser3";

    void Start()
    {
    }
    void Update()
    {
    }
    public void ShootOutrasFases()
    {
            if (Time.time >= nextFireTime)
            {

                if (itemColetado)
                {
                    armaAtual = Instantiate(armaEspecial);
                    StartCoroutine(ResetItemColetado());

                }
                else
                {
                    armaAtual = Instantiate(armaPadrao);

                }
                armaAtual.transform.position = spawnPoint.position;
                armaAtual.GetComponent<Rigidbody2D>().velocity = new Vector2(0, force); // Muda a direção para x ou y
                                                                                        // rigidbody.AddForce(spawnPoint.forward * force, ForceMode.Impulse);

                Destroy(armaAtual, destroy);

                nextFireTime = Time.time + fireRate;
            }
    }

    public void Shoot()
    {
            arma = "laser3";
            projectilePrefab = Resources.Load<GameObject>("itens/Fase3/"+arma); // trocando sprite para o sprite do item ultrajato

        if (Time.time >= nextFireTime)
        {
            GameObject projectile = Instantiate(projectilePrefab);
            projectile.transform.position = spawnPoint.position;
            projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(0, force); // Muda a direção para x ou y

            // rigidbody.AddForce(spawnPoint.forward * force, ForceMode.Impulse);

            Destroy(projectile, destroy);

            nextFireTime = Time.time + fireRate;
        }
    
    }

     public void ultrajato()
     {
            arma = "ultrajato3";
            projectilePrefab = Resources.Load<GameObject>("itens/Fase3/"+arma); // trocando sprite para o sprite do item ultrajato


            if (Time.time >= nextFireTime)
            {
                GameObject projectile = Instantiate(projectilePrefab);
                projectile.transform.position = spawnPoint.position;
                projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(0, force); // Muda a direção para x ou y

                // rigidbody.AddForce(spawnPoint.forward * force, ForceMode.Impulse);

                Destroy(projectile, destroy);

                nextFireTime = Time.time + fireRate;
            }
    }

     public void dispersante()
     {
            arma = "dispersante3";
            projectilePrefab = Resources.Load<GameObject>("itens/Fase3/"+arma); // trocando sprite para o sprite do item ultrajato


            if (Time.time >= nextFireTime)
            {
                GameObject projectile = Instantiate(projectilePrefab);
                projectile.transform.position = spawnPoint.position;
                projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(0, force); // Muda a direção para x ou y

                // rigidbody.AddForce(spawnPoint.forward * force, ForceMode.Impulse);

                Destroy(projectile, destroy);

                nextFireTime = Time.time + fireRate;
            }

    }

     public void sementes()
     {

            arma = "sementes3";
            projectilePrefab = Resources.Load<GameObject>("itens/Fase3/"+arma); // trocando sprite para o sprite do item ultrajato


            if (Time.time >= nextFireTime)
            {
                GameObject projectile = Instantiate(projectilePrefab);
                projectile.transform.position = spawnPoint.position;
                projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(0, force); // Muda a direção para x ou y

                // rigidbody.AddForce(spawnPoint.forward * force, ForceMode.Impulse);

                Destroy(projectile, destroy);

                nextFireTime = Time.time + fireRate;
            }
        
    }

     private IEnumerator ResetItemColetado()
    {
        yield return new WaitForSeconds(3);
        itemColetado = false;
    }       


}
