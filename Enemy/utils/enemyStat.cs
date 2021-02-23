using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class enemyStat : MonoBehaviour
{
	public float max_health = 2500f;
	public float health = 2500f;
	public GameObject host;
	public Slider healthbar;
	private Animator anim;

	void Start(){
		anim = GetComponent<Animator>();
	}




	// public void takeDamage(float dmg){
	// 	health-=dmg;
	// 	adjustUI();
	// 	if(health <= 0){
	// 		die();
	// 	}

	// }
	// public void adjustUI(){
	// 	healthbar.value = health/max_health;
	// }
	// public void die(){
	// 	GetComponent<Enemy>().alive = false;
	// 	anim.Play("zombie_death");
	// 	Destroy(gameObject, 3.0f);
	// }



}
