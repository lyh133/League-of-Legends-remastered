using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public abstract class Zombie : MonoBehaviour
{
    protected GameObject player;
    protected float sightRange;
    protected Animator anim;
    protected float meleeRange;
    protected float attackRange;
    protected float damage;
    protected float health;
    protected float max_health;
    protected bool alive;
    protected float lifesteal;
    protected NavMeshAgent nma;
    protected bool AI_Active = true;
    public AudioSource hitSoundSource;
    public AudioClip[] hitSounds;
    public Slider healthbar;


    public void disableZombie(){
    	AI_Active = false;
    }
    public void enableZombie(){
    	AI_Active = true;
    }


    protected bool playerNearby(){
    	return (Vector3.Distance (player.transform.position, transform.position) < sightRange);
    }
    protected bool playerInMeleeRange(){
    	return (Vector3.Distance (player.transform.position, transform.position) < meleeRange);
    }
    protected bool playerInAttackRange(){
    	return (Vector3.Distance (player.transform.position, transform.position) < attackRange);
    }
    protected void walkToplayer(){
    	nma.SetDestination(player.transform.position);
    	//rotatetoPlayer();
    	//transform.position = Vector3.MoveTowards(transform.position, player.transform.position, 0.005f);
    }

    protected void rotatetoPlayer(){
    		Vector3 direction = player.transform.position - this.transform.position;
			direction.y = 0;
			this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
			Quaternion.LookRotation(direction), 0.1f);
	}
	public void stopMove(int time){
		nma.isStopped = true;
		Invoke("moveAgain",time);
	}

	protected void moveAgain(){
		nma.isStopped = false;
	}
	protected void init_Attack(){
		anim.Play("zombie_attack");
	}
	protected void checkRange(){
		if(!playerInMeleeRange()){
			anim.Play("zombie_walk");
		}
	}
	protected void onHit(){
		if(playerInMeleeRange()){
			stopMove(1);
			player.GetComponent<Champion>().takeDamage(damage);
			applyLifeSteal(damage);
			playRandom();
		}
	}
	protected void applyLifeSteal(float dmg){
		health += (dmg*lifesteal);
		adjustUI();
	}
	protected void playRandom(){
		hitSoundSource.clip = hitSounds[Random.Range(0, hitSounds.Length)];
        hitSoundSource.Play();
	}
	protected void die(){
		alive = false;
		anim.Play("zombie_death");
		Destroy(gameObject, 3.0f);
	}
	public void takeDamage(float dmg){
		health-=dmg;
		adjustUI();
		if(health <= 0){
			die();
		}

	}
	protected void adjustUI(){
		healthbar.value = health/max_health;
	}

	protected void manageHeight(){
		if(transform.position.y > -7f){
			transform.Translate(0, -1 * Time.deltaTime, 0);
		}
	}


}
