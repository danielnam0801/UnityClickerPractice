using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WholeDamageSkillinFront : SkillBase
{
    protected override void Awake()
    {
        skillType = skillType.DamageToLowEnemy;
        base.Awake();
    }

    public override void SkillButtonClick()
    {
        if (skillButton.interactable == true)
        {
            skillLevel = _uiManager.currentLevel;
            CoolDown(skillCool);
            SkillAbility();
        }
    }

    public override void SkillAbility()
    {
        List<Enemy> list = new List<Enemy>();
        //Debug.LogError("아직 구현 안됨");
        int enemyCount = _enemyManager.enemyList.Count;
        for(int i = 0; i < enemyCount; i++)
        {
            if (i > 5) break;
            else
            {
                if(enemyCount <= i)
                    list.Add(_enemyManager.enemyList[i-enemyCount]);
                else 
                    list.Add(_enemyManager.enemyList[i]);
            }
        }
        SkillDamage(list,0.1f);
    }

    public override void SkillCoolMinus(float skilltime)
    {
        if(skillCool > 0)
        skillCool -= skilltime;
    }
}
