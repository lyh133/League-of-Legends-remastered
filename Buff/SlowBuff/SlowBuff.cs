using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;
public class SlowBuff : TimedBuff
{
	private NavMeshAgent nvm;
	// private int maxStack =3;
	// private int currStack = 0;
	public SlowBuff(ScriptableBuff buff, GameObject obj) : base(buff, obj)
    {
    	Duration = 0f;
        nvm = obj.GetComponent<NavMeshAgent>();
        EffectStacks = 0;
    }

    protected override void ApplyEffect(){
    	// if(currStack >= maxStack)return;
   		ScriptableSlowBuff slowbuff = (ScriptableSlowBuff) Buff;
   		nvm.speed *=(1-slowbuff.SpeedDecrease);
   		// currStack++;
    }
    public override void End(){
    	ScriptableSlowBuff slowbuff = (ScriptableSlowBuff) Buff;
    	//nvm.speed /=(float)(Math.Pow((1-slowbuff.SpeedDecrease),currStack));
    	nvm.speed /=(1-slowbuff.SpeedDecrease);
    	EffectStacks = 0;
    	// currStack=0;
    }

}
