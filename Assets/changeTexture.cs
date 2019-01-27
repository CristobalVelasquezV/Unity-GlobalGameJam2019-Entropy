using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeTexture : MonoBehaviour
{

    public void ChangeTexture(Material m) {
        GetComponent<Renderer>().material = m;
    }
}
