using UnityEngine;

public class PlayerDect : MonoBehaviour
{
    [HideInInspector]
    public CircleCollider2D selfCollider;

    void Start() {
        selfCollider = gameObject.GetComponent<CircleCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.name == "FireCar") {
            // TODO
        }
    }
}
