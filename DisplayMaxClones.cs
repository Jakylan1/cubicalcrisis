using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayMaxClones : MonoBehaviour
{
    public TextMeshProUGUI tmp;

    void Start(){
        tmp = GetComponent<TextMeshProUGUI>();
    }

    void Update(){
        tmp.text = "Max Clones: " + GameManager.Instance.playerMaxClones.ToString();
    }
}
