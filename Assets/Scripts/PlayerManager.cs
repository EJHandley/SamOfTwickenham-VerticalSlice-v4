using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    #region Singleton

    public static PlayerManager instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion

    public GameObject player;

    public GameObject hud;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            if (hud.activeSelf)
            {
                hud.SetActive(false);
            }
            else
            {
                hud.SetActive(true);
            }
        }
    }
}
