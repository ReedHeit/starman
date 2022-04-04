using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    public GameObject player;

    void Update()
    {
        float xMovement = Input.GetAxis("Horizontal");
        float yMovement = Input.GetAxis("Vertical");
        if (xMovement != 0 || yMovement != 0)
        {
            if (Vector2.Distance(player.transform.position, this.transform.position) > 1)
            {
                while (Vector2.Distance(player.transform.position, this.transform.position) > 1)
                {
                    transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, .00001f);
                }
                transform.position = new Vector3(transform.position.x, transform.position.y, -10);
            }
        }
    }
    private void FixedUpdate()
    {
        float xMovement = Input.GetAxis("Horizontal");
        float yMovement = Input.GetAxis("Vertical");
        if (xMovement == 0 && yMovement == 0)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, Vector2.Distance(player.transform.position, this.transform.position) / 25);
            transform.position = new Vector3(transform.position.x, transform.position.y, -10);
        }
    }
}
