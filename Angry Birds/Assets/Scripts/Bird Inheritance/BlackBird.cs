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

    public CircleCollider2D circleCollider;
    public bool colliderMengecil = false;

    public void Explode()
    {
        if (State == BirdState.Thrown && !_hasBomb)
        {
            //membuat object collider circle area
            /*Collider2D[] objects = Physics2D.OverlapCircleAll(transform.position, bombArea, LayertoHit);

            //inisiasi
            foreach (Collider2D obj in objects)
            {
                Vector2 direction = obj.transform.position - transform.position;

                obj.GetComponent<Rigidbody2D>().AddForce(direction * force);
            }*/

            StartCoroutine(Bomb());

            _hasBomb = true;

            Debug.Log("BOOOOM");
            AudioManager.Instance.PlaySFX("black bird");

            Instantiate(ExplosionEffect, transform.position, Quaternion.identity);
        }
    }

    private IEnumerator Bomb()
    {
        circleCollider.radius = 1.5f;

        yield return new WaitForSeconds(0.5f);

        circleCollider.radius = 0.32f;
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
