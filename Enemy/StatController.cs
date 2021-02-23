using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatController : MonoBehaviour
{
	private Animator anim;
    // Start is called before the first frame update
    public float health = 1700f;
    public float maxHealth = 1700f;
	public float baseDamage = 50f;
	public int   movementSpeed = 300;
	public float   armor = 30;
	public int   aaRange = 100;
	public int   attackSpeed = 2;
	public int   hitreactiontime = 1;
	public bool canAttack = true;
	public GameObject healthbar;


	void Start(){
		anim = GetComponent<Animator>();
	}

	public void takeDamage(float dmg){
		health-=applyArmor(dmg);
		anim.CrossFadeInFixedTime("reaction_large", 0.1f);
		healthbar.GetComponent<healthBar>().setHealth(health/maxHealth);


		if(health <0){
			die();
		}
	}


	private void die(){
		anim.Play("death");
	}


	private float applyArmor(float dmg){
		return (100f/(100f+armor))*dmg;
	}


	public void disableAttack(){
		canAttack = false;
	}
	public void enableAttack(){
		canAttack = true;
	}
	public void disableautoAda(){
		disableAttack();
		Invoke("enableAttack", attackSpeed);
	}
	public void disabletakedmgAda(){
		disableAttack();
		Invoke("enableAttack", hitreactiontime);
	}

}