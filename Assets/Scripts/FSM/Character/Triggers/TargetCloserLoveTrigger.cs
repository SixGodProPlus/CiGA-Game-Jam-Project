using UnityEngine;
using EveryFunc;
public class TargetCloserLoveTrigger : FSMTrigger
{
    public override void Init()
    {
        triggerID = FSMTriggerID.TargetCloserLove;
    }
    public override bool HandleTrigger(FSMBase fsm)
    {
        return Vector3.Distance(fsm.transform.position, fsm.targetTF.position) <= fsm.highChaseRadius;
    }

}
