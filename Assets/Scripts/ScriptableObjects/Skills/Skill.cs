using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Skill : ScriptableObject
{
    public abstract void SpellSphere();

    public abstract void SimpleActivate(Player p);
}
