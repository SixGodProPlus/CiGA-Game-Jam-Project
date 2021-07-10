using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeBehaviour : MonoBehaviour
{
    [Tooltip("起始端点")]
    public GameObject head;

    [Tooltip("末尾端点")]
    public GameObject tail;

    [Tooltip("绳索个数"), Range(2, 32)]
    public int ropeCount = 20;

    private GameObject ropePrefab;
    private float scale;

    // new Links will be inserted between headLink and tailLink
    private GameObject headLink, tailLink;
    
    // Start is called before the first frame update
    void Start()
    {
        ropePrefab = Resources.Load<GameObject>("Prefabs/Link");

        // add Link
        float distance = Vector3.Distance(head.transform.position, tail.transform.position);
        scale = distance / ropeCount;
        
        Vector3 curPos = head.transform.position;
        var lastRigidbody = head.GetComponent<Rigidbody2D>();
        for (int i = 0; i < ropeCount; ++i)
        {
            var rope = Instantiate<GameObject>(ropePrefab, curPos, Quaternion.identity);
            rope.GetComponent<HingeJoint2D>().connectedBody = lastRigidbody;
            rope.transform.localScale = new Vector3((float)scale, (float)scale, (float)scale);

            // link the last one to tail
            if (i == ropeCount - 1)
            {
                var joint = rope.AddComponent<HingeJoint2D>();
                joint.anchor = new Vector2(1.0f, 0);
                joint.connectedBody = tail.GetComponent<Rigidbody2D>();
            }

            // save headLink and tailLink
            if (i == 0)
                this.headLink = rope;
            if (i == 2)
                this.tailLink = rope;
            
            // update lastRigidbody and curPos
            lastRigidbody = rope.GetComponent<Rigidbody2D>();
            curPos = rope.transform.GetChild(0).position;
        }
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.P)) {
            addLink(6);
        }
    }

    public void addLink(int count)
    {
        var curPos = headLink.transform.GetChild(0).position;
        var lastRigidbody = headLink.GetComponent<Rigidbody2D>();
        GameObject newTail = tailLink;
        for (int i = 0; i < count; ++i)
        {
            var newLink = Instantiate(ropePrefab);
            newLink.transform.position = curPos;
            newLink.transform.localScale = headLink.transform.localScale;
            newLink.transform.rotation = headLink.transform.rotation;

            // rotate
            // if (i % 2 == 0)
                // newLink.transform.rotation = new Quaternion(0, 0, newLink.transform.rotation.z + 180, 0);
            
            newLink.GetComponent<HingeJoint2D>().connectedBody = lastRigidbody;
            
            // link tail to last one
            if (i == count - 1) {
                tailLink.GetComponent<HingeJoint2D>().connectedBody = newLink.GetComponent<Rigidbody2D>();
                tailLink.transform.position = newLink.transform.GetChild(0).position;
            }
            
            // save new tail
            if (i == 0)
                newTail = newLink;

            // update curPos and lastRigidbody
            lastRigidbody = newLink.GetComponent<Rigidbody2D>();
            curPos = newLink.transform.GetChild(0).position;
        }

        // update tail
        tailLink = newTail;
    }
}
