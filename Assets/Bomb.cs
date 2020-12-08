using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    private float countdown = 4f;
    private int bombLength = 1;
    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;
        if (countdown <= 0f){
            Explode(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.layer == 8){
            Explode(true);
        }
    }
    void Explode(bool isTriggerByAnotherBomb){
            FindObjectOfType<MapDestroyer>().Explode(transform.position,isTriggerByAnotherBomb, bombLength);
            Destroy(gameObject); 
    }
    void setLength(int length){
        bombLength = length;
    }
}
