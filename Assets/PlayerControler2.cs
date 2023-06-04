using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler2 : MonoBehaviour

{

    public float speed=5f;
    public KeyCode upkey;
    public KeyCode downkey;



    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(upkey) && transform.position.y < 5)
        {
            transform.position += Vector3.up * Time.deltaTime * speed;
        }
        if (Input.GetKey(downkey) && transform.position.y > -5)
        {
            transform.position += Vector3.down * Time.deltaTime * speed;
        }
    }
}