using UnityEngine;
using UnityEngine.EventSystems;  // Para usar o EventTrigger
using UnityEngine.UI;  // Para usar o Button

[RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D))]
public class PlayerMovement : MonoBehaviour
{
    public static bool atingidoP = false;

    // Referências para o joystick de movimento e o botão de disparo
    public Joystick movementJoystick;   // Referência ao joystick fixo
    public Button buttonShoot;          // Referência ao botão de disparo
    public float playerSpeed;           // Velocidade do jogador

    private Rigidbody2D rb;
    private Shooting shootingScript;    // Referência ao script Shooting (onde está a função ShootOutrasFases)

    private void Start()
    {
        // Inicializa o Rigidbody2D
        rb = GetComponent<Rigidbody2D>();

        // Inicializa o joystick
        movementJoystick = FindObjectOfType<Joystick>(); // Encontramos o primeiro joystick na cena

        // Configura o botão de ataque para chamar a função ShootOutrasFases
        buttonShoot = GameObject.Find("ButtonShoot").GetComponent<Button>();  // Encontramos o botão "ButtonShoot"

        if (buttonShoot != null)
        {
            // Adiciona o evento de clique ao botão de disparo
            buttonShoot.onClick.AddListener(ShootOutrasFases);
        }
        else
        {
            Debug.LogWarning("Botão de disparo não encontrado!");
        }

        // Procurar o script "Shooting" no GameObject do herói
        shootingScript = GameObject.Find("heroi").GetComponent<Shooting>();  // Encontramos o GameObject "heroi"

        if (shootingScript == null)
        {
            Debug.LogWarning("Script Shooting não encontrado no herói!");
        }

        // Configura o EventTrigger para o botão de disparo
        EventTrigger trigger = buttonShoot.GetComponent<EventTrigger>();

        if (trigger == null)
        {
            trigger = buttonShoot.gameObject.AddComponent<EventTrigger>();  // Caso não tenha o EventTrigger, adicionamos um
        }

        // Criando o evento PointerDown
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerDown;
        entry.callback.AddListener((eventData) => OnPointerDown());

        // Adicionando o evento ao EventTrigger
        trigger.triggers.Add(entry);
    }

    private void FixedUpdate()
    {
        // Controle de movimento do jogador com o joystick fixo
        if (movementJoystick.Direction.y != 0 || movementJoystick.Direction.x != 0)
        {
            // Move o personagem com base na direção do joystick
            rb.velocity = new Vector2(movementJoystick.Direction.x * playerSpeed, movementJoystick.Direction.y * playerSpeed);
        }
        else
        {
            // Se não houver movimento no joystick, o jogador para
            rb.velocity = Vector2.zero;
        }
    }

    // Função chamada ao clicar no botão de disparo
    private void ShootOutrasFases()
    {
        Debug.Log("Disparo realizado!");
        // Lógica para disparar ou executar a ação correspondente
    }

    // Função chamada no evento PointerDown
    private void OnPointerDown()
    {
        if (shootingScript != null)
        {
            // Chama a função ShootOutrasFases no script Shooting
            shootingScript.ShootOutrasFases();
            Debug.Log("Botão pressionado - Disparo realizado!");
        }
    }

    // Quando o jogador colidir com o objeto de tag "shotM", ele será atingido
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "shotM")
        {
            atingidoP = true;
        }
    }
}