using UnityEngine;
using EveryFunc;
public class TargetCloserTrigger : FSMTrigger
{
    public override void Init()
    {
        triggerID = FSMTriggerID.TargetCloser;
    }
    public override bool HandleTrigger(FSMBase fsm)
    {
        return Vector3.Distance(fsm.transform.position, fsm.targetTF.position) <= fsm.highChaseRadius;
    }

}
