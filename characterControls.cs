using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterControls : MonoBehaviour {
    public float moveSpeed;

    private Animator playerAnim;
    private bool playerMoving;
    private Vector2 lastMove;
	// Use this for initialization
	void Start () {
        playerAnim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        playerMoving = false; 

		if(Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f) // Player movement on the X axis
        {
            transform.Translate (new Vector3(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f));
            playerMoving = true;
            lastMove = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
        }

        if(Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f) // Player movement on the Y axis
        {
            transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime,  0f));
            playerMoving = true;
            lastMove = new Vector2(0f, Input.GetAxisRaw("Vertical"));
        }


        playerAnim.SetFloat("speedY", Input.GetAxisRaw("Vertical"));
        playerAnim.SetFloat("speedX", Input.GetAxisRaw("Horizontal"));
        playerAnim.SetBool("playerMoving", playerMoving);
        playerAnim.SetFloat("lastMoveX", lastMove.x);
        playerAnim.SetFloat("lastMoveY", lastMove.y);
    }

    
}
