using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 playerPos;

    public float force = 10;
    public int damePlayer = 10;


    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        ShootThePlayer();
    }

    void ShootThePlayer()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;

        Vector2 heading = (playerPos - (Vector2)transform.position);
        float dist = heading.magnitude;
        Vector2 dir = heading / dist;

        rb.AddForce(dir * force);

        float angle = Mathf.Atan2(heading.y, heading.x) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(0, 0, angle);

        Destroy(gameObject, 4);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.isTrigger == false && collision.CompareTag("Player Main Collider"))
        {
            //Tru mau
            Destroy(this.gameObject);
        }
    }
}
