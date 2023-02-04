using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierEnemy : MonoBehaviour
{
    public float speed;
    public GameObject bullet;
    public Transform bulletPos;

    private float timer;
    private bool IsOnPosition = false;
    public Animator animator;

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer > 0.3f)
        {
            timer = 0;
            if (IsOnPosition)
                Shoot();
        }

        transform.Translate(Vector2.right * speed * Time.deltaTime);

        if (transform.position.x > 0)
        {
            transform.eulerAngles = new Vector3(0, -180, 0);
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }
    private void Shoot()
    {
        animator.Play("Shoot");
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            IsOnPosition = true;
            StartCoroutine(StopSoldier());
        }
    }

    IEnumerator StopSoldier()
    {
        speed -= 1f;
        yield return new WaitForSeconds(0.3f);
        if (speed > 0)
        {
            StartCoroutine(StopSoldier());
        }
    }
}
