using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health = 10;
    public GameObject vfx;
    public Transform vfxPos;
    public AudioSource src;
    public AudioClip clip;
    void Start()
    {
        src = GetComponent<AudioSource>();
    }
    public void TakeDamage(int damage)
    {
        src.PlayOneShot(clip);
        health -= damage;
        if (vfx != null)
        {
            Instantiate(vfx, vfxPos.position, Quaternion.identity);
        }
        if (health <= 0 && gameObject != null)
        {
            Destroy(gameObject);
            Debug.Log("IM DEAD");
        }
    }
}
