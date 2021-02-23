using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slurper : MonoBehaviour
{
    private GameObject obj;
    private Vector3 position;
    private float speed;


    void Start()
    {
        //GetComponent<enemyStat>().
    }

    // Update is called once per frame
    void Update()
    {

    	if(Vector3.Distance(position, obj.transform.position) < 2){
    		Destroy(this);
    	}
        obj.transform.position = Vector3.MoveTowards(obj.transform.position, position, speed);
    }
}
