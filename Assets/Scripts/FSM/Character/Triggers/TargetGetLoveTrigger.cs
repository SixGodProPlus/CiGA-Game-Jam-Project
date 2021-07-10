using EveryFunc;
using UnityEngine;
public class TargetGetLoveTrigger : FSMTrigger
{
    public override void Init()
    {
        triggerID = FSMTriggerID.TargetGetLove;
    }
    public override bool HandleTrigger(FSMBase fsm)
    {
        return Vector3.Distance(fsm.transform.position,fsm.targetTF.position)<=fsm.getRadius;
        //        return Vector3.Distance (fsm.transform.position, fsm.targetTF.position) <= fsm.;
    }

}