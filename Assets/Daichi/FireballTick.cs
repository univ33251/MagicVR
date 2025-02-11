using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballTick : MonoBehaviour
{

    protected Vector3 forward;
    protected Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        Destroy(this.gameObject,5f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = forward * 10;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject);
    }

    public void setForward(Vector3 forward) {
        this.forward = forward;
    }
}
