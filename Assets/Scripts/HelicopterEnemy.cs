using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelicopterEnemy : MonoBehaviour
{
    public float speed;
    private float currAngl;
    public GameObject bullet;
    public Transform bulletPos;
    private float timer;
    private bool IsOnPosition = false;
    void Start()
    {
        if (transform.position.y != 34.8)
        {
            transform.position = new Vector3(transform.position.x, 34.8f, transform.position.z);
        }

        if (transform.position.x > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            currAngl = 0;
        }
        else
        {
            transform.eulerAngles = new Vector3(0, -180, 0);
            currAngl = -180;
        }
    }

    
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 0.5f)
        {
            timer = 0;
            if (IsOnPosition)
                Shoot();
        }

        transform.Translate(Vector2.left * speed * Time.deltaTime);

        
    }
    private void Shoot()
    {
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            IsOnPosition = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (currAngl == -180)
            {
                currAngl = 0;
            }
            else
            {
                currAngl = -180;
            }
            transform.eulerAngles = new Vector3(0, currAngl, 0);
        }
    }
}
