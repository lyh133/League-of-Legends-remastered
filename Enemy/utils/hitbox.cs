using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitbox : MonoBehaviour
{
	private float damage = 350f;
	private List<GameObject> enemies = new List<GameObject>();
	public AudioSource hitSound;
	public GameObject host;



	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag == "Enemy"){
			if(!enemies.Contains(other.gameObject))
				enemies.Add(other.gameObject);
		}
	}
	void OnTriggerExit(Collider other){
		if(other.gameObject.tag == "Enemy"){
			if(enemies.Contains(other.gameObject)){
				enemies.Remove(other.gameObject);
			}

		}
	}
	public void applyDamage(){
		bool hit = false;
		foreach(GameObject enemy in enemies){
			if(enemy == null){
				enemies.Remove(enemy);
				continue;
			}
			enemy.GetComponent<Zombie>().takeDamage(damage);
			hit = true;
		}
		if(hit){
			host.GetComponent<warrior>().handleLifeSteal(damage);
			hitSound.Play();
		}
	}
}
