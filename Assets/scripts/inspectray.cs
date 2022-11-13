using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;
using UnityStandardAssets.Characters;


public class inspectray : MonoBehaviour
{

    [SerializeField] GameObject player;
    [SerializeField] GameObject scifi;
    //[SerializeField] GameObject box;
    [SerializeField] private int raylength = 5; // length of ray distance to cover
    [SerializeField] private LayerMask layermaskinteract; // to find layer in object
   
    [SerializeField] GameObject crosshair;  //image of crosshair in ui
    private bool iscrosshairactive; //checkcrosshair on object
    private bool doonce; // dont make the object active for long time


    private void FixedUpdate()
    {
        //player.SetActive(false);
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        Debug.DrawRay(transform.position, fwd * raylength, Color.red);

        if (Physics.Raycast(transform.position, fwd, out hit, raylength, layermaskinteract.value))
        // Debug.DrawRay(transform.position, fwd*raylength,Color.white);// raycast from forward direction to our poisition if hit the raycast within the lenth hit only layermaskinteract //gameObject == box )
        {
            if (hit.collider.CompareTag("Interactobject"))   // if hit object with gametag interactobject then
            {


                if (hit.collider != null)
                {
                    Destroy(hit.collider.gameObject);

                }
               
               
               
            }
            if (hit.collider.CompareTag("road"))
            {

                player.GetComponent<FirstPersonController>().enabled = false;


            }
            else
            {
                player.GetComponent<FirstPersonController>().enabled = true;
            }
            if (hit.collider!=CompareTag("road"))
            {

                player.GetComponent<FirstPersonController>().enabled = true;

            }
            if (hit.collider != CompareTag("road"))
            {

                player.GetComponent<FirstPersonController>().enabled = true;

            }
            if (hit.collider.CompareTag("home"))
            {

                player.GetComponent<FirstPersonController>().enabled = false;
                scifi.SetActive(true);
               
            }
            else
            {
                player.GetComponent<FirstPersonController>().enabled = true;
            }
            if (hit.collider.CompareTag("exit"))
            {

                player.GetComponent<FirstPersonController>().enabled = false;
                scifi.SetActive(false);

            }
            else
            {
                player.GetComponent<FirstPersonController>().enabled = true;
            }
            
        }
       
    }
    }
  



    

