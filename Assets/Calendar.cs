using System;
using UnityEngine;
using TMPro;

public class Calendar : MonoBehaviour
{
    private DateTime _curentDate = DateTime.Today;
    private DateTime _curentDateForOwner;
    [SerializeField] private Money money;
    [SerializeField] private TextMeshProUGUI DateText;


    //[SerializeField] private string _curentDateString;
    void Start()
    {
        OnStart();
    }

    public void AddDate()
    {
        _curentDate = _curentDate.AddDays(7);
        _curentDateForOwner = _curentDateForOwner.AddDays(7);
        ChangeText(DateText,_curentDate.ToString("d"));
        
        //_curentDateString = _curentDate.ToString();


        if(_curentDate.Day <= 7){money.AddMoney(false,10);} 
    }

    private void ChangeText(TextMeshProUGUI _text, string _string){_text.SetText(_string);}
    
    public void OnStart(){_curentDate = DateTime.Today;ChangeText(DateText,_curentDate.ToString("d"));}
}
