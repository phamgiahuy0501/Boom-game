using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; 

public class BombPlanting : MonoBehaviour
{
    public Transform Player;
    public GameObject bombPrefab;
    public LayerMask bombMask;
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
        Instantiate(bombPrefab,bombPosition,Player.rotation);
    }
    
}
