using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StorePanel : MonoBehaviour
{
    public GameObject StoreItemPrefab;
    public GameObject StoreItemContainer;

	// Use this for initialization
	void OnEnable ()
	{
        //remove any exiting items in the container
	    var items = StoreItemContainer.GetComponentsInChildren<Item>();
	    foreach (var item in items)
	    {
	        Destroy(item.gameObject);
	    }
        
        //populate the container with new items.
	    foreach (var item in PlayFabDataStore.Store)
	    {
            //find associated catalog item. 
	        var catItem = PlayFabDataStore.Catalog.Find((ci) => { return ci.ItemId == item.ItemId; });
	        if (catItem == null){ continue; }

	        var storeItem = Instantiate(StoreItemPrefab, Vector3.zero, Quaternion.identity) as GameObject;
            //If for some reason Instantiate fails, break;
	        if (storeItem == null) { continue; }

	        var storeItemClass = storeItem.GetComponent<Item>();
	        storeItemClass.StoreItem = item;
	        storeItemClass.ItemDisplay.text = catItem.DisplayName;
	        storeItemClass.ItemDesc.text = catItem.Description;
	        storeItemClass.BuyButton.GetComponentInChildren<Text>().text = string.Format("Buy for {0} Gold", item.VirtualCurrencyPrices["GO"]);
	        storeItem.transform.SetParent(StoreItemContainer.transform);
	        //We do this so that the UI doesn't get a distored scale (kinda a unity bug)
	        storeItem.transform.localScale = Vector3.one;
	    }

	}
}
