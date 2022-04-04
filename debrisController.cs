using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class debrisController : MonoBehaviour
{
    public AudioSource hit;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector2(this.transform.position.x + Random.Range(-1f,1f), this.transform.position.y + Random.Range(-1f, 1f));
        hit = GameObject.FindGameObjectWithTag("debris").GetComponent<AudioSource>();
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
            player.GetComponent<PlayerController>().debris += 1;
            Destroy(this.gameObject);
        }
    }
}
