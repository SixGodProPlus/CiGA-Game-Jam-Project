using EveryFunc;
using UnityEngine;
public class FindScareTrigger : FSMTrigger {
    public override void Init () {
        triggerID = FSMTriggerID.FindScare;
    }
    public override bool HandleTrigger (FSMBase fsm) {
        return fsm.happyIdleTime <= 0;
    }

}