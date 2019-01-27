using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using Cinemachine;

public class PauseMenu : MonoBehaviour {
    public GameObject pausePanel;
    public static PauseMenu instance;
    [SerializeField] AudioMixer mixer;
    [SerializeField] AudioSource source;
    [SerializeField] AudioClip pauseInClip;
    [SerializeField] AudioClip pauseOutClip;



    float mastervolume;
 
    private void Awake()
    {
        if (instance == null) {
            instance = this;
        }
    }

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }
    void Update () {
        
        if (Input.GetButtonDown("Pause")) {
            if (GameManager.instance.getGameState()==GameManager.GameState.Pause)
            {
                mixer.SetFloat("MasterVolume", mastervolume);
                unPause();
            }
            else {
                Pause();
                mixer.GetFloat("MasterVolume",out mastervolume);
                mixer.SetFloat("MasterVolume", 0f);
            }
        }

        if (Input.GetButtonDown("Quit") && GameManager.instance.getGameState() == GameManager.GameState.Pause) {
            quit();
        }
	}

    private void Pause()
    {
        playPauseIn();
        GameManager.instance.setGameState(GameManager.GameState.Pause);
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void unPause()
    {
        playPauseOut();
        GameManager.instance.setGameState(GameManager.GameState.Default);
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void pauseForMiniGame() {
        GameManager.instance.setGameState(GameManager.GameState.MiniGame);
    }

    public void unpauseForMiniGame()
    {
        GameManager.instance.setGameState(GameManager.GameState.Default);
    }

    public void goToMenu() {
        unPause();
        SceneManager.LoadScene(0);
    }

    public void guitGame() {
        Application.Quit();
    }

    public void playPauseIn()
    {
        source.PlayOneShot(pauseInClip);
    }

    public void playPauseOut() {
        source.PlayOneShot(pauseOutClip);
    }

    public void quit() {
        Debug.Log("quiting game");
        Application.Quit();
    }

  
}
