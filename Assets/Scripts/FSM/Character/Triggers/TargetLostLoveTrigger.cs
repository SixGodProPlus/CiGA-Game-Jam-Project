using EveryFunc;
using UnityEngine;
public class TargetLostLoveTrigger : FSMTrigger {
    public override void Init () {
        triggerID = FSMTriggerID.TargetLostLove;
    }
    public override bool HandleTrigger (FSMBase fsm) {
        //TODO:targetLost
        //return false;
        if (Vector3.Distance (fsm.transform.position, fsm.targetTF.position) > fsm.findRadius + 1f) {
            fsm.targetTF = null;
            return true;
        } else return false;
    }

}