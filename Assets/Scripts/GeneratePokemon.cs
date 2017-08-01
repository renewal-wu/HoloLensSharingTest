using System.Collections;
using System.Collections.Generic;
using HoloToolkit.Sharing;
using HoloToolkit.Sharing.Spawning;
using HoloToolkit.Sharing.Tests;
using UnityEngine;

public class GeneratePokemon : SyncObjectSpawner
{
    private List<GameObject> pokemons;

    [Tooltip("最多顯示幾隻")]
    public int pokemonCountLimit = 20;

    private float currentTime;

    [Tooltip("產生 Pokemon 的間隔時間")]
    public float generatePokemonInterval = 3f;

    public float XRange = 2f;

    public float YRange = 2f;

    public float ZRange = 0f;

    private int pokemonsCount = 0;

    private void Start()
    {
        //pokemons = new List<GameObject>();
    }

    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime > generatePokemonInterval)
        {
            ReleaseUselessPokemon();
            GeneratePokemonRandom();
            currentTime = 0;
        }
    }

    void ReleaseUselessPokemon()
    {
        //if (IsPokemonCountOverLimit() == false)
        //{
        //    return;
        //}

        //List<GameObject> releasedPokemon = new List<GameObject>();

        //foreach (var pokemon in pokemons)
        //{
        //    if (IsPositionInCamera(pokemon.transform.position))
        //    {
        //        continue;
        //    }

        //    ReleaseTargetPokemon(pokemon);
        //    releasedPokemon.Add(pokemon);
        //}

        //pokemons.RemoveAll(p => releasedPokemon.Contains(p));
    }

    private void ReleaseTargetPokemon(GameObject pokemon)
    {
        Destroy(pokemon);
    }

    void GeneratePokemonRandom()
    {
        if (IsPokemonCountOverLimit())
        {
            return;
        }

        var X = Random.Range(-1f, 1f);
        var Y = Random.Range(0f, 1f);
        var Z = Random.Range(-1f, 1f);
        var position = new Vector3(X, Y, Z);

        var spawnedObject = new SyncSpawnedMewObject();
        Spawn(spawnedObject, position, this.gameObject.transform.rotation, "MewObject", false);

        pokemonsCount++;
    }

    public bool IsPokemonCountOverLimit()
    {
        return pokemonsCount >= pokemonCountLimit;
        //return pokemons.Count >= pokemonCountLimit;
    }

    /// <summary>
    /// 檢查指定的點是否存在於 Camera 中
    /// </summary>
    /// <param name="targetPosition"></param>
    /// <returns></returns>
    private bool IsPositionInCamera(Vector3 targetPosition)
    {
        var relatedPosition = Camera.main.WorldToViewportPoint(targetPosition);

        var x = Mathf.Abs(relatedPosition.x);
        var y = Mathf.Abs(relatedPosition.y);
        var z = Mathf.Abs(relatedPosition.z);

        return x <= XRange && y <= YRange && z <= ZRange;
    }
}
