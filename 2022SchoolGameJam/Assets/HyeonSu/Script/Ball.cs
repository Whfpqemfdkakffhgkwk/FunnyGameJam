using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody rb;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(gameObject.transform.position.normalized * 500, ForceMode.Force);
    }
    private void Update()
    {

    }
    // Update is called once per frame
    void FixedUpdate()
    {
        //Vector3 pos = rb.position;
        //rb.velocity = pos + transform.up * speed * Time.deltaTime;
    }
    //private void OnCollisionEnter(Collision collision)
    //{
    //    Vector3 incomingVector = collision.gameObject.transform.position.normalized;
    //    Vector3 normalVector = collision.contacts[0].normal;
    //    Vector3 reflectVector = Vector3.Reflect(incomingVector, normalVector);
    //    reflectVector = reflectVector.normalized;
    //    Debug.Log(reflectVector.normalized);
    //    rb.AddForce(reflectVector.normalized * 300, ForceMode.Force);

    //}
}
