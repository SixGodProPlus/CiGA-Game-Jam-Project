using UnityEngine;
using EveryFunc;
public class TargetFarAwayTrigger : FSMTrigger
{
    public override void Init()
    {
        triggerID = FSMTriggerID.TargetFarAway;
    }
    public override bool HandleTrigger(FSMBase fsm)
    {
        return Vector3.Distance(fsm.transform.position, fsm.targetTF.position) > fsm.highChaseRadius;
    }

}