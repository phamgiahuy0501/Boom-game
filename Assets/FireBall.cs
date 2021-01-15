using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    private float speed = 400f;
    public Transform fireball;
    public Rigidbody2D rb;
    Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        float z = fireball.localEulerAngles.z;
        if(z == 0){
            direction = new Vector3(-1,0,0);
        }
        else if (z == 90){
            direction = new Vector3(0,-1,0);
        }else if (z == 270){
            direction = new Vector3(0,1,0);
        }else {
            direction = new Vector3(1,0,0);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 force = direction * speed * Time.deltaTime;
        rb.AddForce(force);
    }
    void Kill()
    {
        GetComponent<AudioSource>().Play();
        Destroy(gameObject);
    }
}
