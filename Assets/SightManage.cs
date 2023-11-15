using UnityEngine;

public class SightManage : MonoBehaviour
{
    public UDPReceive uDPReceive;
    [SerializeField] GameObject cam;
    [SerializeField] GameObject cam1;

    [SerializeField] GameObject _carCanvas;

    [SerializeField] GameObject _stockCanvas;
    
    void Update()
    { 
        int data;
        bool success = int.TryParse(uDPReceive.data, out data);
        if (success)
        {
            switch(data)
            {
                case 0:
                    Cam();
                    break;
                case 1:
                    Cam1();
                    break;
                case 2:
                    Cam2();
                    break;
                case 3:
                    Cam();
                    break;
            }
        }

    }


    void Cam(){cam.SetActive(true);cam1.SetActive(false);_carCanvas.SetActive(true);_stockCanvas.SetActive(false);}
    void Cam1(){cam.SetActive(false);cam1.SetActive(true);_carCanvas.SetActive(false);_stockCanvas.SetActive(false);}
    void Cam2(){cam.SetActive(true);cam1.SetActive(false);_carCanvas.SetActive(false);_stockCanvas.SetActive(true);}

    public bool CamBool(int _case)
    {
          if(_case == 0)
          {
            return cam.activeSelf;
          }
          else if(_case == 1)
          {
            return cam1.activeSelf;
          }
          else{return false;}
    }
}
