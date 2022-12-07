using Player;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] private ScoreController _scoreController;
    [SerializeField] private FoxController _foxController;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(GameNames.Enemy.ToString()))
        {
            _foxController.MoveFox = true;
        }
        else if (other.CompareTag(GameNames.Seed.ToString()))
        {
            Destroy(other.transform.parent.gameObject);
            _scoreController.AddSeeds(1);
        }
        else if (other.CompareTag(GameNames.Fox.ToString()))
        {
            SceneManager.LoadScene(0);
        }
    }

}


