using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int keyGenerateChanger;

    public int arraylength;
    public int[] generalKeyArray;
    public int[] playerKeyArray;

    public int[] evenNumberArray = {-157, -112, -67, -22, 22, 67, 112, 157};
    public int[] oddNumberArray = {-180, -135, -90, -45, 0, 45, 90, 135, 180};

    public int o;
    public int e;

    public int keyNumber;
    public bool isKeyEnter = false;

    [SerializeField]GameObject canvas;

    public GameObject UpArrowBlack;
    public GameObject UpArrowBlue;
    public GameObject UpArrowOrange;
    public GameObject UpArrowPink;

    public GameObject DownArrowBlack;
    public GameObject DownArrowBlue;
    public GameObject DownArrowOrange;
    public GameObject DownArrowPink;

    public GameObject RightArrowBlack;
    public GameObject RightArrowBlue;
    public GameObject RightArrowOrange;
    public GameObject RightArrowPink;

    public GameObject LeftArrowBlack;
    public GameObject LeftArrowBlue;
    public GameObject LeftArrowOrange;
    public GameObject LeftArrowPink;

    // Start is called before the first frame update
    void Start()
    {
        keyGenerateChanger = Random.Range(1, 3);
        Debug.Log(keyGenerateChanger);
        if (keyGenerateChanger == 1)
        {
            KeyGenerate1();
        }
        if(keyGenerateChanger == 2)
        {
            KeyGenerate2();
        }
        Debug.Log(keyGenerateChanger);

        isKeyEnter = true;
        keyNumber = 0;
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
        arraylength = Random.Range(4, 7);
        generalKeyArray = new int[arraylength];
        Debug.Log("配列の長さ" + arraylength);
        int o = (9 - arraylength) / 2;
        int e = (8 - arraylength) / 2;

        for (int i = 0; i < arraylength; i++)
        {
            int k = Random.Range(1, 5);
            generalKeyArray[i] = k;
            Debug.Log("キー番号" + generalKeyArray[i]);

            if (arraylength%2 == 1)
            {
                if (k == 1)
                {
                    var generateGameobject = Instantiate(UpArrowOrange, new Vector3(oddNumberArray[o + i], 100, 0), Quaternion.identity);
                    generateGameobject.transform.SetParent(canvas.transform, false);
                }

                if (k == 2)
                {
                    var generateGameobject = Instantiate(DownArrowOrange, new Vector3(oddNumberArray[o + i], 100, 0), Quaternion.identity);
                    generateGameobject.transform.SetParent(canvas.transform, false);
                }

                if (k == 3)
                {
                    var generateGameobject = Instantiate(RightArrowOrange, new Vector3(oddNumberArray[o + i], 100, 0), Quaternion.identity);
                    generateGameobject.transform.SetParent(canvas.transform, false);
                }

                if (k == 4)
                {
                    var generateGameobject = Instantiate(LeftArrowOrange, new Vector3(oddNumberArray[o + i], 100, 0), Quaternion.identity);
                    generateGameobject.transform.SetParent(canvas.transform, false);
                }
            }
            if (arraylength % 2 == 0)
            {
                if (k == 1)
                {
                    var generateGameobject = Instantiate(UpArrowOrange, new Vector3(evenNumberArray[e + i], 100, 0), Quaternion.identity);
                    generateGameobject.transform.SetParent(canvas.transform, false);
                }

                if (k == 2)
                {
                    var generateGameobject = Instantiate(DownArrowOrange, new Vector3(evenNumberArray[e + i], 100, 0), Quaternion.identity);
                    generateGameobject.transform.SetParent(canvas.transform, false);
                }

                if (k == 3)
                {
                    var generateGameobject = Instantiate(RightArrowOrange, new Vector3(evenNumberArray[e + i], 100, 0), Quaternion.identity);
                    generateGameobject.transform.SetParent(canvas.transform, false);
                }

                if (k == 4)
                {
                    var generateGameobject = Instantiate(LeftArrowOrange, new Vector3(evenNumberArray[e + i], 100, 0), Quaternion.identity);
                    generateGameobject.transform.SetParent(canvas.transform, false);
                }
            }
        }
    }

    public void KeyGenerate2()
    //LargeEnemyの場合に呼び出すKeyGenerate
    {
        arraylength = Random.Range(7, 10);
        generalKeyArray = new int[arraylength];
        Debug.Log("配列の長さ" + arraylength);
        int o = (9 - arraylength) / 2;
        int e = (8 - arraylength) / 2;

        for (int i = 0; i < arraylength; i++)
        {
            int k = Random.Range(1, 5);
            generalKeyArray[i] = k;
            //Debug.Log("キー番号" + generalKeyArray[i]);

            if (arraylength % 2 == 1)
            {
                if (k == 1)
                {
                    var generateGameobject = Instantiate(UpArrowOrange, new Vector3(oddNumberArray[o + i], 100, 0), Quaternion.identity);
                    generateGameobject.transform.SetParent(canvas.transform, false);
                }

                if (k == 2)
                {
                    var generateGameobject = Instantiate(DownArrowOrange, new Vector3(oddNumberArray[o + i], 100, 0), Quaternion.identity);
                    generateGameobject.transform.SetParent(canvas.transform, false);
                }

                if (k == 3)
                {
                    var generateGameobject = Instantiate(RightArrowOrange, new Vector3(oddNumberArray[o + i], 100, 0), Quaternion.identity);
                    generateGameobject.transform.SetParent(canvas.transform, false);
                }

                if (k == 4)
                {
                    var generateGameobject = Instantiate(LeftArrowOrange, new Vector3(oddNumberArray[o + i], 100, 0), Quaternion.identity);
                    generateGameobject.transform.SetParent(canvas.transform, false);
                }
            }
            if (arraylength % 2 == 0)
            {
                if (k == 1)
                {
                    var generateGameobject = Instantiate(UpArrowOrange, new Vector3(evenNumberArray[e + i], 100, 0), Quaternion.identity);
                    generateGameobject.transform.SetParent(canvas.transform, false);
                }

                if (k == 2)
                {
                    var generateGameobject = Instantiate(DownArrowOrange, new Vector3(evenNumberArray[e + i], 100, 0), Quaternion.identity);
                    generateGameobject.transform.SetParent(canvas.transform, false);
                }

                if (k == 3)
                {
                    var generateGameobject = Instantiate(RightArrowOrange, new Vector3(evenNumberArray[e + i], 100, 0), Quaternion.identity);
                    generateGameobject.transform.SetParent(canvas.transform, false);
                }

                if (k == 4)
                {
                    var generateGameobject = Instantiate(LeftArrowOrange, new Vector3(evenNumberArray[e + i], 100, 0), Quaternion.identity);
                    generateGameobject.transform.SetParent(canvas.transform, false);
                }
            }
        }
    }

    public void PlayerKeyAllayGenerate()
    {
        playerKeyArray = new int[arraylength];
        Debug.Log("プレイヤー配列の長さ" + arraylength);   
    }

    public void PlayerKeyInput()
    {
        int o = (9 - arraylength) / 2;
        int e = (8 - arraylength) / 2;

        if (arraylength % 2 == 1)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                Debug.Log("入力されたキー：1");
                playerKeyArray[keyNumber] = 1;
                Debug.Log(keyNumber + "番目に" + playerKeyArray[keyNumber] + "を入れた");

                if (playerKeyArray[keyNumber] == generalKeyArray[keyNumber])
                {
                    var generateGameobject = Instantiate(UpArrowPink, new Vector3(oddNumberArray[o + keyNumber], 100, 0), Quaternion.identity);
                    generateGameobject.transform.SetParent(canvas.transform, false);
                }
                else
                {
                    var generateGameobject = Instantiate(UpArrowBlack, new Vector3(oddNumberArray[o + keyNumber], 100, 0), Quaternion.identity);
                    generateGameobject.transform.SetParent(canvas.transform, false);
                }

                keyNumber++;
                Debug.Log("現在のkeyNumber" + keyNumber);
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                Debug.Log("入力されたキー：2");
                playerKeyArray[keyNumber] = 2;
                Debug.Log(keyNumber + "番目に" + playerKeyArray[keyNumber] + "を入れた");

                if (playerKeyArray[keyNumber] == generalKeyArray[keyNumber])
                {
                    var generateGameobject = Instantiate(DownArrowPink, new Vector3(oddNumberArray[o + keyNumber], 100, 0), Quaternion.identity);
                    generateGameobject.transform.SetParent(canvas.transform, false);
                }
                else
                {
                    var generateGameobject = Instantiate(DownArrowBlack, new Vector3(oddNumberArray[o + keyNumber], 100, 0), Quaternion.identity);
                    generateGameobject.transform.SetParent(canvas.transform, false);
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
                    var generateGameobject = Instantiate(RightArrowPink, new Vector3(oddNumberArray[o + keyNumber], 100, 0), Quaternion.identity);
                    generateGameobject.transform.SetParent(canvas.transform, false);
                }
                else
                {
                    var generateGameobject = Instantiate(RightArrowBlack, new Vector3(oddNumberArray[o + keyNumber], 100, 0), Quaternion.identity);
                    generateGameobject.transform.SetParent(canvas.transform, false);
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
                    var generateGameobject = Instantiate(LeftArrowPink, new Vector3(oddNumberArray[o + keyNumber], 100, 0), Quaternion.identity);
                    generateGameobject.transform.SetParent(canvas.transform, false);
                }
                else
                {
                    var generateGameobject = Instantiate(LeftArrowBlack, new Vector3(oddNumberArray[o + keyNumber], 100, 0), Quaternion.identity);
                    generateGameobject.transform.SetParent(canvas.transform, false);
                }

                keyNumber++;
                Debug.Log("keyNumber" + keyNumber);
            }
        }

        if (arraylength % 2 == 0)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                Debug.Log("入力されたキー：1");
                playerKeyArray[keyNumber] = 1;
                Debug.Log(keyNumber + "番目に" + playerKeyArray[keyNumber] + "を入れた");

                if (playerKeyArray[keyNumber] == generalKeyArray[keyNumber])
                {
                    var generateGameobject = Instantiate(UpArrowBlue, new Vector3(evenNumberArray[e + keyNumber], 100, 0), Quaternion.identity);
                    generateGameobject.transform.SetParent(canvas.transform, false);
                }
                else
                {
                    var generateGameobject = Instantiate(UpArrowBlack, new Vector3(evenNumberArray[e + keyNumber], 100, 0), Quaternion.identity);
                    generateGameobject.transform.SetParent(canvas.transform, false);
                }

                keyNumber++;
                Debug.Log("現在のkeyNumber" + keyNumber);
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                Debug.Log("入力されたキー：2");
                playerKeyArray[keyNumber] = 2;
                Debug.Log(keyNumber + "番目に" + playerKeyArray[keyNumber] + "を入れた");

                if (playerKeyArray[keyNumber] == generalKeyArray[keyNumber])
                {
                    var generateGameobject = Instantiate(DownArrowBlue, new Vector3(evenNumberArray[e + keyNumber], 100, 0), Quaternion.identity);
                    generateGameobject.transform.SetParent(canvas.transform, false);
                }
                else
                {
                    var generateGameobject = Instantiate(DownArrowBlack, new Vector3(evenNumberArray[e + keyNumber], 100, 0), Quaternion.identity);
                    generateGameobject.transform.SetParent(canvas.transform, false);
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
                    var generateGameobject = Instantiate(RightArrowBlue, new Vector3(evenNumberArray[e + keyNumber], 100, 0), Quaternion.identity);
                    generateGameobject.transform.SetParent(canvas.transform, false);
                }
                else
                {
                    var generateGameobject = Instantiate(RightArrowBlack, new Vector3(evenNumberArray[e + keyNumber], 100, 0), Quaternion.identity);
                    generateGameobject.transform.SetParent(canvas.transform, false);
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
                    var generateGameobject = Instantiate(LeftArrowBlue, new Vector3(evenNumberArray[e + keyNumber], 100, 0), Quaternion.identity);
                    generateGameobject.transform.SetParent(canvas.transform, false);
                }
                else
                {
                    var generateGameobject = Instantiate(LeftArrowBlack, new Vector3(evenNumberArray[e + keyNumber], 100, 0), Quaternion.identity);
                    generateGameobject.transform.SetParent(canvas.transform, false);
                }

                keyNumber++;
                Debug.Log("keyNumber" + keyNumber);
            }
        }
    }
}
