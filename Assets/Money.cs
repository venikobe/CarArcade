using UnityEngine;
using TMPro;

public class Money : MonoBehaviour
{
    [SerializeField] private int CarMoney = 0;
    [SerializeField] private int OwnerMoney = 250;
    [SerializeField] private TextMeshProUGUI CarMoneyText;

    public void AddMoney(bool OwnerMoney, int augment)
    {
        if(OwnerMoney) {this.OwnerMoney += augment;}
        else{this.CarMoney += augment;CarMoneyText.SetText(this.CarMoney.ToString());}
    }
    public void DecreaseMoney(int decrement)
    {
        OwnerMoney -= decrement;
    }

    public int GetMoney(bool OwnerMoney)
    {
        if(OwnerMoney) {return this.OwnerMoney;}
        else{return this.CarMoney;}
    }


}
