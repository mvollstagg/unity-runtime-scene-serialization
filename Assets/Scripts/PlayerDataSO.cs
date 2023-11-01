using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerDataSO", menuName = "ScriptableObjects/PlayerDataSO", order = 1)]
public class PlayerDataSO : ScriptableObject
{
    public int playerHealth;
    public int playerScore;
    public int playerLevel;
    public int playerExperience;
    public int playerGold;
    public PlayerAbility[] playerAbilities;
}
