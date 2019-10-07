using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    [SerializeField] UnityEvent winEvent = null;
    [SerializeField] UnityEvent loseEvent = null;

    GameObject currentTree = null;
    GameObject player;

    int currentTreeIndex = 0;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
    }

    private void Start()
    {
        SpawnCheck();
    }

    public int GetTreeIndex() { return currentTreeIndex; }

    public void SpawnCheck(int lightCost = 0)
    {
        if (currentTree == null)
        {
            SpawnTree();
            return;
        }

        if (currentTreeIndex == player.GetComponent<PlantSpawn>().plants.Length)
        {
            GetComponent<LevelLoader>().LoadNextLevel();
            return;
        }

        if (LightCheck(lightCost))
        {
            player.GetComponent<SunlightBar>().LoseLight(lightCost);
            Destroy(currentTree);
            SpawnTree();
        }
    }

    private bool LightCheck(int lightCost)
    {
        if (player.GetComponent<SunlightBar>().GetCurrentPoints() >= lightCost) return true;
        return false;
    }

    private void SpawnTree()
    {
        currentTree = player.GetComponent<PlantSpawn>().Spawning(currentTreeIndex);
        currentTreeIndex += 1;
    }

    public void Lose()
    {
        loseEvent.Invoke();
    }
}