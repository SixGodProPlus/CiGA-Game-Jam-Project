using System.Collections;
using System.Collections.Generic;
using EveryFunc;
using UnityEngine;
public class PlayerController : MonoBehaviour {
    [Tooltip ("玩家Rigidbody2D")]
    public Rigidbody2D playerRigidbody;

    [Tooltip ("玩家默认速度")]
    public float defaultSpeed;
    private Vector2 speed;
    //是否允许移动
    public bool walkable=true;

    void Update () {
        speed = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"));
        speed = speed.normalized;
    }
    private void FixedUpdate () {
        if (walkable) {
            playerRigidbody.velocity = speed * defaultSpeed * Time.fixedDeltaTime * ConstantList.speedPer;
        } else {
            playerRigidbody.velocity = Vector3.zero;
        }
    }
    private void OnTriggerEnter2D (Collider2D other) {
        if (other.CompareTag ("Interactive")) {
            other.GetComponent<ItemAction> ().Action ();
        }
        if (other.CompareTag("Stage")) {
            other.GetComponent<ItemAction>().Action();
        }
    }

    private void OnTriggerExit2D (Collider2D other) {
        if (other.CompareTag("Stage")) {
            other.GetComponent<ItemAction>().ExitAction();
        }
    }
}