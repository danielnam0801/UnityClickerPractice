using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class FarEnemyDamageSkill : SkillBase
{

    protected override void Awake()
    {
        skillType = skillType.FarEnemy;
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
        list = _enemyManager.enemyList.OrderByDescending(n => Vector3.Distance(transform.position, n.transform.position)).ToList();
        SkillDamageOnlyOne(list[0],0.2f);
    }

    public override void SkillCoolMinus(float skilltime)
    {
        if (skillCool > 0)
            skillCool -= skilltime;
    }
}
