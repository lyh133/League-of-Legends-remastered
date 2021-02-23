using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class AsheAABuff : TimedBuff
{

	public AsheAABuff(ScriptableBuff buff, GameObject obj) : base(buff, obj)
    {	
    	Duration = 0f;
        EffectStacks = 0;
    }
    protected override void ApplyEffect(){
		ScriptableAsheAABuff asheAAbuff = (ScriptableAsheAABuff) Buff;
		if(EffectStacks == 5){
			this.Obj.GetComponent<Champion>().ramped =true;

		}
    }
    public override void End(){
    	ScriptableAsheAABuff asheAAbuff = (ScriptableAsheAABuff) Buff;
    	this.Obj.GetComponent<Champion>().ramped =false;
    	EffectStacks = 0;
    }    
}
