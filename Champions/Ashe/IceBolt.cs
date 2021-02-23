using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBolt : MonoBehaviour
{
	private float damage = 300f;
	public AudioClip[] hitSounds;
	public  AudioSource  Sound;
	public bool mute = false;
	public bool frostOn = false;
	public GameObject player;
	void Start(){
		player=GameObject.FindWithTag("Player");
		if(player.GetComponent<Champion>().ramped){
			this.damage=100f;
		}
		if(!mute)
			playRandom();

	}
	void OnParticleCollision(GameObject other){
		if(other.gameObject.tag == "Enemy"){
			other.gameObject.GetComponent<Zombie>().takeDamage(damage);
			applySlow(other.gameObject);
			applyAsheAA();
		}
	}
	private void playRandom(){
		Sound.clip = hitSounds[Random.Range(0, hitSounds.Length)];
        Sound.Play();
	}
	private void applySlow(GameObject obj){
		if(!frostOn) return;
		GameObject buff = GameObject.Find("Buffs");
		ScriptableBuff sb = buff.GetComponent<Buffs>().getSlb();
		SlowBuff slb = (SlowBuff)sb.InitializeBuff(obj);
		obj.GetComponent<BuffableEntity>().AddBuff(slb);
	}	
	private void applyAsheAA(){
		GameObject buff = GameObject.Find("Buffs");
		ScriptableBuff ab = buff.GetComponent<Buffs>().getAAb();
		AsheAABuff aab = (AsheAABuff)ab.InitializeBuff(player);
		player.GetComponent<BuffableEntity>().AddBuff(aab);
	}
}
