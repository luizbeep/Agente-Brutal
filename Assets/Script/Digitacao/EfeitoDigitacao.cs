using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class EfeitoDigitacao : MonoBehaviour
{
    public string texto;
    char[] ctr;
    public Text viewer;
    // Start is called before the first frame update
    void Start()
    {
        ctr = texto.ToCharArray();
        StartCoroutine(mostrarTexto());
    }

    IEnumerator mostrarTexto()
    {
        int count = 0;
        while (count < ctr.Length)
        {
            yield return new WaitForSeconds(0.022f); // Reduzido para 0.022 segundos
            viewer.text += ctr[count];
            count++;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}