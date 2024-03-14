using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;


[CreateAssetMenu(menuName = "Skills/Lightning Bender")]
public class SkillLightningBender : Skill
{
    [SerializeReference]
    private GameObject _lightningBoltPrefab;


    public override void OnUnlock(Player player)
    {
    }

    public override void SimpleActivate(Player p)
    {
        GameObject _flame = Instantiate(_lightningBoltPrefab);
        _flame.transform.SetParent(p.RightHand.transform, false);
    }

    public override void SpellSphere()
    {
        
    }
}
