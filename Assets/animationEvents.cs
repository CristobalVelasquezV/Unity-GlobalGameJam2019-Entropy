using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class animationEvents : MonoBehaviour
{
    [SerializeField] GameObject camera1;
    [SerializeField] GameObject camera2;
    [SerializeField] GameObject camera3;
    [SerializeField] GameObject camera4;
    [SerializeField] GameObject camera5;
    [SerializeField] GameObject anim;

    [SerializeField] AudioClip animationSound;
    [SerializeField] AudioSource source;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }
    public void FirstCameraChange()
    {
        camera2.SetActive(true);
        camera1.SetActive(false);
        
    }

    public void SecondCameraChange()
    {
        camera2.SetActive(false);
        camera3.SetActive(true);
    }
    public void ThirdCameraChange()
    {
        camera3.SetActive(false);
        camera4.SetActive(true);
        FourChange();

    }

    public void FourChange() {
        camera4.SetActive(false);
        camera5.SetActive(true);
    }

    public void destroyAnimation() {
        anim.SetActive(false);
        GameManager.instance.setGameState(GameManager.GameState.Default);
    }

    public void soundEvent() {
        source.PlayOneShot(animationSound);
    }
}
