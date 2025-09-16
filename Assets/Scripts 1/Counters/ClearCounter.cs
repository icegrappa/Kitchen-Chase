using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClearCounter : BaseCounter
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;
    public override void Interact(Player player)
    {
        if (!HasKitchenObject())
        {
            // There is no kitchen object here
            if (player.HasKitchenObject())
            {
                //Player is carrying smth
                player.GetKitchenObject().SetKitchenObjectParent(this);
            }
            else
            {
                // Player is not carrying anything 
            }
        }
        else
        {
            // There is a Kitchen object here
            if (player.HasKitchenObject())
            {
                //Player is carrying smth
                if (player.GetKitchenObject().TryGetPlate(out PlateKitchenObject plateKitchenObject))
                {
                    //Player is holding a plate :)
                    if (plateKitchenObject.TryAddIngredient(GetKitchenObject().GetKitchenObjectSO()))
                    {
                        GetKitchenObject().DestroySelf();
                    }
                }
                else
                {
                    //Player is not carrying plate but something else
                    if (GetKitchenObject().TryGetPlate(out plateKitchenObject))
                    {
                        //Counter is holding a plate
                       if (plateKitchenObject.TryAddIngredient(player.GetKitchenObject().GetKitchenObjectSO()));
                       {
                           player.GetKitchenObject().DestroySelf();
                       }
                    }
                }
            }
            else
            {
                // Player is not carrying anything 
                GetKitchenObject().SetKitchenObjectParent(player);
            }
        }
    }
}
