using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
  public void MENU_ACTION_Restart(string sceneName) 
    {
        Application.LoadLevel(sceneName);
    }
}
