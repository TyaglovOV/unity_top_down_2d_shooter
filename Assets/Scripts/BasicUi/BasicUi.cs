using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicUi : MonoBehaviour {
    private PlayerManager player;
    private SkillsManager skills;
    private WeaponsManager weapon;

    void OnGUI()
    {
        int posX = 10;
        int posY = 10;
        int offset = 50;
        int width = 100;
        int height = 30;

        if (player != null && skills != null && weapon != null)
        {
            GUI.Box(new Rect(posX, posY, width, height), "Health: " + player.health.ToString() + "/" + player.maxHealth.ToString());

            GUI.Box(new Rect(posX, posY + offset, width, height), "Mana: " + player.mana.ToString() + "/" + player.maxMana.ToString());

            string selectedSkill;

            if (skills.selectedSkill == SkillsNames.Teleport)
            {
                selectedSkill = "RMB: teleport";
            }

            else if (skills.selectedSkill == SkillsNames.Turret)
            {
                selectedSkill = "Turret";
            }

            else
            {
                selectedSkill = "Empty";
            }

            GUI.Box(new Rect(posX, posY + offset * 2, width, height), selectedSkill);

            WeaponsNames selectedWeapon = weapon.selectedWeapon;

            if (selectedWeapon == WeaponsNames.Minigun)
            {
                if (GUI.Button(new Rect(posX, posY + offset * 3, width, height), "Select shootgun"))
                {
                    weapon.SelectShootgun();
                }
            }

            if (selectedWeapon == WeaponsNames.Shootgun)
            {
                if (GUI.Button(new Rect(posX, posY + offset * 3, width, height), "Select minigun"))
                {
                    weapon.SelectMinigun();
                }
            }
        }
    }

    // Use this for initialization
    void Start () {
        player = Managers.Player;
        skills = Managers.Skills;
        weapon = Managers.Weapons;
    }
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            
        }
	}
}
