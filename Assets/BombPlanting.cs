using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; 

public class BombPlanting : MonoBehaviour
{
    public Transform Player;
    public GameObject bombPrefab;
    public LayerMask bombMask;
    private int bombLength = 1;
    private int bombAmount = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         if (Input.GetKeyDown(KeyCode.Space)){
            PlantBomb();
        }
    }
    void PlantBomb() {
        if (bombAmount == 0)
            return;
        bombAmount -= 1;
        Vector3 bombPosition = Player.position;
        bombPosition.x = Mathf.Round(bombPosition.x); 
        bombPosition.y = Mathf.Round(bombPosition.y); 
        bombPosition.z = Mathf.Round(bombPosition.z);
        Collider2D[] c = Physics2D.OverlapCircleAll(bombPosition,0.1f,bombMask,0f,0f);
        for(int i=0; i < c.Length;i++)
        {
            if (c[i].gameObject.tag == "Bomb")
                return;
        }
        GameObject go = Instantiate(bombPrefab,bombPosition,Player.rotation) as GameObject;
        go.SendMessage("setLength",bombLength);
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Fire Amulet"){
            bombLength += 1;
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Bomb Amulet"){
            bombAmount += 1;
            Destroy(other.gameObject);
        }

    }
    public void isExploded(){
        bombAmount += 1;
    }
    
}
