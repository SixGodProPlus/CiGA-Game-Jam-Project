
using UnityEngine;

public abstract class ItemAction : MonoBehaviour {
    public abstract void Action();
    public virtual void ExitAction() {}
}