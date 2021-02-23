using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptableAsheAABuff : ScriptableBuff
{
	public float dmgIncrease = 0.3f;
	public override TimedBuff InitializeBuff(GameObject obj){
   		this.Duration = 5f;
   		this.IsDurationRefreshed=true;
   		this.IsEffectStacked  = true;
   		return new AsheAABuff(this,obj);
   	}
}
