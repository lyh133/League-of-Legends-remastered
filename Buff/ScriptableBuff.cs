using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ScriptableBuff : ScriptableObject
{
    /**
     * Time duration of the buff in seconds.
     */
    public float Duration;

    /**
     * Duration is increased each time the buff is applied.
     */
    public bool IsDurationRefreshed = false;

    /**
     * Effect value is increased each time the buff is applied.
     */
    public bool IsEffectStacked = false;

    public abstract TimedBuff InitializeBuff(GameObject obj);
}
