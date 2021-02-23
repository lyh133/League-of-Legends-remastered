using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class warrior : Champion
{
    // Start is called before the first frame update
    public AudioSource swoosh;
    public GameObject HitBox;

    void Start(){
    	anim = GetComponent<Animator>();
    	health = 2100f;
    	maxHealth = 2100f;
		baseDamage = 350f;
		movementSpeed = 400;
		armor = 60f;
		attackSpeed = 0.7f;//was 1
		hitreactiontime = 0;
		healthRegain = 1f;
		lifeSteal = 0.03f;//was 0
		InvokeRepeating("handlehealthRegain", 1f, 1f);
    }
    public override void AA(){
    	anim.CrossFadeInFixedTime("preAttack", 0.1f);
    	disableAttack();
		Invoke("enableAttack",attackSpeed);
    }
	public void handleAA(){

		swoosh.Play();
	}
	public void applyDamage(){
		HitBox.GetComponent<hitbox>().applyDamage();
	}
	public override void E(){

		anim.CrossFadeInFixedTime("Slam", 0.1f);
	}
	public override void R(){
	}

}
