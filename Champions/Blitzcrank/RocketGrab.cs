using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketGrab : MonoBehaviour
{
    public Transform host;
    private bool forward = false;
    private bool backward = false;
    public GameObject refobj;
    private float grabDistance = 10f;
    private Vector3 handPOS;
    public GameObject handref;
    private GameObject target;
    public AudioSource source;
    public AudioClip grabinit;
    public AudioClip grabbed;
    private bool grabbing = false;
    void Start()
    {
    	    	Vector3 newRotation = 
	 	new Vector3(transform.eulerAngles.x, 
		 			 transform.eulerAngles.y, 
		 			 transform.eulerAngles.z-10f);
	 	this.transform.rotation = Quaternion.Euler(newRotation);
	 	handref.transform.rotation = Quaternion.Euler(newRotation);
        
    }

    // Update is called once per frame
    void Update()
    {

    	if(Vector3.Distance (transform.position, handref.transform.position) > grabDistance){
    		forward = false;
    		backward = true;
    	}

    	if(forward){
    		transform.Translate(-20 * Time.deltaTime, 0, 0);
    	}
    	if(backward){

    		pullTarget();

    		if(Vector3.Distance (transform.position, host.position) < 3 || 
    			Vector3.Distance (transform.position, host.position) > 20){
    			backward = false;
    			this.transform.position = handref.transform.position;
    			target = null;
    		}
    		transform.Translate(20 * Time.deltaTime, 0, 0);
    	}

    }

    private void pullTarget(){
    	if(target != null){
    		target.transform.position = Vector3.MoveTowards(target.transform.position, host.position, 0.5f);
    	}
    }


    public void init(){
    	forward = true;
    	source.clip = grabinit;
		source.Play();
    }
    void OnTriggerEnter(Collider other){
		if(other.gameObject.tag == "Enemy"){
			target = other.gameObject;
			if(forward){
				source.clip = grabbed;
				source.Play();
			}

		}
	}

}
