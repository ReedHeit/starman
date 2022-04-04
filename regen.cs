using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class regen : MonoBehaviour
{
    public AudioSource hit;
    // Start is called before the first frame update
    void Start()
    {
        hit = GameObject.FindGameObjectWithTag("energy").GetComponent<AudioSource>();
        float type = Random.Range(0, 4);
        if (type == 1)
        {
            transform.position = new Vector2(transform.position.x + Random.Range(-10f, 10f), transform.position.y + 6);
        }
        if (type == 2)
        {
            transform.position = new Vector2(transform.position.x + Random.Range(-10f, 10f), transform.position.y + -6);
        }
        if (type == 3)
        {
            transform.position = new Vector2(transform.position.x + -10, transform.position.y + Random.Range(-6f, 6f));
        }
        if (type == 0)
        {
            transform.position = new Vector2(transform.position.x + 10, transform.position.y + Random.Range(-6f, 6f));
        }
    }

    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player.gameObject.GetComponent<PlayerController>().play != 0)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "player")
        {
            hit.Play();
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            player.GetComponent<PlayerController>().life += player.GetComponent<PlayerController>().regen;
            Destroy(this.gameObject);
        }
    }
}
