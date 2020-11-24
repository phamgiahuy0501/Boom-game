using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; 

public class BombPlanting : MonoBehaviour
{
    public Transform Player;
    public GameObject bombPrefab;
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
        Instantiate(bombPrefab,bombPosition,Player.rotation);
    }
    
}
