using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameClockUI : MonoBehaviour
{
    [SerializeField] private GameObject uiParent;
    [SerializeField] private Image progressImage;
    [SerializeField] private TextMeshProUGUI timeText;

    private void Start()
    {
        GameManager.Instance.OnStateChanged += GameManager_OnStateChanged;
        Hide();
    }

    private void Update()
    {
        if (GameManager.Instance.IsGamePlayingState())
        {
            progressImage.fillAmount = GameManager.Instance.GetGamePlayingTimerNormalized();
            timeText.text = Mathf.CeilToInt(GameManager.Instance.GetGamePlayingTimer()).ToString();
        }
    }

    private void GameManager_OnStateChanged(object sender, System.EventArgs e)
    {
        if (GameManager.Instance.IsGamePlayingState())
        {
            Show();
        }
    }

    private void Show()
    {
        uiParent.SetActive(true);
    }
    private void Hide()
    {
        uiParent.SetActive(false);
    }
}
