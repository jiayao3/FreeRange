using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChange : MonoBehaviour
{
    private static GameObject curPlayer;
    private static int curPlayerIndex;
    [SerializeField] GameObject player0;
    [SerializeField] GameObject player1;
    [SerializeField] GameObject player2;
    [SerializeField] GameObject player3;
    public static int eggActivated;
    [SerializeField] AudioSource eggSpawnSound;
    [SerializeField] Animator abilityAnimator;

    // Start is called before the first frame update
    void Start()
    {
        curPlayer = player0;
        curPlayerIndex = 0;
        curPlayer.GetComponent<ActivePlayer>().Activate();
        eggActivated = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ActivePlayer(0);
        } else if (Input.GetKeyDown(KeyCode.Alpha2) && player1 != null && eggActivated >= 1)
        {
            ActivePlayer(1);
        } else if (Input.GetKeyDown(KeyCode.Alpha3) && player2 != null && eggActivated >= 2)
        {
            ActivePlayer(2);
        } else if (Input.GetKeyDown(KeyCode.Alpha4) && player3 != null && eggActivated >= 3)
        {
            ActivePlayer(3);
        }

        if (curPlayer == null)
        {
            ActivePlayer(0);
        }

    }

    void ActivePlayer(int player)
    {
        StopAllCoroutines();
        StartCoroutine(OpenUI());
        eggSpawnSound.Play();
        // switch to different player
        if (player != curPlayerIndex)
        {
            // not main player
            if (player != 0)
            {
                // from
                if (curPlayerIndex == 0)
                {
                    player0.GetComponent<ActivePlayer>().Deactivate();
                }
                else
                {
                    Destroy(curPlayer.gameObject);
                }

                // switch to
                if (player == 1)
                {
                    curPlayer = CreatePlayer(player1);
                    gameObject.GetComponent<EggCarry>().DeactiveEgg(player);
                }
                else if (player == 2)
                {
                    curPlayer = CreatePlayer(player2);
                    gameObject.GetComponent<EggCarry>().DeactiveEgg(player);
                }
                else if (player == 3)
                {
                    curPlayer = CreatePlayer(player3);
                    gameObject.GetComponent<EggCarry>().DeactiveEgg(player);
                }
            }
            // switch to main player
            else
            {
                Destroy(curPlayer.gameObject);
                curPlayer = player0;
                player1.GetComponent<ActivePlayer>().Activate();
            }
            gameObject.GetComponent<EggCarry>().ActiveEgg(curPlayerIndex);
            curPlayer.GetComponent<ActivePlayer>().Activate();
            curPlayerIndex = player;
        }
    }

    IEnumerator OpenUI()
    {
        abilityAnimator.SetBool("OpenAbility", true);
        yield return new WaitForSeconds(2f);
        abilityAnimator.SetBool("OpenAbility", false);
    }
    GameObject CreatePlayer(GameObject player)
    {
        GameObject newPlayer = Instantiate(player, player0.transform.position + new Vector3(-(player0.GetComponent<PlayerController>().GetFace()), 1, 0), transform.rotation);

        return newPlayer;
    }

    public static void NewEgg()
    {
        eggActivated++;
    }

    public static GameObject GetCurPlayer()
    {
        return curPlayer;
    }

    public static int getEggActivated()
    {
        return eggActivated;
    }

    public static int GetCurPlayerIndex()
    {
        return curPlayerIndex;
    }

    public static void SetEggActivated(int num)
    {
        eggActivated = num;
    }
}
