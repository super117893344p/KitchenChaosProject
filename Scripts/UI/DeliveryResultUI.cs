using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryResultUI : MonoBehaviour
{
    private const string IS_SHOW = "IsShow";

    [SerializeField] private Animator deliverySuccessUIAnimator;
    [SerializeField] private Animator deliveryFailUIAnimator;
         
    // Start is called before the first frame update
    void Start()
    {
        OrderMananger.Instance.OnRecipeSuccessed += OrderManager_OnRecipeSuccessed;
        OrderMananger.Instance.OnRecipeFailed += OrderManager_OnRecipeFailed;
    }

    private void OrderManager_OnRecipeFailed(object sender, System.EventArgs e)
    {
        deliveryFailUIAnimator.gameObject.SetActive(true);
        deliveryFailUIAnimator.SetTrigger(IS_SHOW);
    }

    private void OrderManager_OnRecipeSuccessed(object sender, System.EventArgs e)
    {
        deliverySuccessUIAnimator.gameObject.SetActive(true);
        deliverySuccessUIAnimator.SetTrigger(IS_SHOW);
    }

}
