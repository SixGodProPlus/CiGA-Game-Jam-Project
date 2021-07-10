using UnityEngine;
using EveryFunc;
public class TargetFarAwayLoveTrigger : FSMTrigger
{
    public override void Init()
    {
        triggerID = FSMTriggerID.TargetFarAwayLove;
    }
    public override bool HandleTrigger(FSMBase fsm)
    {
        return Vector3.Distance(fsm.transform.position, fsm.targetTF.position) > fsm.highChaseRadius;
    }

}