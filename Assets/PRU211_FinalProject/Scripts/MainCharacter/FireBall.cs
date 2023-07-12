using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float damage;
    private bool hit;
    private BoxCollider2D boxCollider;
    private Animator anim;
    private float direction;
    [SerializeField] private LayerMask playerLayer;
    private float lifetime;
    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        speed = 30;
    }

    // Update is called once per frame
    void Update()
    {
        if (hit)
            return;
        float movementSpeed = speed * Time.deltaTime * direction;
        transform.Translate(movementSpeed, 0, 0);
        lifetime += Time.deltaTime;
        if (lifetime > 3)
            gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("FireBall"))
            return;
        hit = true;
        //boxCollider.enabled = false;
        anim.SetTrigger("explode");
        if (collision.tag == "Enemy")
            collision.GetComponent<HealthEnemy>().TakeDamage(damage);
    }

    public void SetDirection(float _direction)
    {
        lifetime = 0;
        direction = _direction;
        gameObject.SetActive(true);
        //boxCollider.enabled = true;
        hit = false;

        float localScaleX = transform.localScale.x;
        if (Mathf.Sign(localScaleX) != _direction)
        {
            localScaleX = -localScaleX;
        }
        transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
