using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playAgain : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void gogogo()
    {
        player.GetComponent<PlayerController>().play = 0;
        player.GetComponent<PlayerController>().life = player.GetComponent<PlayerController>().maxLife;
        Instantiate(player.GetComponent<PlayerController>().meteor);
    }
    public void upgradeSpeed()
    {
        if (player.GetComponent<PlayerController>().debris >= 50)
        {
            player.GetComponent<PlayerController>().speed += .1f;
            player.GetComponent<PlayerController>().debris -= 50;
        }
    }
    public void upgradeHealth()
    {
        if (player.GetComponent<PlayerController>().debris >= 50)
        {
            player.GetComponent<PlayerController>().maxLife += 25f;
            player.GetComponent<PlayerController>().debris -= 50;
        }
    }
    public void upgradeEnergy()
    {
        if (player.GetComponent<PlayerController>().debris >= 100)
        {
            player.GetComponent<PlayerController>().regen += 10f;
            player.GetComponent<PlayerController>().debris -= 100;
        }
    }
}
