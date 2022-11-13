using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Ball : MonoBehaviour
{
    private bool stickToPlayer;
    [SerializeField] private Transform transformPlayer;
    [SerializeField] private Transform playerBallPosition;
    float speed;
    Vector3 previousLocation;
    Player scriptPlayer;

 
    public bool StickToPlayer {get => stickToPlayer; set => stickToPlayer=value; }

    // Start is called before the first frame update
    void Start()
    {
        playerBallPosition = transformPlayer.Find("Geometry").Find("BallLocation");
        scriptPlayer= transformPlayer.GetComponent<Player>();

    }

    // Update is called once per frame
    void Update()
    {
        if (!stickToPlayer)
        {
            float distanceToPlayer = Vector3.Distance(transformPlayer.position, transform.position);
            if (distanceToPlayer< 0.5)
                {
                stickToPlayer = true;
                scriptPlayer.BallAttachedToPlayer = this;

            }
        }
        else {
            transform.position = playerBallPosition.position;
            Vector3 currentLocation = new Vector3(transform.position.x, transform.position.z);
            speed = Vector3.Distance(currentLocation, previousLocation) / Time.deltaTime;
            transform.Rotate(new Vector3(transformPlayer.right.x, 0, transformPlayer.right.z), speed, Space.World);
            previousLocation = currentLocation;



        }

    }
}

