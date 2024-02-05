using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private GameObject uiParent;
    [SerializeField] private TextMeshProUGUI numberText;

    // Start is called before the first frame update
    void Start()
    {
        Hide();
        GameManager.Instance.OnStateChanged += GameManager_OnStateChanged;
    }

    private void GameManager_OnStateChanged(object sender, System.EventArgs e)
    {
        if (GameManager.Instance.IsGameOverState())
        {
            Show();
        }
    }

    private void Show()
    {
        numberText.text = OrderMananger.Instance.GetSuccessDeliveryCount().ToString();
        uiParent.SetActive(true);
    }
    private void Hide()
    {
        uiParent.SetActive(false);
    }
}
