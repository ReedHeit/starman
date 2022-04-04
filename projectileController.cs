using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileController : MonoBehaviour
{
    public float ProjectileSpeed;
    public ParticleSystem meteorHit;
    public AudioSource hit;
    // Start is called before the first frame update
    void Start()
    {
        hit = GameObject.FindGameObjectWithTag("hit").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        
        transform.position += transform.right * Time.deltaTime * ProjectileSpeed;

        if(Vector2.Distance(transform.position, player.transform.position) > 10)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Contains("Meteor"))
        {
            hit.Play();
        }
        Instantiate(meteorHit, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
