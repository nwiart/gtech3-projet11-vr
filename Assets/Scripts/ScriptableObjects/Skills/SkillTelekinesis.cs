using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Skills/Telekinesis")]
public class SkillTelekinesis : Skill
{
    public override void OnUnlock(Player player)
    {
        player.SetRayInteractorsEnabled(true);
    }
}
