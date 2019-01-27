using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityPuller : MonoBehaviour
{

    [SerializeField] Transform[] pieces;
    [SerializeField] float forceAttractionPlayer;
    [SerializeField] float forceAttractionPieces;
    [SerializeField] int radiusAttraction;
    [SerializeField] bool puller;
    
    private Vector3 dist;
    private Rigidbody rb;
    private float magnitude;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        pullObjects();

        
    }

    void pullObjects() {
        foreach (Transform t in pieces) {
            dist = transform.position - t.position;
            Vector3 distinv= -transform.position + t.position;
            magnitude = dist.magnitude;
            if (magnitude < radiusAttraction) {
                rb = t.GetComponent<Rigidbody>();
                int pull = puller ? 1 : -1;
                if (t.gameObject.tag == "Player")
                {
                    rb.AddForce(pull * dist.normalized * forceAttractionPlayer / (magnitude * magnitude*magnitude));
                }
                else {
                    if (rb != null && pull == -1)
                    {
                        //Debug.Log("pushing");
                        //Debug.Log(distinv.normalized * forceAttractionPieces / (magnitude * magnitude));
                        rb.AddForce(distinv.normalized * forceAttractionPieces / (magnitude * magnitude));
                    }
                    else if (rb != null && pull == 1) {
                        rb.AddForce(pull * dist.normalized * forceAttractionPlayer / (magnitude * magnitude * magnitude));
                    }
                }
            }

        }
    }

  
}
