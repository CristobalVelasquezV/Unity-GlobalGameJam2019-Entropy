using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orbitPlanet : MonoBehaviour
{
    [SerializeField] Transform orbirAround;
    [SerializeField] float angle;

    void Start()
    {
        float m = (orbirAround.position - this.transform.position).magnitude;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 angles = new Vector3(0, angle, 0);
        Vector3 newposition = rotatePoint(this.transform.position, orbirAround.transform.position, angles);
        transform.position = newposition;
    }

    Vector3 rotatePoint(Vector3 position, Vector3 pivot, Vector3 angles)
    {
        Vector3 dir = position - pivot; // get point direction relative to pivot
        dir = Quaternion.Euler(angles) * dir; // rotate it
        position = dir + pivot; // calculate rotated point
        return position;
    }
}
