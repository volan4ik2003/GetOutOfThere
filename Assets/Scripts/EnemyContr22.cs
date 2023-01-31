using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyContr22 : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb;
    [SerializeField] float moveSpeed = 5;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddForce(transform.right * moveSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("TreeTrigger"))
        {
            moveSpeed = 0;
          StartCoroutine(Attack());
        }
    }

    IEnumerator Attack()
    {
        
        Tree.Instance.GetDamage(20);
        yield return new WaitForSeconds(2);
        StartCoroutine(Attack());
    }
}
