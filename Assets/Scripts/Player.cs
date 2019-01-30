using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject leaf;
    public float speed = 10;
    public float lookSpeed = 1;
    Vector3 direction;
    CharacterController controller;
    public GameObject explosion;

    public delegate void ObjectCaptured();
    public static event ObjectCaptured onObjectCaptured;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();

        //transform.position = Vector3.Lerp(transform.position, transform.position + direction * speed * Time.deltaTime, 0.5f);
    }

    void GetInput()
    {
        //float zMovement = Input.GetAxisRaw("Vertical");
        //float xMovement = Input.GetAxisRaw("Horizontal");
        //direction = new Vector3(xMovement, 0, zMovement).normalized;
        //// Checking to make sure it is not off the screen
        //if (transform.position.x <= -6.3 && direction.x < 0)
        //{
        //    direction = new Vector3(0, 0, direction.z);
        //}
        //if (transform.position.x >= 6.3 && direction.x > 0)
        //{
        //    direction = new Vector3(0, 0, direction.z);
        //}
        //if (transform.position.z <= -4.3 && direction.z < 0)
        //{
        //    direction = new Vector3(direction.x, 0, 0);
        //}
        //if (transform.position.z >= 4.3 && direction.z > 0)
        //{
        //    direction = new Vector3(direction.x, 0, 0);
        //}
        float currentSpeed = 0;
        float rotateAmount = 0;

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            currentSpeed = speed;
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            currentSpeed = -speed;
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            rotateAmount -= lookSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            rotateAmount += lookSpeed * Time.deltaTime;
        }
        transform.Rotate(0, rotateAmount, 0);
        Vector3 dir = transform.TransformDirection(Vector3.forward);
        dir *= currentSpeed;
        controller.Move(dir * Time.deltaTime);

        Vector3 pos = transform.position;
        pos.y = 0;
        transform.position = pos;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Pickup")
        {
            float yPos = Random.Range(4f, 13f);
            float xPos = Random.Range(-3f, 4f);
            float zPos = Random.Range(-3f, 2f);

            onObjectCaptured?.Invoke();

            Destroy(collision.gameObject);
            GameObject tempLeaf = Instantiate(leaf, transform.position, leaf.transform.rotation, transform);
            tempLeaf.transform.localPosition = new Vector3(xPos, yPos, zPos);
            Instantiate(explosion, transform.position, transform.rotation);
        }
    }
}
