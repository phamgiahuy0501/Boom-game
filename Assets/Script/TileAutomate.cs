using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileAutomate : MonoBehaviour
{
    int height = 11;
    int width = 15;
    int box = 35;
    int zombie = 4;
    int bombAmu = 5;
    int fireAmu = 8;
    int zombieAmount = 4;
    public GameObject playerPrefab;
    public GameObject boxPrefab;
    public GameObject zombiePrefab;
    public GameObject bombAmuPrefab;
    public GameObject fireAmuPrefab;
    // Start is called before the first frame update
    void Start()
    {
        generateMap();
    }
    void Update()
    {
        if (zombieAmount == 0)
        {
            //END GAME
            Debug.Log("Game over! Win!");
        }
    }

    void generateMap(){
        bool[,] flag = new bool[15,11];
        
        for (int i=0; i <= width / 2; i++)
        {
            for (int j =0;j<= height/2; j++)
            {
                if (i%2 ==0 && j%2 == 0)
                {
                    flag[i + 7, 5 - j] = true;
                    flag[-i + 7, 5 + j] = true;
                }
            }
        }
        flag[0, 0] = true;
        flag[1, 0] = true;
        flag[2, 0] = true;
        flag[0, 1] = true;
        flag[0, 2] = true;

        Instantiate(playerPrefab, new Vector3(xpos(0), ypos(0), 0), Quaternion.identity);
        Instantiate(boxPrefab, new Vector3(xpos(2), ypos(0), 0), Quaternion.identity);
        Instantiate(boxPrefab, new Vector3(xpos(0), ypos(2), 0), Quaternion.identity);
        
        while (box > 0)
        {
            int i = Random.Range(0, 14);
            int j = Random.Range(0, 10);
            while (xpos(i)%2 ==0 && ypos(j)%2 == 0)
            {
                i = Random.Range(0, 14);
                j = Random.Range(0, 10);
            }
            if (!flag[i, j])
            {
                Vector3 position = new Vector3(xpos(i), ypos(j), 0);
                Instantiate(boxPrefab, position, Quaternion.identity);
                box -= 1;
                flag[i, j] = true;
                if (bombAmu > 0)
                {
                    Instantiate(bombAmuPrefab, position, Quaternion.identity);
                    bombAmu--;
                }
                else if (fireAmu > 0) {
                    Instantiate(fireAmuPrefab, position, Quaternion.identity);
                    fireAmu--;
                }
            }
            
        }
        while (zombie > 0)
        {
            int i = Random.Range(0, 14);
            int j = Random.Range(0, 10);
            if (!flag[i, j])
            {
                Vector3 position = new Vector3(xpos(i), ypos(j), 0);
                Instantiate(zombiePrefab, position, Quaternion.identity);
                zombie--;
                flag[i, j] = true;
            }
        }
    }
    int xpos(int i)
    {
        return i - 7;
    }
    int ypos(int j)
    {
        return 5 - j;
    }
    public void KillZombie()
    {
        zombieAmount--;
    }
    
}
