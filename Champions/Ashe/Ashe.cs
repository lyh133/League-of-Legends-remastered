using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ashe : Champion
{
	public GameObject projectile;
	public GameObject volleyProjectile;
	public Transform sample;
	public AudioSource adaSource;
	public AudioClip highHeel;
	public bool frostOn = false;
	public AudioClip[] volleySounds;
	private int AAstack;



	void Start(){
		ramped = false;
		AAstack = 0;
		anim = GetComponent<Animator>();
		health = 1700f;
    	maxHealth = 1700f;
		baseDamage = 100f;
		movementSpeed = 300;
		armor = 30f;
		attackSpeed = 0.8f;
		hitreactiontime = 0;
		healthRegain = 0.3f;
		InvokeRepeating("handlehealthRegain", 1f, 1f);
		projectile.GetComponent<ParticleSystem>().Stop();
	}


	bool isPlaying(Animator anim, string stateName)
	{
    if (anim.GetCurrentAnimatorStateInfo(0).IsName(stateName) &&
            anim.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f)
        return true;
    else
        return false;
	}

	public override void AA(){
		anim.CrossFadeInFixedTime("preAttack", 0.1f);
		disableAttack();
		Invoke("enableAttack",attackSpeed);
	}
	public void handleAA(){
		if(ramped){
			anglezero();
			Invoke("anglezero", 0.1f);
			Invoke("anglezero", 0.2f);
			Invoke("anglezero", 0.3f);
			Invoke("anglezero", 0.4f);
			Invoke("anglezero", 0.5f);

		}else{
			initIceBoltAngle(0);
		}
	}
	private void anglezero(){
		initIceBoltAngle(0);
	}
	public override void E(){
		frostOn = true;
		
	}
	public void Volley(){
		initVolleyBoltAngle(-20);
		initVolleyBoltAngle(-15);
		initVolleyBoltAngle(-10);
		initVolleyBoltAngle(-5);
		initVolleyBoltAngle(0);
		initVolleyBoltAngle(20);
		initVolleyBoltAngle(15);
		initVolleyBoltAngle(10);
		initVolleyBoltAngle(5);
	}
	public override void R(){
		playRandomVolleySound();
		anim.CrossFadeInFixedTime("Volley", 0.1f);
	}

	private void initVolleyBoltAngle(int degree){
		Vector3 newRotation = 
		 new Vector3(sample.transform.eulerAngles.x, 
		 			 sample.transform.eulerAngles.y+degree, 
		 			 sample.transform.eulerAngles.z);

		GameObject proj = Instantiate(volleyProjectile,sample.position
			,
			 Quaternion.Euler(newRotation));

		if(frostOn){
			proj.GetComponent<Volley>().frostOn = true;
		}

		proj.GetComponent<ParticleSystem>().Play();
		Destroy(proj, 5.0f);
	}

	private void initIceBoltAngle(int degree){
		 Vector3 newRotation = 
		 new Vector3(sample.transform.eulerAngles.x, 
		 			 sample.transform.eulerAngles.y+degree, 
		 			 sample.transform.eulerAngles.z);

		GameObject proj = Instantiate(projectile,sample.position
			,
			 Quaternion.Euler(newRotation));

		if(frostOn){
			proj.GetComponent<IceBolt>().frostOn = true;
		}

		proj.GetComponent<ParticleSystem>().Play();
		Destroy(proj, 5.0f);
	}

	private void playRandomVolleySound(){
		adaSource.clip = volleySounds[Random.Range(0, volleySounds.Length)];
        adaSource.Play();
	}

	private void muteAuto(){
		projectile.GetComponent<IceBolt>().mute = true;
	}
	private void unmuteAuto(){
		projectile.GetComponent<IceBolt>().mute = false;
	}
	void Update(){

		//handlehealthRegain();

		if(Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0)
		{
			if(isPlaying(anim,"preAttack")){
				anim.Play("idle");
			}

		}
		 
		else {
			// adaSource.clip = highHeel;
			// adaSource.Play();
		}

	}



}
