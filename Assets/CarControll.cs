using System.Collections;
using Stocks.Views;
using TMPro;
using Unity.Mathematics;
using UnityEngine;

public class CarControll : MonoBehaviour
{

    [SerializeField] MotorControll _mControll;
    [SerializeField] Calendar _Calendar;
    [SerializeField] Money _money;
    [SerializeField] SightManage _sight;
    [SerializeField] TextMeshProUGUI _restart;

    [SerializeField] GameObject _canvas;
    private Vector3 _movedirection = new Vector3(0,0,4);
    private Quaternion _rotation;
    public bool _isAlive = true;
    private Vector3 _startLocation = new Vector3();
    private Quaternion _startrotation;

    [SerializeField] private float speed = 1f;
    [SerializeField] private bool NeedMotor;
    // Start is called before the first frame update
    void Start()
    {
        _startLocation = this.transform.position;
        _startrotation = this.transform.rotation;
        StartCoroutine(MakeStep());
    }

    // Update is called once per frame
    void Update()
    {
        SetDirection();
        StockControll();
        if (_restart.enabled = true && _mControll._stickInput == "DOWN"){Restart();}
    }

    private void SetDirection()
    {

        if(_mControll._stickInput == "LEFT")
        {
            _rotation = Quaternion.Euler(0,-90,0);
            
        }
        if (_mControll._stickInput == "RIGHT")
        {
            _rotation = Quaternion.Euler(0,90,0);
            
        }
            
        if (_mControll._stickInput == "DOWN")
        {
            _rotation = Quaternion.Euler(0,180,0);
            
        }
        if (_mControll._stickInput == "UP")
        {
            _rotation = Quaternion.Euler(0,0,0);
            
        }    
    }

    private void StockControll()
    {
        if(_sight._stockCanvas.activeSelf)
        {
            if(_mControll._stickInput == "LEFT"){_sight._stockCanvas.GetComponentInChildren<StockViewModel>().Sell();}
            if(_mControll._stickInput == "RIGHT"){_sight._stockCanvas.GetComponentInChildren<StockViewModel>().Buy();;}
        }
    }
     private IEnumerator MakeStep()
    {
        while (_isAlive && _money.GetMoney(true) > 0)
        {
            float tickTime = 1f / speed;
            yield return new WaitForSeconds(tickTime);
            if(_isAlive == false){_restart.enabled = true;StopAllCoroutines();}
            if(_sight.CamBool(0) && _canvas.activeSelf)
            {

            if(_mControll.StickBool == true || NeedMotor == false)
            {
                transform.Translate(_movedirection);
                transform.rotation = _rotation;
            }
            }
                _Calendar.AddDate();
                _money.DecreaseMoney(25);
                _sight._stockCanvas.GetComponentInChildren<StockViewModel>().CashValue.Set(_money.GetMoney(true));


        }
    }
    void Restart()
    {
        this.transform.position = _startLocation;
        this.transform.rotation = _startrotation;
        _Calendar.OnStart();
        _money.OnStart();
        _restart.enabled = false;
        _isAlive = true;
        StartCoroutine(MakeStep());
    }

}
