using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FireBall : MonoBehaviour
{
	public float missleSpeed = 10f;
	private Vector3 basePosition;
	public float maxDistance = 20f;
	public GameObject blast;
	public  AudioSource fireballSound;
	public AudioClip travelSound;
	public AudioClip blastSound;
	private float damage = 300f;
	public bool frostOn = false;

	void Start(){

		AudioSource.PlayClipAtPoint (travelSound,transform.position, 1f);

		transform.eulerAngles = new Vector3(
		    transform.eulerAngles.x,
		    transform.eulerAngles.y,
		    transform.eulerAngles.z
		);



		basePosition = new Vector3(transform.position.x,
			transform.position.y,
			transform.position.z);
		
	}
    void Update()
    {
    	if(outOfRange()){
    		explode();
    	}
        propellForward();
    }
    private void initBlast(){

		Instantiate(blast,transform.position,transform.rotation);
	}
	private void explode(){

			AudioSource.PlayClipAtPoint (blastSound,transform.position, 1f);
		    initBlast();
    		Destroy(gameObject);
	}


	private bool outOfRange(){
		return (distanceTraveled() > maxDistance);
	}
	private void propellForward(){
		transform.position += transform.forward * Time.deltaTime * missleSpeed;
	}
	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag == "Enemy"){
			applySlow(other.gameObject);
			other.gameObject.GetComponent<Zombie>().takeDamage(finalDamage(damage));
			explode();
			
		}
	}
	private float distanceTraveled(){
		return Vector3.Distance (basePosition, transform.position);
	}
	private float finalDamage(float dmg){
		return (dmg+distanceTraveled()*40);
	}
	private void applySlow(GameObject obj){
		if(!frostOn) return;
		GameObject buff = GameObject.Find("Buffs");
		ScriptableBuff sb = buff.GetComponent<Buffs>().getSlb();
		SlowBuff slb = (SlowBuff)sb.InitializeBuff(obj);
		obj.GetComponent<BuffableEntity>().AddBuff(slb);
	}






}
