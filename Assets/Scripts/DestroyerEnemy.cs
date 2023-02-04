using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyerEnemy : MonoBehaviour
{
    public float speed;
    public float distance;

    private bool movingRight = true;

    public Transform groundDetection;
    public GameObject bullet;
    public Transform bulletPos;
    private float count = 0;
    private float timer = 0;
    private bool IsOnPosition = false;

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer > 0.05f)
        {
            timer = 0;
            if (count < 5)
            {
                if (IsOnPosition)
                {
                    Shoot();
                    ++count;
                }
            }
        }
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);
        if(groundInfo.collider == false)
        {
            if (movingRight)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            }
            else 
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }
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
            IsOnPosition = false;
            count = 0;
        }
    }


}
