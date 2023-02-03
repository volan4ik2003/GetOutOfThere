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
        currAngl = 0;
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
