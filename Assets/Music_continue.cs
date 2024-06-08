using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Music_continue : MonoBehaviour
{
    // Start is called before the first frame update
    private static Music_continue instance;
    public AudioSource Sons;
    public AudioClip cutscene1;
    public AudioClip fase1;
    public AudioClip fase2;
    public AudioClip fase3;
    public AudioClip fim;
    int currentSceneIndex;

    void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        if (currentSceneIndex == 0)
        {
            // Stop the music if the current scene is the menu (index 0)
            if (Sons.isPlaying)
            {
                Sons.Stop();
            }
        }
        else if (currentSceneIndex >= 1 && currentSceneIndex < 5)
        {
            if (Sons.clip != cutscene1)
            {
                changeSons(cutscene1);
            }
        }
        else if (currentSceneIndex >= 5 && currentSceneIndex < 7)
        {
            if (Sons.clip != fase1)
            {
                changeSons(fase1);
            }
        }
        else if (currentSceneIndex >= 7 && currentSceneIndex < 10)
        {
            if (Sons.clip != fase2)
            {
                changeSons(fase2);
            }
        }
        else if (currentSceneIndex >= 10 && currentSceneIndex < 13)
        {
            if (Sons.clip != fase3)
            {
                changeSons(fase3);
            }
        }
        else if (currentSceneIndex >= 13 && currentSceneIndex < 15)
        {
            if (Sons.clip != fim)
            {
                changeSons(fim);
            }
        }        
    }

    public void changeSons(AudioClip music)
    {
        Sons.Stop();
        Sons.clip = music;
        Sons.Play();
    }
}