using EveryFunc;
using UnityEngine;
public class TargetLostHateTrigger : FSMTrigger {
    public override void Init () {
        triggerID = FSMTriggerID.TargetLostHate;
    }
    public override bool HandleTrigger (FSMBase fsm) {
        if (Vector3.Distance (fsm.transform.position, fsm.targetTF.position) > fsm.findRadius + 1f) {
            fsm.targetTF = null;
            return true;
        } else {
            return false;
        }
    }
}