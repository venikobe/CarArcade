using UnityEngine;
using System;
using System.Collections.Generic;
using System.Threading;
using System.IO.Ports;
using System.Globalization;
using System.Linq;
public class MotorControll : MonoBehaviour
{
    Thread motorThread;

    private SerialPort dataStream= new SerialPort("COM3", 9600);

    public string receivingString;
    public float motorInput;
    public string _stickInput;
    public bool StickBool;

    private List<float> _inputlist = new List<float>();





    // Start is called before the first frame update
    void Start()
    {
        dataStream.Open();
        motorThread = new Thread(
            new ThreadStart(RecieveDataMotor));
        motorThread.IsBackground = true;
        motorThread.Start();
    }

    void Update(){RecieveDataMotor();}

    private void RecieveDataMotor()
    {
        try
        {
            receivingString = dataStream.ReadLine();
            string[] _datas = receivingString.Split(';');
            if (_datas[0] == "UP" || _datas[0] == "DOWN" || _datas[0] == "RIGHT" || _datas[0] == "LEFT" || _datas[0] == "NONE")
                _stickInput = _datas[0];
            motorInput = float.Parse(_datas[1], CultureInfo.InvariantCulture);

            _inputlist.Add(motorInput);
            if(_inputlist.Count > 10) {_inputlist.RemoveAt(0);}
            float inputAverage = Queryable.Average(_inputlist.AsQueryable());
            if(inputAverage>0.03 && inputAverage<0.06){StickBool = false;}
            else{StickBool = true;}

        }
        catch(Exception e)
        {
            print(e.ToString());
        }


    }

}
