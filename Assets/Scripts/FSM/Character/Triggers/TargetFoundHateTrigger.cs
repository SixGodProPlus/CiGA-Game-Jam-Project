using EveryFunc;
using UnityEngine;
public class TargetFoundHateTrigger : FSMTrigger {
    public override void Init () {
        triggerID = FSMTriggerID.TargetFoundHate;
    }
    public override bool HandleTrigger (FSMBase fsm) {
        return fsm.targetTF != null && fsm.targetTF.CompareTag ("MyHate");
    }
}