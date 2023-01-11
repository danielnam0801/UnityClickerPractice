using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LowHpEnemySkill : SkillBase
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
        list = _enemyManager.enemyList.OrderBy(n => n.hp).ToList();
        SkillDamageOnlyOne(list[0],0.2f);
    }

    public override void SkillCoolMinus(float skilltime)
    {
        if (skillCool > 0)
            skillCool -= skilltime;
    }
}
