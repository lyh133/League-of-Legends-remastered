using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class BlitzMelee : MonoBehaviour
{
	private float damage = 300f;
	private List<GameObject> enemies = new List<GameObject>();
	public AudioSource hitSound;
	private float knockUPdist = 3f;



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
	public  void PowerFist(){
		bool hit = false;
		foreach(GameObject enemy in enemies){
			if(enemy == null){
				enemies.Remove(enemy);
				continue;
			}
			enemy.GetComponent<Zombie>().takeDamage(damage);
			sendFly(enemy);
			hit = true;
		}
		if(hit){
			hitSound.Play();
		}
	}
	private void sendFly(GameObject target){
		target.GetComponent<Zombie>().stopMove(500);
		target.GetComponent<Zombie>().disableZombie();
		target.GetComponent<NavMeshAgent>().enabled = false;
		 target.transform.position = new Vector3(target.transform.position.x,target.transform.position.y+knockUPdist,target.transform.position.z);
	}
}
