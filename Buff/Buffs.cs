using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buffs : MonoBehaviour
{
    private ScriptableBuff slb;
    private ScriptableBuff aab;
    // void Start()
    // {
    //     ScriptableBuff slb = (ScriptableBuff)ScriptableObject.CreateInstance("ScriptableSlowBuff");

    // }
    public ScriptableBuff getSlb(){
    	if(slb == null){
    		slb = (ScriptableBuff)ScriptableObject.CreateInstance("ScriptableSlowBuff");
    	}

    	return slb;
    }
    public ScriptableBuff getAAb(){
    	if(aab == null){
    		aab = (ScriptableBuff)ScriptableObject.CreateInstance("ScriptableAsheAABuff");
    	}

    	return aab;
    }


}
