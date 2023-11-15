using System.Collections;
using UnityEngine;

public class Blocktrees : MonoBehaviour
{
    [SerializeField] float DelayOfRespawn = 3;
    [SerializeField] Money _money;
    void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out CarControll car))
        {
            foreach (Transform child in transform){
                StartCoroutine(RespawnTrees(child));
                child.gameObject.SetActive(false);
            }
            _money.AddMoney(true,500);
        }
    }


    IEnumerator RespawnTrees(Transform child)
    {
        yield return new WaitForSeconds(DelayOfRespawn);
        child.gameObject.SetActive(true);

    }



}
