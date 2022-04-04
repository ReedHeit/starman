using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuController : MonoBehaviour
{
    public RectTransform rt;
    public GameObject player;

    // Update is called once per frame
    void Update()
    {
        if(player.GetComponent<PlayerController>().play == 0)
        {
            rt.localPosition = new Vector2(0, -1500);
        }
        if (rt.localPosition.x != 0)
        {
            rt.localPosition = new Vector2(0, rt.localPosition.y);
        }

    }
    private void FixedUpdate()
    {
        if (rt.localPosition.y < 0 && player.GetComponent<PlayerController>().play != 0)
        {
            rt.localPosition = new Vector2(0, rt.localPosition.y + 50);
                
        }
    }
}
