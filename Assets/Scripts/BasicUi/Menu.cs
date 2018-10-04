using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour {
    private PlayerManager player;
    private int width = 100;
    private int height = 30;

    void OnGUI()
    {

        if (player != null)
        {
            if (player.health == 0)
            {
                if (GUI.Button(new Rect((Screen.width - width) / 2, (Screen.height - height) / 2, width, height), "Restart"))
                {
                    Restart();
                }
            }
        }
    }

    private void Restart()
    {
        Application.LoadLevel("MainLevel");
    }

    // Use this for initialization
    void Start () {
        player = Managers.Player;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
