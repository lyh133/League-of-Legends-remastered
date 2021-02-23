using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blitzcrank : Champion
{
	public GameObject hand;
	public GameObject HitBox;
    void Start(){
    	anim = GetComponent<Animator>();
    	health = 2500f;
    	maxHealth = 2500f;
		baseDamage = 100f;
		movementSpeed = 400;
		armor = 150f;
		aaRange = 1000;
		attackSpeed = 1;
		hitreactiontime = 0;
    }
	public override void AA(){

		
	}
	public override void E(){
		//anim.CrossFadeInFixedTime("Grab", 0.1f);
		hand.GetComponent<RocketGrab>().init();
	}
	public override void R(){
		anim.CrossFadeInFixedTime("PowerFist", 0.5f);
	}
	public void PowerFist(){
		HitBox.GetComponent<BlitzMelee>().PowerFist();
	}
}
