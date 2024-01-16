using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using TMPro;
using UnityEngine;

public class PlayerSetup : MonoBehaviour
{
 public Movement movement;

 public GameObject cameraa;
public void IsLocalPlayer(){
    movement.enabled = true;
    cameraa.SetActive(true);
}
}