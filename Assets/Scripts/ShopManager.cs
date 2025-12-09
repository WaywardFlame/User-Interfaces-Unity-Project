using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public GameObject ShopUI;

    public void ShowShop(){
        ShopUI.SetActive(true);
        ShopUI.GetComponent<ShopController>().Refresh();
    }
}
