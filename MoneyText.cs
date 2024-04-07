using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyText : MonoBehaviour
{
    public TextMeshProUGUI tmp;

    void Start(){
        tmp = GetComponent<TextMeshProUGUI>();
    }

    void Update(){
        tmp.text = GameManager.Instance.playerMoney.ToString("000000000");
    }
}
