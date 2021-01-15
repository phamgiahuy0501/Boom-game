using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    private float countdown = 4f;
    private int bombLength = 1;
    public Rigidbody2D rigid;
    public Transform bomb;
    private static GameObject player;
    // Update is called once per frame
    void Start() {
        player = GameObject.FindWithTag("Player");
        Physics2D.IgnoreCollision(bomb.GetComponent<Collider2D>(), player.GetComponent<Collider2D>());
    }
    void Update()
    {
        countdown -= Time.deltaTime;
        if (countdown <= 0f){
            Explode(false);
        }
        float distance = Vector2.Distance(bomb.position, player.transform.position);
        if (distance >= 1.0f){
            Physics2D.IgnoreCollision(bomb.GetComponent<Collider2D>(), player.GetComponent<Collider2D>(), false );
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        int layer = other.gameObject.layer;
        switch (layer)
        {
            case 8:
            Explode(true);
            break;
            case 13:
            Explode(false);
            break;
        }
        Destroy(other.gameObject);
    }
    void Explode(bool isTriggerByAnotherBomb){
        FindObjectOfType<BombPlanting>().isExploded();
        FindObjectOfType<MapDestroyer>().Explode(transform.position,isTriggerByAnotherBomb, bombLength);
        Destroy(gameObject); 
    }
    void setLength(int length){
        bombLength = length;
    }
    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.layer == 12){
            Debug.Log("exit");
            Physics2D.IgnoreCollision(bomb.GetComponent<Collider2D>(), player.GetComponent<Collider2D>(), false );
        }
    }
}
