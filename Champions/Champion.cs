using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Champion : MonoBehaviour
{

	public Animator anim;
    // Start is called before the first frame update
    protected float health;
    protected float maxHealth;
	protected float baseDamage;
	protected int   movementSpeed;
	protected float   armor;
	protected int   aaRange;
	protected float   attackSpeed;
	protected int   hitreactiontime;
	public bool canAttack = true;
	public GameObject healthbar;
	protected float healthRegain;
	protected float lifeSteal;
	public bool ramped;





	public void takeDamage(float dmg){
		health-=applyArmor(dmg);
		//anim.CrossFadeInFixedTime("reaction_large", 0.1f);
		adjustUI();


		if(health <0){
			die();
		}
	}

	private void die(){
		anim.Play("death");
	}

	private void adjustUI(){
		healthbar.GetComponent<healthBar>().setHealth(health/maxHealth);
	}


	private float applyArmor(float dmg){
		return (100f/(100f+armor))*dmg;
	}

	public void handleLifeSteal(float dmg){
		if(health <= maxHealth){
			health += dmg*lifeSteal;
			adjustUI();
		}
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

	public void handlehealthRegain(){
		if(health <= maxHealth){
			health+=healthRegain;
			adjustUI();
		}
	}

	public abstract void AA();
	public abstract void E();
	public abstract void R();

}
