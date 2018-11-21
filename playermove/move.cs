using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour {
    public CharacterController2D controller;
    float LRmove = 0f;
    public float runspeed = 10f;
    bool jump = false;

	// Use this for initialization

	
	// Update is called once per frame
	void Update () {
        LRmove = Input.GetAxisRaw("Horizontal") * runspeed;
        if (Input.GetButtonDown("Jump")) {
            jump = true;
        }
	}

    void FixedUpdate() {

        controller.Move(LRmove * Time.fixedDeltaTime,false,jump);
        jump = false;
    }


}
