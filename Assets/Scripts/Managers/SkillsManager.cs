using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillsManager : MonoBehaviour, IGameManager {
    // how to connect player without ser field or tag ? use static ?
    [SerializeField] private GameObject player;

    public ManagerStatus status { get; private set; }
    public SkillsNames selectedSkill = SkillsNames.Teleport;

    public float skillCooldown = 1f;
    public float teleportDistance = 10.0f;
    public int teleportMana = 10;

    private bool skillOnColldown = false;
    private PlayerManager playerManager;

    public void Startup()
    {
        Debug.Log("skills manager starting...");
        playerManager = Managers.Player;

        status = ManagerStatus.Started;
    }

    // Use this for initialization
    void Start () {
		
	}

    public void UseSkill()
    {
        if (!skillOnColldown)
        {
            skillOnColldown = true;

            switch (selectedSkill)
            {
                case SkillsNames.Teleport:
                    UseTeleport();
                    break;

                case SkillsNames.Turret:
                    UseTurret();
                    break;
            }

            StartCoroutine(SetSkillToColldown());
        }
    }

    // tp user to mouse point direction;
    private void UseTeleport()
    {
        if (playerManager.mana > teleportMana)
        {
            Vector3 teleport;
            Vector3 targetPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            //how to avoid setting z to 10 every time?
            targetPoint.z = player.transform.position.z;

            if ((player.transform.position - targetPoint).magnitude < teleportDistance)
            {
                player.transform.position = new Vector3(targetPoint.x, targetPoint.y, 10);
            }

            else
            {
                teleport = player.transform.position + (targetPoint - player.transform.position).normalized * teleportDistance;

                player.transform.position = new Vector3(teleport.x, teleport.y, 10);
            }

            if (playerManager != null)
            {
                playerManager.ChangeMana(-teleportMana);
            }
        }
    }

    private void UseTurret()
    {

    }

    private IEnumerator SetSkillToColldown()
    {
        yield return new WaitForSeconds(skillCooldown);

        skillOnColldown = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            selectedSkill = SkillsNames.Teleport;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            selectedSkill = SkillsNames.Turret;
        }
    }
}
