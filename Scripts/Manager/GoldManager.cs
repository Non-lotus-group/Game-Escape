using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldManager : MonoBehaviour
{
    //this script is using for manage Exp of Player and Gold
    // Start is called before the first frame update
    public float Experence;
    public int gold;
    public ArrayList LevelUpCpunt;
    void Start()
    {
        Experence = 0;
        gold = 0;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Gold")
        {
            gold += collision.GetComponent<Gold>().AddGold;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Exp")
        {
            Experence += collision.GetComponent<Exp>().AddExp;
            Destroy(collision.gameObject);
            Debug.Log(Experence);
        }
    }
}
