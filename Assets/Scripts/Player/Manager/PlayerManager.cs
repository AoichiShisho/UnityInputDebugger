using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public PlayerSettings settings;
    // [SerializeField] private GameObject[] players;
    private GameObject[] players;
    
    void Start()
    {
        players = new GameObject[settings.playerCount];
        for (int i = 0; i < settings.playerCount; i++)
        {
            players[i] = transform.GetChild(i).gameObject;
        }
        UpdatePlayerActiveState();
    }

    public void UpdatePlayerActiveState()
    {
        for (int i = 0; i < players.Length; i++)
        {
            players[i].SetActive(i < settings.playerCount);
        }
    }
}