using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerAbility", menuName = "ScriptableObjects/PlayerAbility", order = 1)]
public class PlayerAbility : ScriptableObject
{
    public string name;
    public int damage;
    public int cost;
    public PlayerAbilityTypeEnum type;
}
