using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;

    public float speed = 70f;

    public int damage = 1;


    public GameObject impacteffect;

    // Start is called before the first frame update
    public void seek (Transform _target)
    {
        target = _target;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
           
        }

        Vector3 direction = target.position - transform.position;
        float distanceFrame = speed * Time.deltaTime;

        if (direction.magnitude <= distanceFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(direction.normalized * distanceFrame, Space.World);



    }

    void HitTarget()

    {
        GameObject effectinstance = (GameObject)Instantiate(impacteffect, transform.position, transform.rotation);
        Destroy(effectinstance, 2f);
        Damage(target);
        

        Destroy(gameObject);

            
    }

    void Damage (Transform enemy)
    {
        Enemy e = enemy.GetComponent<Enemy>();

        if (e != null) 
        {
            Debug.Log("Damage: " + damage);
            e.TakeDamage(damage);
        }
    }
}
