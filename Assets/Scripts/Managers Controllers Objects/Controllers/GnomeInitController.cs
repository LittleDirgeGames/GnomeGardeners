using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GnomeInitController : MonoBehaviour
{
    [SerializeField]
    private GameObject gnomePrefab;
    [SerializeField]
    private List<Transform> playerSpawnLocations;

    private GnomeSkin gnomeSkin;

    private void Start()
    {
        InitPlayerGnomes();
    }

    private void InitPlayerGnomes()
    {
        foreach(PlayerConfig player in GameManager.Instance.PlayerConfigManager.PlayerConfigs)
        {
            GameObject newGnome = Instantiate(gnomePrefab, playerSpawnLocations[player.PlayerIndex].position, Quaternion.identity, transform);
            //We would build the gnomeSkin here.

            newGnome.GetComponent<GnomeController>().InitializePlayer(player);
        }
    }
}
