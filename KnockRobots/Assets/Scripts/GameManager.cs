using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int arraylength;
    public int[] generalKeyArray;
    public int[] playerKeyArray;
    public int keyNumber;
    public bool isKeyEnter = false;

    // Start is called before the first frame update
    void Start()
    {
        isKeyEnter = true;
        keyNumber = 0;
        KeyGenerate1();
        PlayerKeyAllayGenerate();
        Debug.Log("現在のkeyNumber" + keyNumber);
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    void Update()
    {
        if(isKeyEnter)
        {
            if (keyNumber > arraylength)
            {
                isKeyEnter = false;
            }
            else
            {
                PlayerKeyInput();
            }
        }
    }

    public void KeyGenerate1()
    //SmallEnemyの場合に呼び出すKeyGenerate
    {
        arraylength = Random.Range(3, 7);
        generalKeyArray = new int[arraylength];
        Debug.Log("配列の長さ" + arraylength);

        for (int i = 0; i < arraylength; i++)
        {
            int k = Random.Range(1, 5);
            generalKeyArray[i] = k;
            Debug.Log("キー番号" + generalKeyArray[i]);
        }
    }

    public void KeyGenerate2()
    //LargeEnemyの場合に呼び出すKeyGenerate
    {
        arraylength = Random.Range(7, 11);
        generalKeyArray = new int[arraylength];

        Debug.Log("配列の長さ" + arraylength);

        for (int i = 0; i < arraylength; i++)
        {
            int k = Random.Range(1, 5);
            generalKeyArray[i] = k;
            //Debug.Log("キー番号" + generalKeyArray[i]);
        }
    }

    public void PlayerKeyAllayGenerate()
    {
        playerKeyArray = new int[arraylength];
        Debug.Log("プレイヤー配列の長さ" + arraylength);   
    }

    public void PlayerKeyInput()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Debug.Log("入力されたキー：1");
            playerKeyArray[keyNumber] = 1;
            Debug.Log(keyNumber + "番目に" + playerKeyArray[keyNumber] + "を入れた");

            if (playerKeyArray[keyNumber] == generalKeyArray[keyNumber])
            {
                Debug.Log("○");
            }

            keyNumber++;           
            Debug.Log("現在のkeyNumber" + keyNumber);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Debug.Log("入力されたキー：2");
            playerKeyArray[keyNumber] = 2;
            Debug.Log(keyNumber + "番目に"　+ playerKeyArray[keyNumber] + "を入れた");

            if (playerKeyArray[keyNumber] == generalKeyArray[keyNumber])
            {
                Debug.Log("○");
            }

            keyNumber++;
            Debug.Log("keyNumber" + keyNumber);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Debug.Log("入力されたキー：3");
            playerKeyArray[keyNumber] = 3;
            Debug.Log(keyNumber + "番目に" + playerKeyArray[keyNumber] + "を入れた");

            if (playerKeyArray[keyNumber] == generalKeyArray[keyNumber])
            {
                Debug.Log("○");
            }

            keyNumber++;
            Debug.Log("keyNumber" + keyNumber);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Debug.Log("入力されたキー：4");
            playerKeyArray[keyNumber] = 4;
            Debug.Log(keyNumber + "番目に" + playerKeyArray[keyNumber] + "を入れた");

            if (playerKeyArray[keyNumber] == generalKeyArray[keyNumber])
            {
                Debug.Log("○");
            }

            keyNumber++;
            Debug.Log("keyNumber" + keyNumber);
        }
    }
}
