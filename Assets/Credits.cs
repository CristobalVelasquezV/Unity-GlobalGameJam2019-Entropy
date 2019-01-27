using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credits : MonoBehaviour
{
    private bool show = false;
    [SerializeField] GameObject creditPanel;

    [SerializeField] GameObject finalAnimation;
    [SerializeField] GameObject initialAnimation;

    [SerializeField] GameObject initialCamera;
    [SerializeField] GameObject finalCamera;

  

    [SerializeField] GameObject[] followers;
    public static Credits instance;

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else {
            Destroy(this.gameObject);
        }
    }
    float totalTime = 0;
    [SerializeField] float showingTime = 5;

    public void showCredits() {
        if (show == false) {
            show = true;
            creditPanel.SetActive(true);
            StartCoroutine("creditsTimer");
        }
        finalAnimation.SetActive(false);
    }

    public void dontShowCredits() {
        if (show == false) {
            creditPanel.SetActive(false);
        }
    }
    private IEnumerator creditsTimer() {
        totalTime = 0;
        while (totalTime < showingTime && show == true) {
            totalTime += Time.deltaTime;
            yield return 1;
        }
        show = false;
        dontShowCredits();
       
        GameManager.instance.setGameState(GameManager.GameState.Default);
        appearFollowers();
        finalCamera.SetActive(false);
        initialCamera.SetActive(true);
        initialAnimation.SetActive(true);
    }
    
        public void appearFollowers()
        {
            foreach (GameObject follower in followers)
            {
                follower.SetActive(true);
            }
        }
    
}
