using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D other) {
        if (other.gameObject.layer == 13){
            other.gameObject.GetComponent<AudioSource>().Play();
            Destroy(other.gameObject);
        }
    }
}
