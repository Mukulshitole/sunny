using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class football : MonoBehaviour
{
    public Transform target;
    public int Force=30;
    public Rigidbody rb;
    public GameObject GameObject;
    public GameObject trgt;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Update()
    {
        /*if (Input.GetKey(KeyCode.Space))
        {
            shoot();
            
        }*/
    }

    public void shoot()
    {
        
        Vector3 Shoot = (target.position - this.transform.position).normalized;
        //GetComponent<Rigidbody>().AddForce(Shoot * Force + new Vector3(0, 3f, 0), ForceMode. Impulse);
        GetComponent<Rigidbody>().AddForce(Shoot * Force, ForceMode.Impulse);
        trgt.SetActive(false);
        StartCoroutine(Wait());

    }

    

    IEnumerator Wait() 
    {
        
        yield return new WaitForSeconds(4f);
        ResetGauge();//Reset Force and slider
    }

    public void ResetGauge()
    {
        GameObject.transform.position = new Vector3(12.68f, -2.831f, 293.89f);
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        trgt.SetActive(true);
    }

    
}
