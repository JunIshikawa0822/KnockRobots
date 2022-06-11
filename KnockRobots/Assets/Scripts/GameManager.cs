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

    public int[] evenNumberArray = { -157, -112, -67, -22, 22, 67, 112, 157 };
    public int[] oddNumberArray = { -180, -135, -90, -45, 0, 45, 90, 135, 180 };

    public int o;
    public int e;

    public int keyNumber;
    public bool isKeyEnter = false;

    public bool isOneTurn = false;

    [SerializeField] GameObject canvas;

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

    public GameObject FourColorKeys;

    public GameObject[] generateGeneralGameObjectArray;
    public GameObject[] generatePlayerGameObjectArray;

    [SerializeField] public Image GreenGauge;
    [SerializeField] public Image YellowGauge;
    [SerializeField] public Image RedGauge;
    [SerializeField] int maxHP = 300;
    [SerializeField] int damage = 50;
    public int currentHP;

    [SerializeField] public Image KnockGauge;
    [SerializeField] int maxMP = 300;
    [SerializeField] int MPPoint = 10;
    public int currentMP;

    [SerializeField] int healPoint = 50;
    [SerializeField] int balanceHealPoint = 25;

    int state;

    // Start is called before the first frame update
    void Start()
    {
        isOneTurn = true;
    }

    void Update()
    {
        if (isOneTurn == true)
        {
            GameGenerater();
            isOneTurn = false;
            isKeyEnter = true;
        }

        if (isKeyEnter == true)
        {
            if (keyNumber > arraylength)
            {
                isKeyEnter = false;
            }
            else
            {
                PlayerKeyInput();
            }

            if (keyNumber == arraylength)
            {   
                Debug.Log("Perfect");
                Invoke("OneTurnSwitcher", 1);
            }  
        }

        GaugeReduction();
        //Debug.Log(currentHP);
    }

    public void KeyGenerate1()
    //SmallEnemyの場合に呼び出すKeyGenerate
    {
        arraylength = Random.Range(4, 7);
        generalKeyArray = new int[arraylength];
        generateGeneralGameObjectArray = new GameObject[arraylength];

        //Debug.Log("配列の長さ" + arraylength);
        int o = (9 - arraylength) / 2;
        int e = (8 - arraylength) / 2;

        for (int i = 0; i < arraylength; i++)
        {
            GameObject generateGameobject = null;
            int k = Random.Range(1, 5);
            generalKeyArray[i] = k;
            //Debug.Log("キー番号" + generalKeyArray[i]);

            if (arraylength%2 == 1)
            {
                if (k == 1)
                {
                    generateGameobject = Instantiate(UpArrowOrange, new Vector3(oddNumberArray[o + i], 100, 0), Quaternion.identity);
                    generateGameobject.transform.SetParent(canvas.transform, false);
                }

                if (k == 2)
                {
                    generateGameobject = Instantiate(DownArrowOrange, new Vector3(oddNumberArray[o + i], 100, 0), Quaternion.identity);
                    generateGameobject.transform.SetParent(canvas.transform, false);
                }

                if (k == 3)
                {
                    generateGameobject = Instantiate(RightArrowOrange, new Vector3(oddNumberArray[o + i], 100, 0), Quaternion.identity);
                    generateGameobject.transform.SetParent(canvas.transform, false);
                }

                if (k == 4)
                {
                    generateGameobject = Instantiate(LeftArrowOrange, new Vector3(oddNumberArray[o + i], 100, 0), Quaternion.identity);
                    generateGameobject.transform.SetParent(canvas.transform, false);
                }
            }
            if (arraylength % 2 == 0)
            {
                if (k == 1)
                {
                    generateGameobject = Instantiate(UpArrowOrange, new Vector3(evenNumberArray[e + i], 100, 0), Quaternion.identity);
                    generateGameobject.transform.SetParent(canvas.transform, false);
                }

                if (k == 2)
                {
                    generateGameobject = Instantiate(DownArrowOrange, new Vector3(evenNumberArray[e + i], 100, 0), Quaternion.identity);
                    generateGameobject.transform.SetParent(canvas.transform, false);
                }

                if (k == 3)
                {
                    generateGameobject = Instantiate(RightArrowOrange, new Vector3(evenNumberArray[e + i], 100, 0), Quaternion.identity);
                    generateGameobject.transform.SetParent(canvas.transform, false);
                }

                if (k == 4)
                {
                    generateGameobject = Instantiate(LeftArrowOrange, new Vector3(evenNumberArray[e + i], 100, 0), Quaternion.identity);
                    generateGameobject.transform.SetParent(canvas.transform, false);
                }
            }

            generateGeneralGameObjectArray[i] = generateGameobject;
        }
    }

    public void KeyGenerate2()
    //LargeEnemyの場合に呼び出すKeyGenerate
    {
        arraylength = Random.Range(7, 10);
        generalKeyArray = new int[arraylength];
        generateGeneralGameObjectArray = new GameObject[arraylength];

        //Debug.Log("配列の長さ" + arraylength);
        int o = (9 - arraylength) / 2;
        int e = (8 - arraylength) / 2;

        for (int i = 0; i < arraylength; i++)
        {
            GameObject generateGameobject = null;
            int k = Random.Range(1, 6);
            generalKeyArray[i] = k;
            //Debug.Log("キー番号" + generalKeyArray[i]);

            if (arraylength % 2 == 1)
            {
                if (k == 1)
                {
                    generateGameobject = Instantiate(UpArrowOrange, new Vector3(oddNumberArray[o + i], 100, 0), Quaternion.identity);
                    generateGameobject.transform.SetParent(canvas.transform, false);
                }

                if (k == 2)
                {
                    generateGameobject = Instantiate(DownArrowOrange, new Vector3(oddNumberArray[o + i], 100, 0), Quaternion.identity);
                    generateGameobject.transform.SetParent(canvas.transform, false);
                }

                if (k == 3)
                {
                    generateGameobject = Instantiate(RightArrowOrange, new Vector3(oddNumberArray[o + i], 100, 0), Quaternion.identity);
                    generateGameobject.transform.SetParent(canvas.transform, false);
                }

                if (k == 4)
                {
                    generateGameobject = Instantiate(LeftArrowOrange, new Vector3(oddNumberArray[o + i], 100, 0), Quaternion.identity);
                    generateGameobject.transform.SetParent(canvas.transform, false);
                }

                if (k == 5)
                {
                    generateGameobject = Instantiate(FourColorKeys, new Vector3(oddNumberArray[o + i], 100, 0), Quaternion.identity);
                    generateGameobject.transform.SetParent(canvas.transform, false);
                }
            }
            if (arraylength % 2 == 0)
            {
                if (k == 1)
                {
                    generateGameobject = Instantiate(UpArrowOrange, new Vector3(evenNumberArray[e + i], 100, 0), Quaternion.identity);
                    generateGameobject.transform.SetParent(canvas.transform, false);
                }

                if (k == 2)
                {
                    generateGameobject = Instantiate(DownArrowOrange, new Vector3(evenNumberArray[e + i], 100, 0), Quaternion.identity);
                    generateGameobject.transform.SetParent(canvas.transform, false);
                }

                if (k == 3)
                {
                    generateGameobject = Instantiate(RightArrowOrange, new Vector3(evenNumberArray[e + i], 100, 0), Quaternion.identity);
                    generateGameobject.transform.SetParent(canvas.transform, false);
                }

                if (k == 4)
                {
                    generateGameobject = Instantiate(LeftArrowOrange, new Vector3(evenNumberArray[e + i], 100, 0), Quaternion.identity);
                    generateGameobject.transform.SetParent(canvas.transform, false);
                }

                if (k == 5)
                {
                    generateGameobject = Instantiate(FourColorKeys, new Vector3(evenNumberArray[e + i], 100, 0), Quaternion.identity);
                    generateGameobject.transform.SetParent(canvas.transform, false);
                }
            }
            generateGeneralGameObjectArray[i] = generateGameobject;
        }
    }

    public void PlayerKeyAllayGenerate()
    {
        playerKeyArray = new int[arraylength];
        //Debug.Log("プレイヤー配列の長さ" + arraylength);   
    }

    public void PlayerKeyInput()
    {
        int o = (9 - arraylength) / 2;
        int e = (8 - arraylength) / 2;
        generatePlayerGameObjectArray = new GameObject[arraylength];

        if (isKeyEnter)
        {
            GameObject generatePlayerGameobject = null;
            if (arraylength % 2 == 1)
            {
                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    //Debug.Log("入力されたキー：1");
                    playerKeyArray[keyNumber] = 1;
                    //Debug.Log(keyNumber + "番目に" + playerKeyArray[keyNumber] + "を入れた");
                    Destroy(generateGeneralGameObjectArray[keyNumber]);

                    if (playerKeyArray[keyNumber] == generalKeyArray[keyNumber])
                    {
                        generatePlayerGameobject = Instantiate(UpArrowPink, new Vector3(oddNumberArray[o + keyNumber], 100, 0), Quaternion.identity);
                        generatePlayerGameobject.transform.SetParent(canvas.transform, false);
                        currentMP += MPPoint;
                    }
                    else if (generalKeyArray[keyNumber] == 5)
                    {
                        generatePlayerGameobject = Instantiate(UpArrowBlue, new Vector3(oddNumberArray[o + keyNumber], 100, 0), Quaternion.identity);
                        generatePlayerGameobject.transform.SetParent(canvas.transform, false);
                        currentHP += healPoint;
                    }
                    else
                    {
                        generatePlayerGameobject = Instantiate(UpArrowBlack, new Vector3(oddNumberArray[o + keyNumber], 100, 0), Quaternion.identity);
                        generatePlayerGameobject.transform.SetParent(canvas.transform, false);
                        currentHP -= damage;
                    }

                    generatePlayerGameObjectArray[keyNumber] = generatePlayerGameobject;
                    
                    keyNumber++;
                    //Debug.Log("現在のkeyNumber" + keyNumber);
                }
                else if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                    //Debug.Log("入力されたキー：2");
                    playerKeyArray[keyNumber] = 2;
                    //Debug.Log(keyNumber + "番目に" + playerKeyArray[keyNumber] + "を入れた");
                    Destroy(generateGeneralGameObjectArray[keyNumber]);

                    if (playerKeyArray[keyNumber] == generalKeyArray[keyNumber])
                    {
                        generatePlayerGameobject = Instantiate(DownArrowPink, new Vector3(oddNumberArray[o + keyNumber], 100, 0), Quaternion.identity);
                        generatePlayerGameobject.transform.SetParent(canvas.transform, false);
                        currentMP += MPPoint;
                    }
                    else if (generalKeyArray[keyNumber] == 5)
                    {
                        generatePlayerGameobject = Instantiate(DownArrowBlue, new Vector3(oddNumberArray[o + keyNumber], 100, 0), Quaternion.identity);
                        generatePlayerGameobject.transform.SetParent(canvas.transform, false);
                        //comboの値を上昇させる
                    }
                    else
                    {
                        generatePlayerGameobject = Instantiate(DownArrowBlack, new Vector3(oddNumberArray[o + keyNumber], 100, 0), Quaternion.identity);
                        generatePlayerGameobject.transform.SetParent(canvas.transform, false);
                        currentHP -= damage;
                    }

                    generatePlayerGameObjectArray[keyNumber] = generatePlayerGameobject;
                    
                    keyNumber++;
                    //Debug.Log("keyNumber" + keyNumber);
                }
                else if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    //Debug.Log("入力されたキー：3");
                    playerKeyArray[keyNumber] = 3;
                    //Debug.Log(keyNumber + "番目に" + playerKeyArray[keyNumber] + "を入れた");
                    Destroy(generateGeneralGameObjectArray[keyNumber]);

                    if (playerKeyArray[keyNumber] == generalKeyArray[keyNumber])
                    {
                        generatePlayerGameobject = Instantiate(RightArrowPink, new Vector3(oddNumberArray[o + keyNumber], 100, 0), Quaternion.identity);
                        generatePlayerGameobject.transform.SetParent(canvas.transform, false);
                        currentMP += MPPoint;
                    }
                    else if (generalKeyArray[keyNumber] == 5)
                    {
                        generatePlayerGameobject = Instantiate(RightArrowBlue, new Vector3(oddNumberArray[o + keyNumber], 100, 0), Quaternion.identity);
                        generatePlayerGameobject.transform.SetParent(canvas.transform, false);
                        currentMP += healPoint;
                    }
                    else
                    {
                        generatePlayerGameobject = Instantiate(RightArrowBlack, new Vector3(oddNumberArray[o + keyNumber], 100, 0), Quaternion.identity);
                        generatePlayerGameobject.transform.SetParent(canvas.transform, false);
                        currentHP -= damage;
                    }

                    generatePlayerGameObjectArray[keyNumber] = generatePlayerGameobject;
                    
                    keyNumber++;
                    //Debug.Log("keyNumber" + keyNumber);
                }
                else if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    //Debug.Log("入力されたキー：4");
                    playerKeyArray[keyNumber] = 4;
                    //Debug.Log(keyNumber + "番目に" + playerKeyArray[keyNumber] + "を入れた");
                    Destroy(generateGeneralGameObjectArray[keyNumber]);

                    if (playerKeyArray[keyNumber] == generalKeyArray[keyNumber])
                    {
                        generatePlayerGameobject = Instantiate(LeftArrowPink, new Vector3(oddNumberArray[o + keyNumber], 100, 0), Quaternion.identity);
                        generatePlayerGameobject.transform.SetParent(canvas.transform, false);
                        currentMP += MPPoint;
                    }
                    else if (generalKeyArray[keyNumber] == 5)
                    {
                        generatePlayerGameobject = Instantiate(LeftArrowBlue, new Vector3(oddNumberArray[o + keyNumber], 100, 0), Quaternion.identity);
                        generatePlayerGameobject.transform.SetParent(canvas.transform, false);
                        currentHP += balanceHealPoint;
                        currentMP += balanceHealPoint;
                        //comboの値を少しだけ上昇させる
                    }
                    else
                    {
                        generatePlayerGameobject = Instantiate(LeftArrowBlack, new Vector3(oddNumberArray[o + keyNumber], 100, 0), Quaternion.identity);
                        generatePlayerGameobject.transform.SetParent(canvas.transform, false);
                        currentHP -= damage;
                    }

                    generatePlayerGameObjectArray[keyNumber] = generatePlayerGameobject;
                    
                    keyNumber++;
                    //Debug.Log("keyNumber" + keyNumber);
                }
            }

            if (arraylength % 2 == 0)
            {
                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    //Debug.Log("入力されたキー：1");
                    playerKeyArray[keyNumber] = 1;
                    //Debug.Log(keyNumber + "番目に" + playerKeyArray[keyNumber] + "を入れた");
                    Destroy(generateGeneralGameObjectArray[keyNumber]);

                    if (playerKeyArray[keyNumber] == generalKeyArray[keyNumber])
                    {
                        generatePlayerGameobject = Instantiate(UpArrowPink, new Vector3(evenNumberArray[e + keyNumber], 100, 0), Quaternion.identity);
                        generatePlayerGameobject.transform.SetParent(canvas.transform, false);
                        currentMP += MPPoint;
                    }
                    else if (generalKeyArray[keyNumber] == 5)
                    {
                        generatePlayerGameobject = Instantiate(UpArrowBlue, new Vector3(evenNumberArray[e + keyNumber], 100, 0), Quaternion.identity);
                        generatePlayerGameobject.transform.SetParent(canvas.transform, false);
                        currentHP += healPoint;
                    }
                    else
                    {
                        generatePlayerGameobject = Instantiate(UpArrowBlack, new Vector3(evenNumberArray[e + keyNumber], 100, 0), Quaternion.identity);
                        generatePlayerGameobject.transform.SetParent(canvas.transform, false);
                        currentHP -= damage;
                    }

                    generatePlayerGameObjectArray[keyNumber] = generatePlayerGameobject;
                    
                    keyNumber++;
                    //Debug.Log("現在のkeyNumber" + keyNumber);
                }
                else if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                    //Debug.Log("入力されたキー：2");
                    playerKeyArray[keyNumber] = 2;
                    //Debug.Log(keyNumber + "番目に" + playerKeyArray[keyNumber] + "を入れた");
                    Destroy(generateGeneralGameObjectArray[keyNumber]);

                    if (playerKeyArray[keyNumber] == generalKeyArray[keyNumber])
                    {
                        generatePlayerGameobject = Instantiate(DownArrowPink, new Vector3(evenNumberArray[e + keyNumber], 100, 0), Quaternion.identity);
                        generatePlayerGameobject.transform.SetParent(canvas.transform, false);
                        currentMP += MPPoint;
                    }
                    else if (generalKeyArray[keyNumber] == 5)
                    {
                        generatePlayerGameobject = Instantiate(DownArrowBlue, new Vector3(evenNumberArray[e + keyNumber], 100, 0), Quaternion.identity);
                        generatePlayerGameobject.transform.SetParent(canvas.transform, false);
                        //comboの値を上昇させる
                    }
                    else
                    {
                        generatePlayerGameobject = Instantiate(DownArrowBlack, new Vector3(evenNumberArray[e + keyNumber], 100, 0), Quaternion.identity);
                        generatePlayerGameobject.transform.SetParent(canvas.transform, false);
                        currentHP -= damage;
                    }

                    generatePlayerGameObjectArray[keyNumber] = generatePlayerGameobject;
                    
                    keyNumber++;
                    //Debug.Log("keyNumber" + keyNumber);
                }
                else if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    //Debug.Log("入力されたキー：3");
                    playerKeyArray[keyNumber] = 3;
                    //Debug.Log(keyNumber + "番目に" + playerKeyArray[keyNumber] + "を入れた");
                    Destroy(generateGeneralGameObjectArray[keyNumber]);

                    if (playerKeyArray[keyNumber] == generalKeyArray[keyNumber])
                    {
                        generatePlayerGameobject = Instantiate(RightArrowPink, new Vector3(evenNumberArray[e + keyNumber], 100, 0), Quaternion.identity);
                        generatePlayerGameobject.transform.SetParent(canvas.transform, false);
                        currentMP += MPPoint;
                    }
                    else if (generalKeyArray[keyNumber] == 5)
                    {
                        generatePlayerGameobject = Instantiate(RightArrowBlue, new Vector3(evenNumberArray[e + keyNumber], 100, 0), Quaternion.identity);
                        generatePlayerGameobject.transform.SetParent(canvas.transform, false);
                        currentMP += healPoint;
                    }
                    else
                    {
                        generatePlayerGameobject = Instantiate(RightArrowBlack, new Vector3(evenNumberArray[e + keyNumber], 100, 0), Quaternion.identity);
                        generatePlayerGameobject.transform.SetParent(canvas.transform, false);
                        currentHP -= damage;
                    }

                    generatePlayerGameObjectArray[keyNumber] = generatePlayerGameobject;
                    
                    keyNumber++;
                    //Debug.Log("keyNumber" + keyNumber);
                }
                else if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    //Debug.Log("入力されたキー：4");
                    playerKeyArray[keyNumber] = 4;
                    //Debug.Log(keyNumber + "番目に" + playerKeyArray[keyNumber] + "を入れた");
                    Destroy(generateGeneralGameObjectArray[keyNumber]);

                    if (playerKeyArray[keyNumber] == generalKeyArray[keyNumber])
                    {
                        generatePlayerGameobject = Instantiate(LeftArrowPink, new Vector3(evenNumberArray[e + keyNumber], 100, 0), Quaternion.identity);
                        generatePlayerGameobject.transform.SetParent(canvas.transform, false);
                        currentMP += MPPoint;
                    }
                    else if (generalKeyArray[keyNumber] == 5)
                    {
                        generatePlayerGameobject = Instantiate(LeftArrowBlue, new Vector3(evenNumberArray[e + keyNumber], 100, 0), Quaternion.identity);
                        generatePlayerGameobject.transform.SetParent(canvas.transform, false);
                        currentHP += balanceHealPoint;
                        currentMP += balanceHealPoint;
                        //comboの値を少しだけ上昇させる
                    }
                    else
                    {
                        generatePlayerGameobject = Instantiate(LeftArrowBlack, new Vector3(evenNumberArray[e + keyNumber], 100, 0), Quaternion.identity);
                        generatePlayerGameobject.transform.SetParent(canvas.transform, false);
                        currentHP -= damage;
                    }

                    generatePlayerGameObjectArray[keyNumber] = generatePlayerGameobject;
                    
                    keyNumber++;
                    //Debug.Log("keyNumber" + keyNumber);
                }
            }
        }
    }

    public void GaugeReduction()
    {
        if(currentHP > maxHP)
        {
            currentHP = maxHP;
        }

        YellowGauge.fillAmount = (float)currentHP / (float)maxHP;
        //Debug.Log(YellowGauge.fillAmount);
        if(currentHP < maxHP)
        {
            GreenGauge.enabled = false;
        }

        if(RedGauge.fillAmount > YellowGauge.fillAmount)
        {
            if(RedGauge.fillAmount - YellowGauge.fillAmount > 0.005f)
            {
                RedGauge.fillAmount -= 0.005f;
            }
            else
            {
                RedGauge.fillAmount = YellowGauge.fillAmount;
            }
        }

        float fillProp = 0.75f;
        KnockGauge.fillAmount = (float)currentMP / (float)maxMP;
        KnockGauge.fillAmount *= fillProp;

        //if(currentMP == maxMP)
        //{

        //}
    }

    public void GameGenerater()
    {
        keyGenerateChanger = Random.Range(1, 3);
        //Debug.Log(keyGenerateChanger);
        if (keyGenerateChanger == 1)
        {
            KeyGenerate1();
        }
        if (keyGenerateChanger == 2)
        {
            KeyGenerate2();
        }
        //Debug.Log(keyGenerateChanger);

        keyNumber = 0;

        currentHP = maxHP;
        currentMP = 0;

        PlayerKeyAllayGenerate();
        //Debug.Log("現在のkeyNumber" + keyNumber);
    }

    public void OneTurnSwitcher()
    {
        isOneTurn = true;
        keyNumber = 0;
    }
}
