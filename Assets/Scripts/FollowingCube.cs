using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingCube : MonoBehaviour
{
    [SerializeField] AudioSource source;
    [SerializeField] AudioClip clipColected;
    [SerializeField] AudioClip clipUncolected;
    [SerializeField] changeTexture change;


    [SerializeField] Material oldMaterial;
    [SerializeField] Material lightedMaterial;

    private bool following = false;


    private bool changingColor = false;


    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    void Update()
    {

    }

    public void playColectedSound() {
        //Debug.Log("Colected");
        source.clip = clipColected;
        source.Play();
    }

    public void playUnColectedSound() {
        //Debug.Log("UnColected");
        source.clip = clipUncolected;
        source.Play();
    }

    public bool getFollowing() {
        return following;
    }

    public void setFollowing(bool set) {
        following = set;
        if (set)
        {
            change.ChangeTexture(lightedMaterial);
        }
        else {
            change.ChangeTexture(oldMaterial);
        }
    }

    private IEnumerator changeColor() {

        while (changingColor) {
            if (following)
            {

            }
            else {

            }
            yield return 0;
        }
        changingColor = false;
        
    }
}
