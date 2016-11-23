﻿using UnityEngine;
using System.Collections;

public class ObstacleBehaviour : MonoBehaviour {

    public float radius = 1.1f;
    public int durability = 3;
    private float durabilityLeft;


	// Use this for initialization
	void Start () {
        durabilityLeft = durability;

    }
	
	// Update is called once per frame
	void Update () {

        // Damage obstacle with player pick axe
        for (int i = 0; i < 4; i++)
        {
            if (Input.GetButtonDown("Pick axe-P"+i))
            {

                GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

                foreach (GameObject player in players)
                {
                    if (player.GetComponent<PlayerStats>().PlayerNumber == i)
                    {
                        if (Vector2.Distance(transform.position, player.transform.position) <= radius)
                        {

                            if (player.transform.position.x > transform.position.x && player.GetComponent<PlayerMovement>().getIsFacingEast() == false)
                            {
                                durabilityLeft -= 1;
                            }
                            else if (player.transform.position.x < transform.position.x && player.GetComponent<PlayerMovement>().getIsFacingEast() == true)
                            {
                                durabilityLeft -= 1;
                            }
                            if (player.transform.position.y > transform.position.y && player.GetComponent<PlayerMovement>().getIsFacingNorth() == false)
                            {
                                durabilityLeft -= 1;
                            }
                            else if (player.transform.position.y < transform.position.y && player.GetComponent<PlayerMovement>().getIsFacingNorth() == true)
                            {
                                durabilityLeft -= 1;
                            }
                        }
                    }
                }

            }
        }

        // Destroy fully damaged obstacles
        if (durabilityLeft < 1)
        {
            Destroy(gameObject);
        }

        // Restore obstacle durability if not touched for a while
        durabilityLeft += Time.deltaTime * 0.3f;
        if(durabilityLeft>durability)
        {
            durabilityLeft = durability;
        }
	}
}