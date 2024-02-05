using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ClearCounter : BaseCounter
{

    public override void Interact(Player player)
    {
        if (player.IsHaveKitchenObject())
        {//������KitchenObject

            if(player.GetKitchenObject()
                .TryGetComponent<PlateKitchenObject>(out PlateKitchenObject plateKitchenObject))
            {//����������
                if (IsHaveKitchenObject() == false)
                {//��ǰ��̨ Ϊ��
                    TransferKitchenObject(player, this);
                }
                else
                {//��ǰ��̨ ��Ϊ��
                    bool isSuccess = plateKitchenObject.AddKitchenObjectSO( GetKitchenObjectSO());
                    if (isSuccess)
                    {
                        DestroyKitchenObject();
                    }
                }
            }
            else
            {//��������ͨʳ��
                if (IsHaveKitchenObject() == false)
                {//��ǰ��̨ Ϊ��
                    TransferKitchenObject(player, this);
                }
                else
                {//��ǰ��̨ ��Ϊ��
                    if(GetKitchenObject().TryGetComponent<PlateKitchenObject>(out plateKitchenObject))
                    {

                        if(plateKitchenObject.AddKitchenObjectSO( player.GetKitchenObjectSO()))
                        {
                            player.DestroyKitchenObject();
                        }

                    }

                }
            }

            //if (IsHaveKitchenObject() == false)
            //{//��ǰ��̨ Ϊ��
            //    TransferKitchenObject(player, this);
            //}
            //else
            //{//��ǰ��̨ ��Ϊ��

            //}
        }
        else
        {//����ûʳ��
            if (IsHaveKitchenObject() == false)
            {//��ǰ��̨ Ϊ��
                
            }
            else
            {//��ǰ��̨ ��Ϊ��
                TransferKitchenObject(this, player);
            }
        }
    }

}
