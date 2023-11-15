using System.Collections;
using UnityEngine;

public class CarControll : MonoBehaviour
{

    [SerializeField] MotorControll _mControll;
    [SerializeField] Calendar _Calendar;
    [SerializeField] Money _money;
    [SerializeField] SightManage _sight;

    [SerializeField] GameObject _canvas;
    private Vector3 _movedirection = new Vector3(0,0,4);
    private Quaternion _rotation;
    private bool _isAlive = true;

    [SerializeField] private float speed = 1f;
    [SerializeField] private bool NeedMotor;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(MakeStep());
    }

    // Update is called once per frame
    void Update()
    {
        SetDirection();
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

     private IEnumerator MakeStep()
    {
        while (_isAlive)
        {
            float tickTime = 1f / speed;
            yield return new WaitForSeconds(tickTime);
            if(_sight.CamBool(0) && _canvas.activeSelf)
            {

            if(_mControll.StickBool == true || NeedMotor == false)
            {
                transform.Translate(_movedirection);
                transform.rotation = _rotation;
            }
                _Calendar.AddDate();
                _money.DecreaseMoney(50);
            }

        }
    }

}
