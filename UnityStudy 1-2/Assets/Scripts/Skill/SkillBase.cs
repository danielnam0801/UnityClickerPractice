using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.UI;

public enum skillType
{
    DamageToLowEnemy = 1,
    FarEnemy = 2,
    MostFastEnemy = 3,
    wholeDamage = 4,
    SkillCoolDown = 5
}

public abstract class SkillBase : MonoBehaviour
{
    [SerializeField]
    protected skillType skillType;  
    
    [SerializeField]
    protected float skillCool;
    [SerializeField]
    protected int skillPower;
    [SerializeField]
    protected int skillLevel;

    [SerializeField]
    protected Image skillImage;
    [SerializeField]
    protected Button skillButton; 

    protected EnemyManager _enemyManager;
    protected UIManager _uiManager;

    protected virtual void Awake()
    {
        _enemyManager = GameObject.Find("Manager").GetComponentInChildren<EnemyManager>();
        _uiManager = GameObject.Find("UIManager").GetComponentInChildren<UIManager>();
    }

    public abstract void SkillButtonClick();
    public abstract void SkillAbility();
    protected void SkillDamage(List<Enemy> enemies, float skillValue)
    {
        skillPower = (int)(skillPower * (1 + skillLevel * skillValue));

        foreach (Enemy enemy in enemies)
        {
            enemy.hp -= skillPower;
        }
    }
    protected void SkillDamageOnlyOne(Enemy enemy, float skillValue)
    {
        skillPower = (int)(skillPower * (1 + skillLevel * skillValue));
        enemy.hp -= skillPower;
    }

    protected void CoolDown(float skillCool)
    {
        StartCoroutine(CheckCoolDown(skillCool));
    }

    IEnumerator CheckCoolDown(float skillCool)
    {
        skillButton.interactable = false;
        skillImage.fillAmount = 0;
        float t = 0;
        while (t < skillCool)
        {
            t += Time.deltaTime;
            skillImage.fillAmount = Mathf.Lerp(0, 1, t/skillCool);
            yield return null;
        }
        skillButton.interactable = true;
    }

    public abstract void SkillCoolMinus(float skilltime);
    
}
