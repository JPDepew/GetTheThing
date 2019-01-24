using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject leaf;
    public float speed = 10;
    Vector3 direction;
    

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        transform.position = Vector3.Lerp(transform.position, transform.position + direction * speed * Time.deltaTime, 0.5f);
    }

    void GetInput()
    {
        float zMovement = Input.GetAxisRaw("Vertical");
        float xMovement = Input.GetAxisRaw("Horizontal");
        direction = new Vector3(xMovement, 0, zMovement).normalized;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Pickup")
        {
            float yPos = Random.Range(3f, 9f);
            float xPos = Random.Range(-2f, 2f);
            float zPos = Random.Range(-2f, 2f);

            Destroy(collision.gameObject);
            GameObject tempLeaf = Instantiate(leaf, transform.position, leaf.transform.rotation, transform);
            tempLeaf.transform.localPosition = new Vector3(xPos, yPos, zPos);
        }
    }
}
