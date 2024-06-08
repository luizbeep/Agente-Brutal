using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Timers;

public class movimentoF3 : MonoBehaviour
{
    public float moveSpeed; 
    Timer timer;
    float intervaloPrintMin = 1f; // Intervalo mínimo para imprimir e multiplicar moveSpeed (em segundos)
    float intervaloPrintMax = 5f; // Intervalo máximo para imprimir e multiplicar moveSpeed (em segundos)
    float timerCount = 0f;
    public static bool atingidoM = false;

    public GameObject monstro;
    public float estadoMonstro;

    public GameObject tiro;
    public string tiroAtual;


    // Start is called before the first frame update
    void Start()
    {
        // Inicializa o timer e define o intervalo inicial
        timer = new Timer();
        DefineIntervalo();
        timer.Elapsed += OnTimerElapsed;
        timer.Start();

    }

    // Update is called once per frame
    void Update()
    {
        // Move o objeto
        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);

        estadoMonstro = monstro.GetComponent<ProjetilSpawnF3>().randomAttack;
        tiroAtual = tiro.GetComponent<Shooting>().arma;

        // Atualiza o contador do timer
        timerCount += Time.deltaTime;
        
        // Verifica se o tempo para imprimir e multiplicar moveSpeed foi atingido
        if (timerCount >= timer.Interval / 1500) // Converte milissegundos para segundos
        {
            timerCount = 0f; // Reseta o contador
            Debug.Log("Millisegundos: " + timer.Interval);
            moveSpeed *= -1; // Inverte a direção
            DefineIntervalo(); // Define um novo intervalo para o timer
        }
    }

    void OnTimerElapsed(object sender, ElapsedEventArgs e)
    {
        // Ajusta a velocidade de movimento e redefine o intervalo do timer
        moveSpeed *= -1;
        DefineIntervalo();
        timer.Interval = (int)(Random.Range(intervaloPrintMin, intervaloPrintMax) * 1000); // Converte segundos para milissegundos
    }

    void DefineIntervalo()
    {
        // Define um novo intervalo aleatório
        timer.Interval = (int)(Random.Range(intervaloPrintMin, intervaloPrintMax) * 1000); // Converte segundos para milissegundos
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Inverte a direção quando colide com a borda
        if(collision.gameObject.tag == "Boundary")
        {
            moveSpeed *= -1;
        }

        if(collision.gameObject.tag == "shotP")
        {
            atingidoM = true;
        }


    }
}