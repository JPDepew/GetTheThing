using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovement : MonoBehaviour
{
    Vector3 direction;
    float speed = 10;

    public GameObject hitSystem;

    void Start()
    {
        direction = new Vector3(1, 0, 1);
    }

    void Update()
    {
        int temp = Random.Range(0, 2);
        if(temp == 0)
        {
            temp = Random.Range(0, 2);
            direction.x += temp == 0? 0.2f: -0.2f;
        }
        else
        {
            temp = Random.Range(0, 2);
            direction.z += temp == 0 ? 0.2f : -0.2f;
        }
        direction.Normalize();
        transform.position = Vector3.Lerp(transform.position, transform.position + direction * speed * Time.deltaTime, 0.5f);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.tag == "Wall")
        {
            float diffX = Mathf.Abs(other.contacts[0].point.x - transform.position.x);
            float diffZ = Mathf.Abs(other.contacts[0].point.z - transform.position.z);
            Instantiate(hitSystem, other.contacts[0].point, hitSystem.transform.rotation);
            if (diffX < 0.1f)
            {
                direction.z *= -1;
            }
            if (diffZ < 0.1f)
            {
                direction.x *= -1;
            }
        }
    }
}
