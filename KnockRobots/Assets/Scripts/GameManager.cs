using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int arraylength;

    // Start is called before the first frame update
    void Start()
    {
        KeyGenerate();
        PlayerKeyEnter();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void KeyGenerate()
    {
        arraylength = Random.Range(3, 10);
        int[] generalKeyArray;
        generalKeyArray = new int[arraylength];
        Debug.Log("配列の長さ" + arraylength);

        for (int i = 0; i < arraylength; i++)
        {
            int k = Random.Range(0, 4);
            generalKeyArray[i] = k;
            //Debug.Log("キー番号" + generalKeyArray[i]);
        }
    }

    public void PlayerKeyEnter()
    {
        int[] playerKeyArray;
        playerKeyArray = new int[arraylength];
        Debug.Log("プレイヤー配列の長さ" + arraylength);

        int keyNumber = 0;
        int isKeyEnter = 0;
        
        if(isKeyEnter <= arraylength)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                playerKeyArray[keyNumber] = 0;
                Debug.Log(keyNumber + "0");
                keyNumber++;
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                playerKeyArray[keyNumber] = 1;
                Debug.Log(keyNumber + "1");
                keyNumber++;
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                playerKeyArray[keyNumber] = 2;
                Debug.Log(keyNumber + "2");
                keyNumber++;
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                playerKeyArray[keyNumber] = 3;
                Debug.Log(keyNumber + "3");
                keyNumber++;
            }
        }      
    }
}
