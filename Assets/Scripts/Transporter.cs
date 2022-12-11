using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transporter : Tile
{
    // Serialized *****
    [SerializeField] private GameObject successVfxPrefab;
    
    // MonoBehavior Callbacks *****

    // Public Methods *****
    public override void ActionComplete()
    {
        _onActionComplete();
    }

    // Private Methods *****
    public override void TakeAction(PlayerInteraction owner, Item playerItem, Action onActionComplete)
    {
        _onActionComplete = onActionComplete;
        
        if (playerItem && playerItem.TryGetComponent(out Plate plate) && plate.IsCookedFood())
        {
            if (GrabItem(playerItem))
            {
                owner.DropItem();
                SuccessOrder();
            }
            
        }
    }

    protected override void TakeAdvanceAction(PlayerInteraction owner)
    {
        
    }
    private void SuccessOrder()
    {
        Debug.Log("Order success");
        GameManager.Instance.SuccessOrder();
        GameObject successVfx = Instantiate(successVfxPrefab, itemAnchor);
        DropItem(true);
    }
}
