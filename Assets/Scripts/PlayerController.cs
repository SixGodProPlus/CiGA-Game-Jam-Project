using System.Collections;
using System.Collections.Generic;
using EveryFunc;
using UnityEngine;
public class PlayerController : MonoBehaviour {
    [Tooltip ("玩家Rigidbody2D")]
    public Rigidbody2D playerRigidbody;

    [Tooltip ("玩家默认速度")]
    public float defaultSpeed;
    //玩家贴图
    [HideInInspector]
    public SpriteRenderer spriteRenderer;
    [HideInInspector]
    public Animator animator;
    private Vector2 speed;
    //是否允许移动
    public bool walkable = true;
    private void Awake () {
        spriteRenderer = this.GetComponentInChildren<SpriteRenderer> ();
        animator = this.GetComponentInChildren<Animator> ();
    }
    void Update () {
        speed = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"));
        speed = speed.normalized;
        PictureFlip ();
    }
    private void FixedUpdate () {
        if (walkable) {
            playerRigidbody.velocity = speed * defaultSpeed * Time.fixedDeltaTime * ConstantList.speedPer;
        } else {
            playerRigidbody.velocity = Vector3.zero;
        }
    }
    private void PictureFlip () {
        animator.SetFloat ("Speed", Mathf.Abs (speed.x) + Mathf.Abs(speed.y) / 2);
        if (animator.GetBool ("Slow") || animator.GetBool ("Dragged")) {
            if (GameManager.Instance.fireCar.transform.position.x - this.transform.position.x >= 0.05f) {
                spriteRenderer.flipX = false;
            } else if (GameManager.Instance.fireCar.transform.position.x - this.transform.position.x <= -0.05f) {
                spriteRenderer.flipX = true;
            }
        } else {
            if (playerRigidbody.velocity.x >= 0.05) {
                spriteRenderer.flipX = false;
            } else if (playerRigidbody.velocity.x <= -0.05) {
                spriteRenderer.flipX = true;
            }
        }

    }
    private void OnTriggerEnter2D (Collider2D other) {
        if (other.CompareTag ("Interactive")) {
            other.GetComponent<ItemAction> ().Action ();
        }
        if (other.CompareTag ("Stage")) {
            other.GetComponent<ItemAction> ().Action ();
        }
    }

    private void OnTriggerExit2D (Collider2D other) {
        if (other.CompareTag ("Stage")) {
            other.GetComponent<ItemAction> ().ExitAction ();
        }
    }
}