using UnityEngine;

public class PlayerDetect : MonoBehaviour {
    [HideInInspector]
    public CircleCollider2D selfCollider;
    public SpriteRenderer fatherRenderer;
    public Collider2D fatherCollider;
    private Animator animator;
    void Awake () {
        selfCollider = gameObject.GetComponent<CircleCollider2D> ();
        animator = this.GetComponent<Animator> ();
        fatherRenderer.enabled = false;
        fatherCollider.enabled = false;
    }

    private void OnTriggerEnter2D (Collider2D other) {
        if (other.name == "FireCar") {
            if (!fatherRenderer.enabled) {
                animator.Play ("Explosion");
            }
            // TODO

        }
    }
    public void FatherActive () {
        fatherRenderer.enabled = true;
        fatherCollider.enabled = true;
    }
}