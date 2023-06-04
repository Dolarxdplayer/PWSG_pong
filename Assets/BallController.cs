using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float speed = 5f;
    public Rigidbody2D rb2d;
    public Vector3 vel;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        ResetAndSendBallInRandomDirrection();
    }
    private void ResetAndSendBallInRandomDirrection()
    {
        rb2d.velocity = Vector3.zero;
        transform.position = Vector3.zero;
 rb2d.velocity = GenerateRandomVelocity(true)* speed;
      vel = rb2d.velocity;
    }
private Vector3 GenerateRandomVelocity(bool shouldReturnNormalized)
    {
        Vector3 velociti = new Vector3();
        velociti.x = Random.Range(-1f, 1f);
        velociti.y = Random.Range(-1f, 1f);
        if (shouldReturnNormalized)
        {
            return velociti.normalized;
        }
        return velociti;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector3 newVellociti = vel;
        newVellociti += new Vector3(Random.Range(-0.5f,0.5f), Random.Range(-0.5f, 0.5f));
        rb2d.velocity = Vector3.Reflect(newVellociti, collision.contacts[0].normal);
        vel = rb2d.velocity;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (transform.position.x>0)
        {
            print("left Player +1");
        }
        if (transform.position.x < 0)
        {
            print("right Player +1");
        }
        ResetAndSendBallInRandomDirrection();
    }
}
