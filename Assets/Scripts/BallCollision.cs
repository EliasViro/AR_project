using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BallCollision : MonoBehaviour {

    private GameObject TextWindow;

    private void Awake()
    {
        TextWindow = GameObject.Find("Canvas");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")) {
            TextWindow.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
        }
    }
}
