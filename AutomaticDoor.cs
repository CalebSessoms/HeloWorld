using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticDoor : MonoBehaviour
{
    public GameObject movingDoor;
    public GameObject message;
    public float min = -5f;
    public float speed = 2.5f;
    bool playerIsHere;

    // Start is called before the first frame update
    void Start()
    {
        playerIsHere = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(playerIsHere == true)
        {
            if(movingDoor.transform.position.y > min)
            {
                movingDoor.transform.Translate(0, -speed * Time.deltaTime, 0);
                Destroy(message);
            }
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            playerIsHere = true;
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            playerIsHere = false;
        }
    }
}
