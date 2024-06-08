using Assets.Script.Item;
using System.Collections;
using UnityEngine;

public class SurgimentoItem : MonoBehaviour
{
    public float minX;
    public float maxX;
    public float interval = 5;
    public float speed = 4;
    private float screenTop;
    private float screenBottom;
    private float nextSpawnTime;
    public GameObject itemPrefab;
    // Use this for initialization
    void Start()
    {
        Camera cam = Camera.main;
        screenTop = cam.ViewportToWorldPoint(new Vector3(0, 1, cam.nearClipPlane)).y+10;
        screenBottom = cam.ViewportToWorldPoint(new Vector3(0, 0, cam.nearClipPlane)).y;
        SetNextSpawnTime();
        SetRandomPosition();
    }

    // Update is called once per frame
    void Update()
    {
         if (Time.time >= nextSpawnTime)
        {
            DescerItemPelaTela();
        }
    }
    
    private void DescerItemPelaTela()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
        if (transform.position.y < screenBottom)
        {
            SetNextSpawnTime();
            SetRandomPosition();
        }
    }
    private void SetNextSpawnTime()
    {
        nextSpawnTime = Time.time + interval;
    }
    private void SetRandomPosition()
    {
        float randomX = Random.Range(minX, maxX);
        transform.position = new Vector3(randomX, screenTop, transform.position.z);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("heroi"))
        {
            
            Destroy(gameObject);
            AdicionarDanoCritico adicionarDanoCritico = new();
            adicionarDanoCritico.addDanoCritico();
            StartCoroutine(ColetarItem());
        }
    }
    public IEnumerator ColetarItem()
    {
        
        SpawnNewItem();
        yield return null;
        Destroy(gameObject);
        
    }
    private void SpawnNewItem()
    {
        float randomX = Random.Range(minX, maxX);
        Vector3 spawnPosition = new Vector3(randomX, screenTop, transform.position.z);
        GameObject newItem = Instantiate(itemPrefab, spawnPosition, Quaternion.identity);
        newItem.AddComponent<SurgimentoItem>();
        BoxCollider2D boxCollider = newItem.AddComponent<BoxCollider2D>();
        boxCollider.isTrigger = true;
    }
}