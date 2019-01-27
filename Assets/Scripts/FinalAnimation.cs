using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class FinalAnimation : MonoBehaviour
{

   
    [SerializeField] GameObject firstAnimation;
   
    [SerializeField] GameObject secondAnimation;


    [SerializeField] GameObject vcam1;
    [SerializeField] GameObject vcam2;
    [SerializeField] GameObject vcam3;

    [SerializeField] TriggerEnd tend;

    void Start()
    {

    }


 
    public void secondTransition()
    {
        vcam1.SetActive(false);
        StartCoroutine("desapearAnimation");
        vcam2.SetActive(true);
    }

    private IEnumerator desapearAnimation() {
        float totaltime = 0;
        while (totaltime<1.2) {
            totaltime += Time.deltaTime;
            yield return 1;
        }
        firstAnimation.SetActive(false);
        secondAnimation.SetActive(true);
        int n = MainCube.instance.getFollowNumber();
        TriggerEnd.instance.playDelayedSong();
        thirdTransition();
    }

    public void thirdTransition()
    {
        vcam2.SetActive(false);
        int n = MainCube.instance.getFollowNumber();
        vcam3.SetActive(true);
    }

 

}
