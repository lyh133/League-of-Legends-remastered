using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : Zombie
{

    void Start()
    {
    	sightRange = 100f;
    	meleeRange = 3f;
		attackRange = 2f;
    	damage = 150f;
    	lifesteal = 0.5f;
    	alive = true;
    	health = 2500f;
    	max_health = 2500f;

    	nma = GetComponent<NavMeshAgent>();
    	anim = GetComponent<Animator>();
    	anim.applyRootMotion =false;
        player =  GameObject.FindWithTag("Player");
        nma.Warp(transform.position);
    }
    void Update()
    {
        manageHeight();
    	if(!alive|| !AI_Active)return;
        if(playerNearby()){
        	if(playerInAttackRange()){
        		init_Attack();
        	}else{
	        	walkToplayer();
        	}

        }
    }

}
