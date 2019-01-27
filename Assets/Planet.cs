using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    [SerializeField] Transform initial;
    [SerializeField] Transform final;
    [SerializeField] float angularRotation;
    [SerializeField] bool rotate;
    [SerializeField] bool translate;
    [SerializeField] float atackingRot;

    bool up = true;
    float t = 5;
    float totalTime = 0;
    float actualTime;

    float transformRotation;

    Vector3 v = Vector3.zero;
    float initialRotation;
    Rigidbody rb;
    void Start()
    {
        initialRotation = angularRotation;
       rb = GetComponent<Rigidbody>();
        if (translate) {
            StartCoroutine("TranslateUp");
        }
    }

    private void FixedUpdate()
    {
        Rotate();
    }

    void Rotate() {

        transformRotation = angularRotation*Mathf.Sin(Time.deltaTime);
        v.y = transformRotation;
        rb.angularVelocity= v;
    }

    IEnumerator TranslateUp()
    {
        totalTime = 0;
        up = true;
        while (totalTime <= t && up == true) {
            actualTime = totalTime/ t;
            transform.position = Vector3.Lerp(initial.position, final.position, actualTime);
            totalTime += Time.deltaTime;
            yield return 0;
        }
        up = false;
        StartCoroutine("TranslateDown");
    }

    IEnumerator TranslateDown() {
        totalTime = 0;
        up = false;
        while (totalTime <= t && up == false)
        {
            actualTime = totalTime / t;
            transform.position = Vector3.Lerp(final.position, initial.position, actualTime);
            totalTime += Time.deltaTime;
            yield return 0;
        }
        up = true;
        StartCoroutine("TranslateUp");
    }

    public void atackingRotation() {
        angularRotation = atackingRot;
    }

    public void defaultRotation() {
        angularRotation = initialRotation;
    }
}
