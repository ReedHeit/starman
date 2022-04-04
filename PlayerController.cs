using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    public float life;
    public float debris;
    public float waitTime;
    private float wait = 0;
    public GameObject meteor;
    public GameObject regenerate;
    public GameObject meteor1;
    public GameObject meteor2;
    public GameObject meteor3;
    public Sprite help;
    public Sprite idle;
    public Sprite left;
    public Sprite right;
    public float play = 0;
    public float maxLife = 100;
    public float regen = 10;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(meteor);
    }

    // Update is called once per frame
    void Update()
    {
        float xMovement = Input.GetAxis("Horizontal") * speed;
        float yMovement = Input.GetAxis("Vertical") * speed;
        if (play == 0)
        {
            rb.MovePosition(new Vector2(this.transform.position.x + xMovement, this.transform.position.y + yMovement));
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0 + xMovement * -75));

            float distanceToClosestEnemy = Mathf.Infinity;
            meteorController closestEnemy = null;
            meteorController[] allenemies = GameObject.FindObjectsOfType<meteorController>();

            foreach (meteorController currentEnemy in allenemies)
            {
                float distanceToEnemy = (currentEnemy.transform.position - this.transform.position).sqrMagnitude;
                if (distanceToEnemy < distanceToClosestEnemy)
                {
                    distanceToClosestEnemy = distanceToEnemy;
                    closestEnemy = currentEnemy;
                }
            }
            Debug.DrawLine(this.transform.position, closestEnemy.transform.position);
            if (distanceToClosestEnemy > 200)
            {
                int yee = Random.Range(0, 5);
                if (yee == 0)
                {
                    Instantiate(regenerate, transform.position, Quaternion.identity);
                }
                if (yee == 1)
                {
                    Instantiate(meteor, transform.position, Quaternion.identity);
                }
                if (yee == 2)
                {
                    Instantiate(meteor1, transform.position, Quaternion.identity);
                }
                if (yee == 3)
                {
                    Instantiate(meteor2, transform.position, Quaternion.identity);
                }
                if (yee == 4)
                {
                    Instantiate(meteor3, transform.position, Quaternion.identity);
                }
            }
            if (allenemies.Length == 0)
            {
                int yee = Random.Range(0, 5);
                if (yee == 0)
                {
                    Instantiate(regenerate, transform.position, Quaternion.identity);
                }
                if (yee == 1)
                {
                    Instantiate(meteor, transform.position, Quaternion.identity);
                }
                if (yee == 2)
                {
                    Instantiate(meteor1, transform.position, Quaternion.identity);
                }
                if (yee == 3)
                {
                    Instantiate(meteor2, transform.position, Quaternion.identity);
                }
                if (yee == 4)
                {
                    Instantiate(meteor3, transform.position, Quaternion.identity);
                }
            }

            if (life < 25)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = help;
            }
            else
            {
                if (xMovement < 0)
                {
                    gameObject.GetComponent<SpriteRenderer>().sprite = left;
                }
                if (xMovement > 0)
                {
                    gameObject.GetComponent<SpriteRenderer>().sprite = right;
                }
                if (xMovement == 0)
                {
                    gameObject.GetComponent<SpriteRenderer>().sprite = idle;
                }
            }
            if (life <= 0)
            {
                play = 1;
            }
        }
    }
    private void FixedUpdate()
    {
        wait += 1;
        if(wait >= waitTime && play == 0)
        {
            wait = 0;
            life -= 5;
        }
    }
}
