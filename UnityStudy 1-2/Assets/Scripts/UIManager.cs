using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Numerics;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI gold_txt;
    [SerializeField] TextMeshProUGUI stage_txt;
    [SerializeField] TextMeshProUGUI level_txt;

    public BigInteger goldAmount = 0;
    public int currentStage = 1;
    public int currentLevel = 1;    
    public int currentEnemyDie = 0;

    StageManager stageManager;

    Clicker clicker;
    void Start()
    {
        clicker = FindObjectOfType<Clicker>();
        stageManager = GameObject.Find("Manager").GetComponentInChildren<StageManager>();   
    }
    void Update()
    {
        //gold_txt.text = $"GOLD : {goldAmount}";
        gold_txt.text = $"GOLD : {CheckDanwi(goldAmount)}";
        stage_txt.text = $"Stage : {currentStage.ToString()}";
        level_txt.text = $"Level : {currentLevel.ToString()}";
        if(currentEnemyDie >= 10)
        {
            stageManager.canSpawnBoss = true;
            currentStage++;
            currentEnemyDie = 0;
        }
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
                moneyStr = (money / (BigInteger)Mathf.Pow(10, 3)).ToString() + "K";
                break;
            case 7:
            case 8:
            case 9:
                moneyStr = (money / (BigInteger)Mathf.Pow(10, 6)).ToString() + "M";
                break;
            case 10:
            case 11:
            case 12:
                moneyStr = (money / (BigInteger)Mathf.Pow(10, 9)).ToString() + "B";
                break;
            case 13:
            case 14:
            case 15:
                moneyStr = (money / (BigInteger)Mathf.Pow(10, 12)).ToString() + "T";
                break;
            default:
                string mon = money.ToString();
                moneyStr = $"{mon[0]}.{mon[1]}{mon[2]}E" + "+" + ((money / (BigInteger)Mathf.Pow(10, 12)).ToString().Length + 15 - 1).ToString();
                break;
        }
        return moneyStr;
    }
    public void PlusButtonClick()
    {
        goldAmount += 12345678;
    }
    public void LevelUPButtonClick()
    {
        
        if(goldAmount > clicker.levelUpCost)
        {
            currentLevel++;
            goldAmount -= clicker.levelUpCost;
        }
    }

    public void MultiplyButtonClick()
    {
        goldAmount *= 11;
    }
    IEnumerator ReStart()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(0);
    }
    public void GameReStart()
    {
        StartCoroutine(ReStart());
    }
}
