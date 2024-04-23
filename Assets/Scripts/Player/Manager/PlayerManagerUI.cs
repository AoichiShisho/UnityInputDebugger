using UnityEngine;
using UnityEngine.UI;

public class PlayerManagerUI : MonoBehaviour
{
    public PlayerSettings settings;
    [SerializeField] private PlayerManager playerManager;
    public Text playerCountText;
    public Button increaseButton;
    public Button decreaseButton;

    void Start()
    {
        playerManager = GetComponent<PlayerManager>();
        UpdatePlayerCountText();
        increaseButton.onClick.AddListener(IncreasePlayerCount);
        decreaseButton.onClick.AddListener(DecreasePlayerCount);
    }

    public void IncreasePlayerCount()
    {
        if (settings.playerCount < settings.maxPlayerCount)
        {
            settings.playerCount++;
            playerManager.UpdatePlayerActiveState();
            UpdatePlayerCountText();
        }
    }

    public void DecreasePlayerCount()
    {
        if (settings.playerCount > settings.minPlayerCount)
        {
            settings.playerCount--;
            playerManager.UpdatePlayerActiveState();
            UpdatePlayerCountText();
        }
    }

    private void UpdatePlayerCountText()
    {
        playerCountText.text = "Players: " + settings.playerCount.ToString();
    }
}