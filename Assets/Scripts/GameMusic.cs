using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMusic : MonoBehaviour
{
    private static GameMusic _instance;
    public static GameMusic Instance { get { return _instance; } }

    public AudioSource audioRef;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Awake()
    {
        audioRef = transform.GetComponent<AudioSource>();
        audioRef.Play();

        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    public void EndMusic()
    {
        audioRef.Stop();
        Destroy(gameObject);
    }
}
