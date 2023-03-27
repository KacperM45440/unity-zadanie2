using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuManager : MonoBehaviour
{
    public AudioMixer ostRef;
    public AudioMixer sfxRef;
    public TMP_Text ostText;
    public TMP_Text sfxText;

    public void LoadGameScene()
    {
        SceneManager.LoadScene("Game");
    }

    // Przy bardziej rozbudowanych ustawieniach ta logike rowniez mozna by bylo podpiac pod PlayerPrefs,
    // aby zapisywac wybor gracza przy wejsciu do gry
    private void Start()
    {
        sfxRef.GetFloat("SFX", out float x);
        ostRef.GetFloat("OST", out float y);

        if (x.Equals(-80))
        {
            sfxText.text = "SFX: OFF";
        }
        if (y.Equals(-80))
        {
            ostText.text = "OST: OFF";
        }
    }

    public void MuteSFX()
    {
        sfxRef.GetFloat("SFX", out float x);
        if (!x.Equals(-80))
        {
            sfxRef.SetFloat("SFX", -80);
            sfxText.text = "SFX: OFF";
        }
        else
        {
            sfxRef.SetFloat("SFX", 0);
            sfxText.text = "SFX: ON";
        }
    }

    public void MuteOST()
    {
        ostRef.GetFloat("OST", out float x);
        if (!x.Equals(-80))
        {
            ostRef.SetFloat("OST", -80);
            ostText.text = "OST: OFF";
        }
        else
        {
            ostRef.SetFloat("OST", 0);
            ostText.text = "OST: ON";
        }
    }
}
