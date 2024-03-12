using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : ScriptableObject
{
    public virtual void OnUnlock(Player player) { }

    public virtual void SpellSphere() { }

    public virtual void SimpleActivate(Player p) { }
}
