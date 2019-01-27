using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalAnimationTwo : MonoBehaviour
{
    [SerializeField] GameObject[] cubesFinal;
    [SerializeField] Transform initialPositionCube;
    public void showCredits() {
        MainCube.instance.transform.position = initialPositionCube.position;
        StartCoroutine("showCreditsTimer");
    }

    private IEnumerator showCreditsTimer() {
        float totalTime = 0;
        while (totalTime < 3) {
            totalTime += Time.deltaTime;
            yield return 1;
        }
        Credits.instance.showCredits();
    }

    public void deleteFinalCubes(int n)
    {
        for (int i = 0; i < n; i++)
        {
            cubesFinal[i].SetActive(false);
        }
    }
}
