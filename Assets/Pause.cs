using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Pause : MonoBehaviour
{
    void Update()
    {
        if (Input.GetButtonDown("Fire1")|| Input.GetButtonDown("Pause")) {
            SceneManager.LoadScene(1);
        }
    }
}
