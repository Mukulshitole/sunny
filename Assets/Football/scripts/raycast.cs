using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.HID;
using UnityEngine.UIElements;

public class raycast : MonoBehaviour
{
    football football;
    public GameObject GameObject;
    

    // Start is called before the first frame update
    void Start()
    {
        /*football = GameObject.Find("Ball").GetComponent<football>();*/
        football = FindObjectOfType < football>();
    }

    // Update is called once per frame
    public void FixedUpdate()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out RaycastHit hitinfo, 20f))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hitinfo.distance, Color.red);

            if (hitinfo.collider.CompareTag("target"))   // if hit object with gametag interactobject then
            {
                //StartCoroutine(Wait());
                football.shoot();

            }
            
        }
    }

   /* IEnumerator Wait()
    {

        yield return new WaitForSeconds(0.5f);
        Debug.Log("ho");
        football.shoot();
    }
*/

}
