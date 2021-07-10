using UnityEngine;
using EveryFunc;
public class TargetFoundLoveTrigger : FSMTrigger
{
    public override void Init()
    {
        triggerID = FSMTriggerID.TargetFoundLove;
    }
    public override bool HandleTrigger(FSMBase fsm)
    {
        return fsm.targetTF != null&&fsm.targetTF.CompareTag("MyLove");
    }

}