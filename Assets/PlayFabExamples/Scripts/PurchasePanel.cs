using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using PlayFab;
using PlayFab.ClientModels;

public class PurchasePanel : MonoBehaviour
{
    public Text ItemDisplay;
    public Text ItemDesc;
    public Text ItemCost;
    public Button ConfirmPurchase;
    public Button CancelPurchase;

    public StartPurchaseResult Order;

	// Use this for initialization
    private void OnEnable()
    {
        Order = PlayFabDataStore.Orders.Dequeue();
        var itemId = Order.Contents[0].ItemId;
        var cost = Order.Contents[0].VirtualCurrencyPrices["GO"];
        var catItem = PlayFabDataStore.Catalog.Find((ci) => { return ci.ItemId == itemId; });
        if (catItem != null)
        {
            ItemDisplay.text = catItem.DisplayName;
            ItemDesc.text = catItem.Description;
            ItemCost.text = string.Format("Cost: {0} Gold Coins", cost);
        }

        ConfirmPurchase.onClick.AddListener(HandleConfirmPurchase);
        CancelPurchase.onClick.AddListener(HandleCancelPurchase);
    }

    private void HandleConfirmPurchase()
    {
        if (Order != null)
        {
            var payRequest = new PayForPurchaseRequest()
            {
                OrderId = Order.OrderId,
                ProviderName = string.Format("Title{0}",PlayFabSettings.TitleId),
                Currency = "GO"
            };
            PlayFabClientAPI.PayForPurchase(payRequest, (payResult) =>
            {
                //Here we should add to the inventory locally in the game and then confirm the purchase.
                //But for now we are just going to confirm the purchase.
                var confirmRequest = new ConfirmPurchaseRequest()
                {
                    OrderId = payResult.OrderId
                };
                PlayFabClientAPI.ConfirmPurchase(confirmRequest, (confirmResult) =>
                {
                    Debug.Log("Purchase was completed.");
                    Order = null;
                    WindowManager.SendEvent("Store");
                }, PlayFabErrorHandler.HandlePlayFabError);

            }, PlayFabErrorHandler.HandlePlayFabError);
        }
    }

    private void HandleCancelPurchase()
    {
        throw new System.NotImplementedException();
    }

}
