using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class move : MonoBehaviour
{
    
    public float Speed;
    public float speed;
    public float x;
    public float y;
    public Rigidbody Rigidbody;
    public GameObject obj;
    public float LifeTime;
    public float end=2;

    // Start is called before the first frame update
    void Start()
    {

        Rigidbody = GetComponent<Rigidbody>();
        Speed = Random.Range(1f, 2f);
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

        //LifeTime -= Time.deltaTime;
        //if (LifeTime < 0){LifeTime += 10;Destroy(this.gameObject);}
        if(Input.GetKeyDown(KeyCode.Space)){Rigidbody.velocity = Vector3.zero;}

        if(Input.GetKey(KeyCode.W)){Rigidbody.velocity += Vector3.up * Speed;}

        if (Input.GetKey(KeyCode.S)){Rigidbody.velocity += Vector3.down * Speed;}

        if (Input.GetKey(KeyCode.A)){Rigidbody.velocity += Vector3.left * Speed;}

        if (Input.GetKey(KeyCode.D)){Rigidbody.velocity += Vector3.right * Speed;}

        if (Input.GetKeyDown(KeyCode.R)){transform.position = new Vector3(0, 10.5f, 0);}

        if (Input.GetKeyDown(KeyCode.Q)){ x = Random.Range(1, 5);}

        if(LifeTime >= end) { Destroy(this.gameObject); }
        if (x <= 1 && x >= -1) { x = x * 2; }
        if (y <= 1 && y >= -1) { y = y * 2; }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.CompareTag("wall"))
        {
            //transform.position = new Vector3(0, 10.5f, 0);

            x = -x;
            Rigidbody.velocity = new Vector3(x, y, 0);
            Instantiate(obj, new Vector3(0, 10.5f, 0), Quaternion.identity);
            LifeTime = LifeTime + 1;
        }
        if (collision.collider.gameObject.CompareTag("top"))
        {
            //transform.position = new Vector3(0, 10.5f, 0);

            y = -y;
            Rigidbody.velocity = new Vector3(x, y, 0);
            Instantiate(obj, new Vector3(0, 10.5f, 0), Quaternion.identity);
            LifeTime = LifeTime + 1;


        }
    }
}
