using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meteorController : MonoBehaviour
{
    public float speed;
    public float life;
    public GameObject debris;
    public ParticleSystem meteorBreak;
    public AudioSource die;
    // Start is called before the first frame update
    void Start()
    {
        
        life = Random.Range(1f, 10f);
        speed = Random.Range(0.1f, 2f);
        transform.localScale *= life;
        float type = Random.Range(0, 4);
        if(type == 1)
        {
            transform.position = new Vector2(transform.position.x + Random.Range(-20f, 20f), transform.position.y + 12);
        }
        if (type == 2)
        {
            transform.position = new Vector2(transform.position.x + Random.Range(-20f, 20f), transform.position.y + -12);
        }
        if (type == 3)
        {
            transform.position = new Vector2(transform.position.x + -20, transform.position.y + Random.Range(-12f, 12f));
        }
        if (type == 0)
        {
            transform.position = new Vector2(transform.position.x + 20, transform.position.y + Random.Range(-12f, 12f));
        }
    }

    // Update is called once per frame
    void Update()
    {
        die = GameObject.FindGameObjectWithTag("break").GetComponent<AudioSource>();
        transform.Rotate(0, 0, speed * Time.deltaTime);
        if(life <= 0)
        {
            int i = 0;
            float amount = transform.localScale.x;
            Instantiate(meteorBreak, transform.position, Quaternion.identity);
            while (i < amount)
            {
                int amountOfDebris = Random.Range(0, 4);
                if(amountOfDebris == 1)
                {
                    Instantiate(debris, transform.position, Quaternion.identity);
                }
                if (amountOfDebris == 2)
                {
                    Instantiate(debris, transform.position, Quaternion.identity);
                    Instantiate(debris, transform.position, Quaternion.identity);
                }
                if (amountOfDebris == 3)
                {
                    Instantiate(debris, transform.position, Quaternion.identity);
                    Instantiate(debris, transform.position, Quaternion.identity);
                    Instantiate(debris, transform.position, Quaternion.identity);
                }
                i++;
            }
            die.Play();
            Destroy(this.gameObject);
        }
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if(player.gameObject.GetComponent<PlayerController>().play != 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name.Contains("bullet"))
        {
            life -= 1;
        }
    }
}
