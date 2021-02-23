using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// namespace ScriptableObjects
// {

	public class ScriptableSlowBuff : ScriptableBuff
	{
	   	public float SpeedDecrease = 0.3f;
	   	
	   	public override TimedBuff InitializeBuff(GameObject obj){
	   		this.Duration = 2f;
	   		this.IsDurationRefreshed=true;
	   		return new SlowBuff(this,obj);
	   	}
	}








//}


