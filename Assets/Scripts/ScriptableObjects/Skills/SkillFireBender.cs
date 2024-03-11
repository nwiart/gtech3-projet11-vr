using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;


[CreateAssetMenu(menuName = "Skills/Fire Bender")]
public class SkillFireBender : Skill
{
    [SerializeReference]
    private GameObject _flamePrefab;

    private GameObject _flame = null;


    public override void SpellSphere()
    {
    }

    public override void SimpleActivate(Player p)
    {
        if (_flame == null)
        {
            _flame = Instantiate(_flamePrefab);
            _flame.transform.SetParent(p.LeftHand.transform, false);
        }
        else
        {
            Destroy(_flame);
        }
    }
}
