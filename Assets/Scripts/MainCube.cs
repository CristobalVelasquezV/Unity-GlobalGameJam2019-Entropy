using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCube: MonoBehaviour
{
    Rigidbody rb;
    float h;
    float v;

    float h2;
    float v2;

    public static MainCube instance;

    private AudioSource source;
    [SerializeField] AudioClip spinSound;
    [SerializeField] AudioClip collitionClip;

    [SerializeField] int increaseParticlesAmount = 10;

    [SerializeField] int actualNumberParticles = 1000;

    [SerializeField] int decreaseParticleAmount = 10;

    [SerializeField] float maxDistanceAtraction = 15;

    [SerializeField] float forceAmplify;

    public Transform sizeTransform;

    public Transform[] followingPieces;

    [SerializeField] float velocityFactor;
    float powerUp;

    [SerializeField] float powerUpCooldown;

    private float cooldownTime;

    private int spinVelocity;
    private int totalFollow = 0;

    private bool spinning=false;

    void Start()
    {
        if (instance == null)
        {
            Debug.Log(this.gameObject.name);
            instance = this;
            rb = GetComponent<Rigidbody>();
            source = GetComponent<AudioSource>();
            powerUp = 1;
        }
        else {
            Debug.Log(this.gameObject.name);
            Destroy(this.gameObject);
        }
  
    }

    private void FixedUpdate()
    {
        if (GameManager.instance.getGameState() == GameManager.GameState.Default) {
            followMainCube();

            if (Input.GetButtonDown("Fire1"))
            {
                if (spinning == false)
                {
                    Debug.Log("powerup");
                    spinning = true;
                    soundSpin();
                    StartCoroutine("Spin");
                }
            }
            else
            {
                if (spinning == false)
                {
                    powerUp = 1;
                    spinVelocity = 4;
                }
            }
            rb.angularVelocity = Vector3.up * spinVelocity;
        }
    }

    private IEnumerator Spin() {
        cooldownTime = 0;

        while (cooldownTime< powerUpCooldown)
        {
            powerUp = 20;
            spinVelocity = 100;
            cooldownTime += Time.deltaTime;
            yield return 0;
        }
        powerUp = 1;
        spinVelocity = 4;
        spinning = false;
        Debug.Log("end Power up");
    }

    void Update()
    {
        if (GameManager.instance.getGameState() == GameManager.GameState.Default)
        {
            h = Input.GetAxis("Horizontal");
            v = Input.GetAxis("Vertical");

            h2 = Input.GetAxisRaw("HorizontalR");
            v2 = Input.GetAxisRaw("VerticalR");
            //Debug.Log(h2);
            //Debug.Log(v2);

            Vector3 dir = new Vector3(h, 0, v);


            if (Mathf.Abs(h) > 0.5 || Mathf.Abs(v) > 0.5)
            {

                dir = Camera.main.transform.TransformDirection(dir);
                dir.y = 0.0f;
                rb.velocity = dir.normalized * velocityFactor;

            }
        }
    }

    public void increaseParticleNumber(int n) {
        Vector3 v = new Vector3(increaseParticlesAmount+actualNumberParticles, 0, 0);
        actualNumberParticles += increaseParticlesAmount;
        sizeTransform.position = v;  
    }


    public void decreaseParticleNumber(int n) {
        if (-decreaseParticleAmount + actualNumberParticles > 0) {
            Vector3 v = new Vector3(-decreaseParticleAmount + actualNumberParticles, 0, 0);
            actualNumberParticles -= decreaseParticleAmount;
            sizeTransform.position = v;
        }
    }

    public int getFollowNumber() {
        int v = 0;
        foreach (Transform t in followingPieces)
        {
            FollowingCube cube = t.GetComponent<FollowingCube>();
            if (cube.getFollowing()) {
                v++;
            }
        }
        return v;
    }


    public void followMainCube() {

        int value = 0;
        foreach(Transform t in followingPieces){
            v++;
           FollowingCube cube = t.GetComponent<FollowingCube>();
            if ((this.transform.position - t.position).magnitude < maxDistanceAtraction)
            {
                
                if (cube.getFollowing())
                {
                    //already following do nothing
                }
                else
                {
                    cube.setFollowing(true);
                    cube.playColectedSound();
                }
                Rigidbody rb = t.GetComponent<Rigidbody>();
                Vector3 v = (this.transform.position - t.position).normalized;
                rb.AddForce(v * forceAmplify * powerUp);
            }
            else {
                if (cube.getFollowing()) {
                    cube.setFollowing(false);
                    cube.playUnColectedSound();
                }
            }
        }
        totalFollow = value;
    }


    public Vector3 getDirection() {
        return new Vector3(h2, 0, v2);
    }

    private void soundSpin() {
        source.PlayOneShot(spinSound);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Planet p = collision.collider.GetComponent<Planet>();
        if (p!=null ||collision.collider.tag=="PlanetaCuliao") {
            //Debug.Log("choca Planeta");
            playCollitionSound();
            repellMainCube();
        }
    }

    public void repellMainCube()
    {
        foreach (Transform t in followingPieces) {

            FollowingCube cube = t.GetComponent<FollowingCube>();
            if (cube.getFollowing()) {
                Vector3 v = (this.transform.position - t.position).normalized;
                Rigidbody rb = cube.GetComponent<Rigidbody>();
                rb.AddForce(-v * 1500);
            } 
        }
  
    }

    public void playCollitionSound() {
        source.PlayOneShot(collitionClip);
    }




















}
