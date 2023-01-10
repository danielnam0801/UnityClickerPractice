using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Numerics;

public class UIManager : MonoBehaviour
{
    public static BigInteger moneyCnt = 0;

    [SerializeField]
    TextMeshProUGUI moneyCntTxt;
    [SerializeField]
    TextMeshProUGUI stageTxt;

    private void Awake()
    {
        moneyCnt = 0;
        moneyCntTxt = GameObject.Find("Money").GetComponent<TextMeshProUGUI>();
    }

    public void Update()
    {
        moneyCntTxt.text = moneyCnt.ToString();
        stageTxt.text = "Stage : " + StageManager.stageLevel.ToString();
    }

    public void OnClickMoney()
    {
        moneyCnt *= 11;
        moneyCntTxt.text = CheckDanwi(moneyCnt);
    }

    public string CheckDanwi(BigInteger money)
    {
        string moneyStr = "";
        switch (money.ToString().Length)
        {
            case 0:
            case 1:
            case 2:
            case 3:
                moneyStr = money.ToString();
                break;
            case 4:
            case 5:
            case 6:
                moneyStr =  (money/(BigInteger)Mathf.Pow(10,3)).ToString() + "K";
                break;
            case 7:
            case 8:
            case 9:
                moneyStr = (money/ (BigInteger)Mathf.Pow(10, 6)).ToString() + "M";
                break;
            case 10:
            case 11:
            case 12:
                moneyStr = (money/ (BigInteger)Mathf.Pow(10, 9)).ToString() + "B";
                break;
            case 13:
            case 14:
            case 15:
                moneyStr = (money / (BigInteger)Mathf.Pow(10, 12)).ToString() + "T";
                break;
            default:
                string mon = money.ToString();
                moneyStr = $"{mon[0]}.{mon[1]}{mon[2]}E" + "+" + ((money/ (BigInteger)Mathf.Pow(10, 12)).ToString().Length + 15-1).ToString();
                break ;
        }
        return moneyStr;
    }
}

