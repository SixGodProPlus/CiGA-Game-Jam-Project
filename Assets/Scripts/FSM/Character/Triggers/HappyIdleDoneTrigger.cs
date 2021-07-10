using UnityEngine;
using EveryFunc;
public class HappyIdleDoneTrigger : FSMTrigger
{
    public override void Init()
    {
        triggerID = FSMTriggerID.HappyIdleDone;
    }
    public override bool HandleTrigger(FSMBase fsm)
    {
        return fsm.happyIdleTime <= 0;
    }

}