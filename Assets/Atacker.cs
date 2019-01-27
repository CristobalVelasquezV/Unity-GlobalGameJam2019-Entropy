using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atacker : MonoBehaviour
{

    [SerializeField] float radiusOfAtack;

    [SerializeField] float speedOfAtack;
    [SerializeField] Transform ataqued;
    [SerializeField] Transform initialPosition;
    [SerializeField] Planet p;

    [SerializeField] float amplifyForce;

    bool atack = false;
    bool returningToInitialPos = false;
    Rigidbody rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    Vector3 v;
    Vector3 f;
    void FixedUpdate()
    {
        v = ataqued.position - transform.position;
        f = initialPosition.position - transform.position;

        if (f.magnitude > radiusOfAtack&&!returningToInitialPos) {
            atack = false;
            StartCoroutine("returnToInitialPosition");
        }
        if (v.magnitude < radiusOfAtack && !(f.magnitude > radiusOfAtack)&&!atack) {
            StartCoroutine("atacking");
        }
    }

    private IEnumerator returnToInitialPosition() {
        returningToInitialPos = true;
        Debug.Log("returning to initial pos");
        while (f.magnitude > 0.2f && returningToInitialPos) {
            rb.AddForce(f.normalized * amplifyForce);
            yield return 0;
        }
        returningToInitialPos = false;
    }

    private IEnumerator atacking() {
        atack = true;
        Debug.Log("Atacking");
        p.atackingRotation();
        while (atack && !returningToInitialPos) {
            rb.AddForce( v.normalized * amplifyForce);
            yield return 0;
        }
        p.defaultRotation();
        atack = false;
    }
}
