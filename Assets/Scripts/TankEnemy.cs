using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankEnemy : MonoBehaviour
{
    public float speed;
    public GameObject bullet;
    public Transform bulletPos;

    private float timer;
    private bool IsOnPosition = false;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 2)
        { 
            timer = 0;
            if(IsOnPosition)
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
            Debug.Log("LOL");
            StartCoroutine(StopTank());
        }
    }

    IEnumerator StopTank()
    {
        speed -= 1f;
        yield return new WaitForSeconds(0.1f);
        if (speed > 0)
        {
            StartCoroutine(StopTank());
        }
    }
}
