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
        Destroy(gameObject);
        if (other.gameObject.layer == 8){
            
        }
    }
    private void OnTriggerStay(Collider other) {
        
    }
    private void OnTriggerStay2D(Collider2D other) {
        Destroy(gameObject);
        if (other.gameObject.layer == 8){
            Destroy(gameObject);
        }
    }
}
