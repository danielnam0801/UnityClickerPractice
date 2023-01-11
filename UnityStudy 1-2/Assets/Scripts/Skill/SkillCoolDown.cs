using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillCoolDown : SkillBase
{
    [SerializeField]
    List<SkillBase> skillCoolDownList;
    public float coolDownValue = 3f;

    protected override void Awake()
    {
        skillType = skillType.SkillCoolDown;
        base.Awake();
    }

    public override void SkillButtonClick()
    {
        if (skillButton.interactable == true)
        {
            CoolDown(skillCool);
            SkillAbility();
        }
    }

    public override void SkillAbility()
    {
        foreach(var skill in skillCoolDownList)
        {
            skill.SkillCoolMinus(3);
        }
    }

    public override void SkillCoolMinus(float skilltime)
    {
        if (skillCool > 0)
            skillCool -= skilltime;
    }
}
