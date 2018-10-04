using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkillsController : MonoBehaviour {
    private SkillsManager skill;

	// Use this for initialization
	void Start () {
        skill = Managers.Skills;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(1))
        {
            if (skill != null)
            {
                skill.UseSkill();
            }
        }
    }
}
