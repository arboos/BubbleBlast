using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Saw : MonoBehaviour
{
    public static Saw Instance { get; private set; }
    
    public Rigidbody2D sawRB;
    public Rigidbody2D pointRb;

    public ParticleSystem wallCollision;
    public ParticleSystem enemyCollision;

    public float maxDist = 2f;
    public float force = 2f;
    public bool isTouched = false;


    public AudioSource[] wallSounds;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        sawRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isTouched)
        {
            Vector2 mousPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if(Vector2.Distance(mousPos, pointRb.position) > maxDist)
            {
                sawRB.position = pointRb.position + (mousPos - pointRb.position).normalized * maxDist;
            }
            else
            {
                sawRB.position = mousPos;
            }
        }
        sawRB.velocity = new Vector2(Mathf.Clamp(sawRB.velocity.x, -5, 5), Mathf.Clamp(sawRB.velocity.y, -5, 5));

        if (sawRB.isKinematic == false)
        {
            sawRB.velocity = new Vector2(Mathf.Clamp(sawRB.velocity.x, -5, 5), Mathf.Clamp(sawRB.velocity.y, -5, 5));
        }
    }

    private void OnMouseDown()
    {
        isTouched = true;
        sawRB.isKinematic = true;
    }

    private void OnMouseUp()
    {
        isTouched=false;
        sawRB.isKinematic=false;
        

        SawLine.Instance.gameObject.SetActive(false);

        StartCoroutine(Fly());
    }

    IEnumerator Fly()
    {
        yield return new WaitForSeconds(0.1f);

        gameObject.GetComponent<SpringJoint2D>().enabled = false;
        this.enabled = false;
        GetComponent<Animator>().SetTrigger("Rotating");
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            ParticleSystem particles = Instantiate(wallCollision);
            particles.transform.position = other.GetContact(0).point;
            particles.Play();

            wallSounds[Random.Range(0, wallSounds.Length-1)].Play();
            
            Destroy(particles.gameObject, 1f);
        }
    }
}