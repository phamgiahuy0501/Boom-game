using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    private float countdown = 4f;

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;
        if (countdown <= 0f){
            FindObjectOfType<MapDestroyer>().Explode(transform.position);
           Destroy(gameObject); 
        }
    }
}
