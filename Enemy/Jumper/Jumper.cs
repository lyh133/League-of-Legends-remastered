using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Jumper : Zombie
{

	private float jumpCD = 30f;
	private float nextJump = 0f;
	private float distance;
	private float JumpRange = 7f;

    void Start()
    {
    	sightRange = 100f;
    	meleeRange = 2f;
		attackRange = 1f;
    	damage = 100f;
    	lifesteal = 0f;
    	alive = true;
    	health = 1500f;
    	max_health = 1500f;

    	nma = GetComponent<NavMeshAgent>();
    	anim = GetComponent<Animator>();
    	anim.applyRootMotion =false;
        player =  GameObject.FindWithTag("Player");
        nma.Warp(transform.position);
    }
    void Update()
    {
    	Distance=(Vector3.Distance (player.transform.position, transform.position));
    	if(!alive || !AI_Active)return;
        if(playerNearby()){
        	if(playerInAttackRange()){
        		init_Attack();
        	}else{
	        	walkToplayer();
        	}

        }
    }

    private void Jump(){
    	nextJump = Time.time + jumpCD;
    	GetComponent<ZombieAbility>().jumpInit();
    }
    private bool canJump(float distance){
    	return(distance < JumpRange) && (Time.time > nextJump);
    }
	public float Distance{

		get{return distance;}
		set
		{
			if(distance == value) return;
			distance = value;
			if(canJump(distance)){
				Jump();
			}
		}
	}    



}
