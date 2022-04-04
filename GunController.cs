using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public GameObject bullet;
    public GameObject shootpoint;
    public AudioSource shoot;
    public AudioSource shoot2;
    public AudioSource shoot3;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (player.gameObject.GetComponent<PlayerController>().play == 0)
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 5.23f;

            Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);
            mousePos.x = mousePos.x - objectPos.x;
            mousePos.y = mousePos.y - objectPos.y;

            float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
            if (Input.GetMouseButtonDown(0))
            {
                Instantiate(bullet, shootpoint.transform.position, transform.rotation);
                int audio = Random.Range(0, 3);
                if (audio == 0)
                {
                    shoot.Play();
                }
                if (audio == 1)
                {
                    shoot2.Play();
                }
                if (audio == 2)
                {
                    shoot3.Play();
                }
            }
        }
    }
}
