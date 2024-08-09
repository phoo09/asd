using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{

    public float Speed = Random.Range(1f,2f);
    public Vector3 start;
    public Vector3 asd;
    public float x;
    public float y;
    public float z;

    public GameObject obj;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 10.5f, 0);
        x = Random.Range(-1f, 1f);
        y = Random.Range(-1f, 1f);
        start = new Vector3(x, y, 0);
        

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(start * Time.deltaTime);

        if(Input.GetKeyDown(KeyCode.Space))
        {
            transform.position = new Vector3(0, 10.5f, 0);
        }

        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            transform.position += Vector3.forward * Speed;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.CompareTag("wall"))
        {
            x = -x;
            start = new Vector3(x, y, 0);
            Instantiate(obj);
            Destroy(this.obj);
        }
        if (collision.collider.gameObject.CompareTag("top"))
        {
            y = -y;
            start = new Vector3(x, y, 0);
            Instantiate(obj);
            Destroy(this.obj);
        }
        if (collision.collider.gameObject.CompareTag("boll"))
        {
            x = -x;
            y = -y;
            start = new Vector3(x, y, 0);
        }
    }
}
