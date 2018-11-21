using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class playermovement : MonoBehaviour {
    public bool diamondcollide;
    public GameObject Win;
    
    public AudioClip footstep;
    private AudioSource source;
    public CharacterController2D controller;
    public Animator animator;
    public float speed = 20f;
    float LRmove = 0f;
    bool jump = false;
    public float vollrange = 0.8f;
    public float volhrange = 1.3f;
    
    void Awake () {
        
		source=GetComponent<AudioSource>();
        Win.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        LRmove = Input.GetAxisRaw("Horizontal") * speed;
        animator.SetFloat("Pspeed",Mathf.Abs(LRmove));
        if (Input.GetButtonDown("Jump")) {
            jump = true;
            //animator.SetBool("Pjump", jump); not working
        }
       

        
	}
   // public void OnLanding () {
       //}

    void FixedUpdate() {
        controller.Move(LRmove * Time.fixedDeltaTime, false, jump);
        jump = false;
        float vol = 0;
        if (Mathf.Abs(LRmove) > 1)
        {
            if (!source.isPlaying)
            {
                vol = Random.Range(vollrange, volhrange);
                source.pitch = Random.Range(2f, 3.2f);
                source.PlayOneShot(footstep, vol);
            }
        }
            else
            {
                source.Stop();
            }
       }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            controller.enabled = false;   // Disable the players movement.
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else if(other.gameObject.tag=="Diamond") {
        
            diamondcollide=true;
        }

            if (other.gameObject.tag == "Chest"  && diamondcollide==true)
            {
                Win.SetActive(true);
            }
        }
}

