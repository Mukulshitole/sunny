using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityStandardAssets.Characters;


public class playerselect : MonoBehaviour

{
    [SerializeField] GameObject player;
    public Renderer renderer;
    public GameObject[] characters;
    public GameObject[] Selectedcharacterprefab;
    public int selectedcharacter = 0;
    public int selectedcharacter2 = 0;
    [SerializeField] private int raylength = 5;
    [SerializeField] private LayerMask layermaskinteract;
    private void FixedUpdate()
    {
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        Debug.DrawRay(transform.position, fwd * raylength, Color.red);
        // StartCoroutine(timedelay());
        // IEnumerator timedelay() {

        if (Physics.Raycast(transform.position, fwd, out hit, raylength, layermaskinteract.value))
        {
            // StartCoroutine(timedelay());
            //StartCoroutine(timedelay());
            if (hit.collider.CompareTag("next"))
            {

                
                renderer.material.color = Color.red;

                //characters[selectedcharacter].SetActive(false);

                //StartCoroutine(timedelay());
                characters[selectedcharacter].SetActive(false);
                selectedcharacter = (selectedcharacter + 1) % characters.Length;

                characters[selectedcharacter].SetActive(true);
                // yield return new WaitForSeconds(5f);

                player.GetComponent<FirstPersonController>().enabled = false;

            }
            else
            {
                renderer.material.color = Color.white;
            }

            if (hit.collider.CompareTag("previous"))
            {


                characters[selectedcharacter].SetActive(false);

                selectedcharacter--;
                if (selectedcharacter < 0)
                {
                    selectedcharacter += characters.Length;
                }
                //selectedcharacter = (selectedcharacter + 1) % characters.Length;

                characters[selectedcharacter].SetActive(true);
                player.GetComponent<FirstPersonController>().enabled = false;


            }
            if (hit.collider.CompareTag("start"))
            {

                PlayerPrefs.SetInt("selectedCharacter", selectedcharacter);

                Selectedcharacterprefab[selectedcharacter2].SetActive(false);
                selectedcharacter = PlayerPrefs.GetInt("selectedCharacter");
                GameObject prefab = Selectedcharacterprefab[selectedcharacter];
                // Selectedcharacterprefab[selectedcharacter].SetActive(false);

                Selectedcharacterprefab[selectedcharacter].SetActive(true);
                selectedcharacter2 = (selectedcharacter) % characters.Length;

                player.GetComponent<FirstPersonController>().enabled = false;


            }
        }   //StartCoroutine(timedelay());
            // }
    }
}
  


