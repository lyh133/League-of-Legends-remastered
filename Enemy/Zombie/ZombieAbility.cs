using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAbility : MonoBehaviour
{
    


	private Animator anim;
	private GameObject player;
	private bool isJump = false;
	private float JumpStopRange = 1f;
	private float jumpDamage = 250f;
    void Start()
    {
        anim = GetComponent<Animator>();
        player =  GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        manageJump();
    }

    private float distanceToPlayer(){
    	return (Vector3.Distance (player.transform.position, transform.position));
    }



    public void jumpInit(){
    	isJump = true;
    	GetComponent<Zombie>().disableZombie();
    }


    private void Jump(){
    	anim.Play("Jump");
    	transform.position = Vector3.MoveTowards(transform.position, player.transform.position, 0.1f);
    }

    private void manageJump(){
    	if(!isJump)return;
    	Jump();
    	if(distanceToPlayer() < JumpStopRange){
    		isJump = false;
    		GetComponent<Zombie>().enableZombie();
    		player.GetComponent<Champion>().takeDamage(jumpDamage);
    	}
    }



}
