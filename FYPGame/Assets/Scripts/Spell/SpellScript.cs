using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellScript : MonoBehaviour
{
    private Rigidbody2D myRigidbody;
    [SerializeField]
    private float speed;

    public Transform Target { get; private set; }
    private Transform source;
    private float damage;
    // Use this for initialization
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        // target = GameObject.FindGameObjectWithTag("Enemy").transform;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Initialize(Transform target, float damage, Transform source)
    {
        Target = target;
        this.damage = damage;
        this.source = source;
    }

    private void FixedUpdate()
    {
        if (Target != null)
        {
            //targets position - the fireballs position
            Vector2 direction = Target.position - transform.position;
            myRigidbody.velocity = direction.normalized * speed;
            //change rotation of fireball
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            //set it
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //check if whatever i collide with has the same transform as the target i want to hit
        //can take out if our spell wants to hit any enemy in target direction
        if (collision.tag == "HitBox" && collision.transform == Target)
        {
            speed = 0;
            collision.GetComponentInParent<Enemy>().TakeDamage(10, transform);
            GetComponent<Animator>().SetTrigger("impact");
            myRigidbody.velocity = Vector2.zero;
            Target = null;
        }
    }
}
