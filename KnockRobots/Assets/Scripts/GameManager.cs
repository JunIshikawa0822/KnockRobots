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

    public bool isGenerate = false;

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

    [SerializeField] float timeLimit = 3;
    public Image TimerIcon1;
    public Image TimerIcon2;
    public Image TimerIcon3;

    public int judge = 0;
    public bool isKnock = false;
    public bool isKnockEnter = false;

    public int combo;
    public Text comboText;

    // Start is called before the first frame update
    void Start()
    {
        isOneTurn = true;
        isGenerate = true;
        currentHP = maxHP;
        currentMP = 0;
        combo = 0;
    }

    void Update()
    {
        if (isOneTurn == true && isGenerate == true)
        {
            GameGenerater();
            isKeyEnter = true;
            isGenerate = false;
            TimerIcon1.enabled = true;
            TimerIcon2.enabled = true;
            TimerIcon3.enabled = true;
        }

        if (isKeyEnter == true)
        {
            PlayerKeyInput();
        }

        if(keyNumber > arraylength)
        {
            isKeyEnter = false;
        }

        if(isOneTurn == true && isGenerate == false)
        {
            timeLimit -= Time.deltaTime * 0.7f;
            if(timeLimit <= 2)
            {
                TimerIcon1.enabled = false;
                if(timeLimit <= 1)
                {
                    TimerIcon2.enabled = false;
                    if(timeLimit <= 0)
                    {
                        TimerIcon3.enabled = false;
                    }
                }
            }
            if ((keyNumber == arraylength)　|| (timeLimit <= 0) || isKnockEnter == true)
            {
                isKeyEnter = false;
                isOneTurn = false;
                isKnockEnter = false;
                Invoke("UIReset", 0.5f);
                Judge();
                Invoke("OneTurnSwitcher", 1);
            }
        }

        if(currentMP >= maxMP)
        {
            currentMP = maxMP;
            isKnock = true;
        }

        comboText.text = "x " + combo.ToString();
        GaugeReduction();    
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
        generatePlayerGameObjectArray = new GameObject[arraylength];
        //Debug.Log("プレイヤー配列の長さ" + arraylength);   
    }

    public void PlayerKeyInput()
    {
        int o = (9 - arraylength) / 2;
        int e = (8 - arraylength) / 2;

        if (isKeyEnter)
        {
            if (arraylength % 2 == 1)
            {
                GameObject generatePlayerGameobject = null;
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
                        judge++;
                    }
                    else if (generalKeyArray[keyNumber] == 5)
                    {
                        generatePlayerGameobject = Instantiate(UpArrowBlue, new Vector3(oddNumberArray[o + keyNumber], 100, 0), Quaternion.identity);
                        generatePlayerGameobject.transform.SetParent(canvas.transform, false);
                        currentHP += healPoint;
                        judge++;
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
                        judge++;
                    }
                    else if (generalKeyArray[keyNumber] == 5)
                    {
                        generatePlayerGameobject = Instantiate(DownArrowBlue, new Vector3(oddNumberArray[o + keyNumber], 100, 0), Quaternion.identity);
                        generatePlayerGameobject.transform.SetParent(canvas.transform, false);
                        //comboの値を上昇させる
                        judge++;
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
                        judge++;
                    }
                    else if (generalKeyArray[keyNumber] == 5)
                    {
                        generatePlayerGameobject = Instantiate(RightArrowBlue, new Vector3(oddNumberArray[o + keyNumber], 100, 0), Quaternion.identity);
                        generatePlayerGameobject.transform.SetParent(canvas.transform, false);
                        currentMP += healPoint;
                        judge++;
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
                        judge++;
                    }
                    else if (generalKeyArray[keyNumber] == 5)
                    {
                        generatePlayerGameobject = Instantiate(LeftArrowBlue, new Vector3(oddNumberArray[o + keyNumber], 100, 0), Quaternion.identity);
                        generatePlayerGameobject.transform.SetParent(canvas.transform, false);
                        currentHP += balanceHealPoint;
                        currentMP += balanceHealPoint;
                        //comboの値を少しだけ上昇させる
                        judge++;
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
                GameObject generatePlayerGameobject = null;
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
                        judge++;
                    }
                    else if (generalKeyArray[keyNumber] == 5)
                    {
                        generatePlayerGameobject = Instantiate(UpArrowBlue, new Vector3(evenNumberArray[e + keyNumber], 100, 0), Quaternion.identity);
                        generatePlayerGameobject.transform.SetParent(canvas.transform, false);
                        currentHP += healPoint;
                        judge++;
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
                        judge++;
                    }
                    else if (generalKeyArray[keyNumber] == 5)
                    {
                        generatePlayerGameobject = Instantiate(DownArrowBlue, new Vector3(evenNumberArray[e + keyNumber], 100, 0), Quaternion.identity);
                        generatePlayerGameobject.transform.SetParent(canvas.transform, false);
                        //comboの値を上昇させる
                        judge++;
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
                        judge++;
                    }
                    else if (generalKeyArray[keyNumber] == 5)
                    {
                        generatePlayerGameobject = Instantiate(RightArrowBlue, new Vector3(evenNumberArray[e + keyNumber], 100, 0), Quaternion.identity);
                        generatePlayerGameobject.transform.SetParent(canvas.transform, false);
                        currentMP += healPoint;
                        judge++;
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
                        judge++;
                    }
                    else if (generalKeyArray[keyNumber] == 5)
                    {
                        generatePlayerGameobject = Instantiate(LeftArrowBlue, new Vector3(evenNumberArray[e + keyNumber], 100, 0), Quaternion.identity);
                        generatePlayerGameobject.transform.SetParent(canvas.transform, false);
                        currentHP += balanceHealPoint;
                        currentMP += balanceHealPoint;
                        //comboの値を少しだけ上昇させる
                        judge++;
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

            if(Input.GetKeyDown(KeyCode.KeypadEnter))
            {
                if(isKnock == true)
                {
                    Knock();
                    isKnock = false;
                    isKnockEnter = true;
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

        if(currentHP >= maxHP)
        {
            GreenGauge.enabled = true;
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
        timeLimit = 3;
        judge = 0;

        PlayerKeyAllayGenerate();
        //Debug.Log("現在のkeyNumber" + keyNumber);
    }

    public void OneTurnSwitcher()
    {
        isOneTurn = true;
        isGenerate = true;

        Debug.Log("Restart");
    }

    public void UIReset()
    {
        foreach (GameObject i in generatePlayerGameObjectArray)
        {
            Destroy(i);
        }

        foreach (GameObject i in generateGeneralGameObjectArray)
        {
            Destroy(i);
        }
    }

    public void Judge()
    {
        if(judge < arraylength/3)
        {
            Debug.Log("Hopeless");
        }
        if(judge >= arraylength/3 && judge < arraylength / 2)
        {
            Debug.Log("Not Enough");
        }
        if(judge >= arraylength / 2 && judge < arraylength)
        {
            Debug.Log("Good!");
            combo++;
        }
        if(judge == arraylength)
        {
            Debug.Log("Perfect!");
            combo += 5;
        }
    }

    public void Knock()
    {
        int o = (9 - arraylength) / 2;
        int e = (8 - arraylength) / 2;
        currentMP = 0;
        judge = arraylength;
        for (int i = 0; i < arraylength; i++)
        {
            playerKeyArray[i] = generalKeyArray[i];
            if (arraylength % 2 == 1)
            {
                GameObject generatePlayerGameobject = null;
                if (generalKeyArray[i] == 1)
                {
                    Destroy(generateGeneralGameObjectArray[i]);
                    generatePlayerGameobject = Instantiate(UpArrowPink, new Vector3(oddNumberArray[o + i], 100, 0), Quaternion.identity);
                    generatePlayerGameobject.transform.SetParent(canvas.transform, false);
                    generatePlayerGameObjectArray[i] = generatePlayerGameobject;
                }
                else if (generalKeyArray[i] == 2)
                {
                    Destroy(generateGeneralGameObjectArray[i]);
                    generatePlayerGameobject = Instantiate(DownArrowPink, new Vector3(oddNumberArray[o + i], 100, 0), Quaternion.identity);
                    generatePlayerGameobject.transform.SetParent(canvas.transform, false);
                    generatePlayerGameObjectArray[i] = generatePlayerGameobject;
                }
                else if (generalKeyArray[i] == 3)
                {
                    Destroy(generateGeneralGameObjectArray[i]);
                    generatePlayerGameobject = Instantiate(RightArrowPink, new Vector3(oddNumberArray[o + i], 100, 0), Quaternion.identity);
                    generatePlayerGameobject.transform.SetParent(canvas.transform, false);
                    generatePlayerGameObjectArray[i] = generatePlayerGameobject;
                }
                else if (generalKeyArray[i] == 4)
                {
                    Destroy(generateGeneralGameObjectArray[i]);
                    generatePlayerGameobject = Instantiate(LeftArrowPink, new Vector3(oddNumberArray[o + i], 100, 0), Quaternion.identity);
                    generatePlayerGameobject.transform.SetParent(canvas.transform, false);
                    generatePlayerGameObjectArray[i] = generatePlayerGameobject;
                }
                else if (generalKeyArray[i] == 5)
                {
                    Destroy(generateGeneralGameObjectArray[i]);
                    generatePlayerGameobject = Instantiate(UpArrowBlue, new Vector3(oddNumberArray[o + i], 100, 0), Quaternion.identity);
                    generatePlayerGameobject.transform.SetParent(canvas.transform, false);
                    generatePlayerGameObjectArray[i] = generatePlayerGameobject;
                }
            }

            if (arraylength % 2 == 0)
            {
                GameObject generatePlayerGameobject = null;
                if (generalKeyArray[i] == 1)
                {
                    Destroy(generateGeneralGameObjectArray[i]);
                    generatePlayerGameobject = Instantiate(UpArrowPink, new Vector3(evenNumberArray[e + i], 100, 0), Quaternion.identity);
                    generatePlayerGameobject.transform.SetParent(canvas.transform, false);
                    generatePlayerGameObjectArray[i] = generatePlayerGameobject;
                }
                else if (generalKeyArray[i] == 2)
                {
                    Destroy(generateGeneralGameObjectArray[i]);
                    generatePlayerGameobject = Instantiate(DownArrowPink, new Vector3(evenNumberArray[e + i], 100, 0), Quaternion.identity);
                    generatePlayerGameobject.transform.SetParent(canvas.transform, false);
                    generatePlayerGameObjectArray[i] = generatePlayerGameobject;
                }
                else if (generalKeyArray[i] == 3)
                {
                    Destroy(generateGeneralGameObjectArray[i]);
                    generatePlayerGameobject = Instantiate(RightArrowPink, new Vector3(evenNumberArray[e + i], 100, 0), Quaternion.identity);
                    generatePlayerGameobject.transform.SetParent(canvas.transform, false);
                    generatePlayerGameObjectArray[i] = generatePlayerGameobject;
                }
                else if (generalKeyArray[i] == 4)
                {
                    Destroy(generateGeneralGameObjectArray[i]);
                    generatePlayerGameobject = Instantiate(LeftArrowPink, new Vector3(evenNumberArray[e + i], 100, 0), Quaternion.identity);
                    generatePlayerGameobject.transform.SetParent(canvas.transform, false);
                    generatePlayerGameObjectArray[i] = generatePlayerGameobject;
                }
                else if (generalKeyArray[i] == 5)
                {
                    Destroy(generateGeneralGameObjectArray[i]);
                    generatePlayerGameobject = Instantiate(UpArrowBlue, new Vector3(evenNumberArray[e + i], 100, 0), Quaternion.identity);
                    generatePlayerGameobject.transform.SetParent(canvas.transform, false);
                    generatePlayerGameObjectArray[i] = generatePlayerGameobject;
                }              
            }
        } 
    }
}
