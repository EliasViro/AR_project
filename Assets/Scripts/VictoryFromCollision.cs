using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VictoryFromCollision : MonoBehaviour
{
    private TextMeshProUGUI textBox;

    private void Awake()
    {
        textBox = GameObject.Find("VictoryText").GetComponent<TextMeshProUGUI>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            textBox.enabled = true;
        }
    }
}
