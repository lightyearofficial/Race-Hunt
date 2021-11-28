using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingCamera : MonoBehaviour
{
    public Transform player;
    public TMPro.TextMeshProUGUI distanceText;
    public List<Collectible> allCollectibles = new List<Collectible>();


    private void Start()
    {
        allCollectibles.AddRange(FindObjectsOfType<Collectible>());
    }

    private void Update()
    {
        transform.position = new Vector3(player.position.x,transform.position.y,player.position.z);
        float distance = Vector3.Distance(player.transform.position, ClosestCollectible().transform.position);
        distanceText.text = "" + Mathf.RoundToInt(distance) + "m";
        if(distance > 100)
        {
            distanceText.color = Color.white;
        } 
        else if (distance <= 25)
        {
           distanceText.color = Color.blue;
        }
        else if (distance <= 50)
        {
           distanceText.color = Color.green;
        }
        else if (distance <= 75)
        {
           distanceText.color = Color.yellow;
        }

        //transform.rotation = Quaternion.Euler(0f, 0f, player.rotation.z);
    }

    private Collectible ClosestCollectible()
    {
        Collectible closest = null;
        float closestDistance = 9999999f;
        foreach(Collectible collect in allCollectibles)
        {
            if(collect == null)
            {
                continue;
            }

            float distance = Vector3.Distance(player.position,collect.transform.position);
            if(distance < closestDistance)
            {
                closest = collect;
                closestDistance = distance;
            }
        }
        return closest;
    }
}
