using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Volley : MonoBehaviour
{
	private float damage = 100f;
	// public AudioClip[] hitSounds;
	// public  AudioSource  Sound;
	public bool frostOn = false;
	void Start(){


	}
	void OnParticleCollision(GameObject other){
		if(other.gameObject.tag == "Enemy"){
			other.gameObject.GetComponent<Zombie>().takeDamage(damage);
			applySlow(other.gameObject);
		}
	}

	private void applySlow(GameObject obj){
		if(!frostOn) return;
		GameObject buff = GameObject.Find("Buffs");
		ScriptableBuff sb = buff.GetComponent<Buffs>().getSlb();
		SlowBuff slb = (SlowBuff)sb.InitializeBuff(obj);
		obj.GetComponent<BuffableEntity>().AddBuff(slb);
	}
}
