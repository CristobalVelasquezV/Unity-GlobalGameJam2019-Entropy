using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEnd : MonoBehaviour
{
    [SerializeField] GameObject firstFinalAnimation;

    [SerializeField] GameObject vcamGamePlay;
    [SerializeField] GameObject vcam1;
    [SerializeField] GameObject firstAnimation;

    [SerializeField] GameObject[] followers;
    
    [SerializeField] AudioClip audioFinal01;
    [SerializeField] AudioClip audioFinal02;
    [SerializeField] AudioSource source;

    public static TriggerEnd instance;

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
            source = GetComponent<AudioSource>();
        }
        else {
            Destroy(this.gameObject);
        }
      
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Player"&&GameManager.instance.getGameState()==GameManager.GameState.Default) {
            firstTransition();
            Debug.Log("game over");
            desapearFollowers();
            GameManager.instance.setGameState(GameManager.GameState.CutScene);
            Debug.Log(MainCube.instance.getFollowNumber());
            playAnimationSound01();
        }
    }

    public void firstTransition()
    {
        vcamGamePlay.SetActive(false);
        firstAnimation.SetActive(true);
        vcam1.SetActive(true);
    }

    public void desapearFollowers() {
        foreach(GameObject follower in followers)
        {
            follower.SetActive(false);
        }
    }

    public void playAnimationSound01() {
        source.PlayOneShot(audioFinal01);
    }

    public void playAnimationSound02() {
        source.PlayOneShot(audioFinal02);
    }

    public void playDelayedSong()
    {
        StartCoroutine("delaySong");
    }
    public IEnumerator delayFirstSong()
    {
        float totaltime = 0;
        while (totaltime < 0.7)
        {
            totaltime += Time.deltaTime;
            yield return 0;
        }
        playAnimationSound02();
    }


    public IEnumerator delaySong()
    {
        float totaltime = 0;
        while (totaltime < 0.7)
        {
            totaltime += Time.deltaTime;
            yield return 0;
        }
        playAnimationSound02();
    }
}
