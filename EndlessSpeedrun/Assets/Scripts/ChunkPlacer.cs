using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkPlacer : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private Chunk[] _chunkPrefabs;

    [SerializeField] private Chunk _firstChunk;

    private List<Chunk> _chunksOnScene = new();

    private void Start()
    {
        _chunksOnScene.Add(_firstChunk);
    }

    private void Update()
    {
        if (_player.position.z > _chunksOnScene[^1].End.position.z - 80)
        {
            CreateChunk();
        }
    }

    private void CreateChunk()
    {
        Chunk newChunk = Instantiate(_chunkPrefabs[Random.Range(0, _chunkPrefabs.Length)]);
        newChunk.transform.position = _chunksOnScene[^1].End.position - newChunk.Begin.localPosition;
        _chunksOnScene.Add(newChunk);

        if (_chunksOnScene.Count > 3)
        {
            Destroy(_chunksOnScene[0].gameObject);
            _chunksOnScene.RemoveAt(0);
        }
    }
}
