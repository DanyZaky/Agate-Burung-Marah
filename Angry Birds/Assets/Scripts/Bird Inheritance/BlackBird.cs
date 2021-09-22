using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackBird : Bird
{
    [SerializeField]
    public float bombArea, force;
    public LayerMask LayertoHit;
    public bool _hasBomb = false;

    public GameObject ExplosionEffect;

    public void Explode()
    {
        if (State == BirdState.Thrown && !_hasBomb)
        {
            //membuat object collider circle area
            Collider2D[] objects = Physics2D.OverlapCircleAll(transform.position, bombArea, LayertoHit);

            //inisiasi
            foreach (Collider2D obj in objects)
            {
                Vector2 direction = obj.transform.position - transform.position;

                obj.GetComponent<Rigidbody2D>().AddForce(direction * force);
            }
            _hasBomb = true;

            Debug.Log("BOOOOM");

            //Instantiate(ExplosionEffect, transform.position, Quaternion.identity);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, bombArea);
    }

    public override void OnTap()
    {
        Explode();
    }
}
