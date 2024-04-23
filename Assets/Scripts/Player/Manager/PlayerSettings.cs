using UnityEngine;

[CreateAssetMenu(fileName = "PlayerSettings", menuName = "Player/PlayerSettings", order = 1)]
public class PlayerSettings : ScriptableObject
{
    public int minPlayerCount = 2;
    public int maxPlayerCount = 4;
    public int playerCount = 2;
}