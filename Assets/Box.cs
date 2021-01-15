using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnTriggerEnter2D(Collider2D other) {
       
    }
    private void OnTriggerStay(Collider other) {
        
    }
    private void OnTriggerStay2D(Collider2D other) {
        if (other.gameObject.layer == 8){
            Destroy(gameObject);
        }
        else if (other.gameObject.layer == 13){
            other.gameObject.GetComponent<AudioSource>().Play();
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
