using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class move : MonoBehaviour
{
    

    public float Speed = Random.Range(1f,2f);
    public float speed;
    public Vector3 start;
    public Vector3 asd;
    public float x = Random.Range(-3f, 3f);
    public float y = Random.Range(-3f, 3f);
    public float z = Random.Range(-2f, 2f);
    public Rigidbody Rigidbody;
    public GameObject obj;
    public 

    // Start is called before the first frame update
    void Start()
    {

        Rigidbody = GetComponent<Rigidbody>();

        y = Random.Range(-3f, 3f);
        x = Random.Range(-3f, 3f);

    }

    // Update is called once per frame
    void Update()
    {
        speed = Rigidbody.velocity.magnitude;
        
        if(speed >= 100f)
        {
            speed -= 1;
        }

        Rigidbody.velocity = new Vector3(x, y, 0);




        transform.Translate(start * Time.deltaTime);

        if(Input.GetKeyDown(KeyCode.Space))
        {
            Rigidbody.velocity = Vector3.zero;
        }

        if(Input.GetKey(KeyCode.W))
        {
            Rigidbody.velocity += Vector3.up * Speed;
        }

        if (Input.GetKey(KeyCode.S))
        {
            Rigidbody.velocity += Vector3.down * Speed;
        }

        if (Input.GetKey(KeyCode.A))
        {
            Rigidbody.velocity += Vector3.left * Speed;
        }

        if (Input.GetKey(KeyCode.D))
        {
            Rigidbody.velocity += Vector3.right * Speed;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            transform.position = new Vector3(0, 10.5f, 0);
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            x = Random.Range(1, 5);
        }

        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.CompareTag("wall"))
        {
            //transform.position = new Vector3(0, 10.5f, 0);

            x = -x;
            Rigidbody.velocity = new Vector3(x, y, 0);

            Instantiate(obj);

        }
        if (collision.collider.gameObject.CompareTag("top"))
        {
            //transform.position = new Vector3(0, 10.5f, 0);

            y = -y;
            Rigidbody.velocity = new Vector3(x, y, 0);
            Instantiate(obj);

        }
    }
}
