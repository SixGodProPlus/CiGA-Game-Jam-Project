using EveryFunc;
using UnityEngine;
public class PatrolDoneTrigger : FSMTrigger
{
    public override void Init()
    {
        triggerID = FSMTriggerID.PatrolDone;
    }
    public override bool HandleTrigger(FSMBase fsm)
    {
        return fsm.patrolTime <= 0;
    }

}