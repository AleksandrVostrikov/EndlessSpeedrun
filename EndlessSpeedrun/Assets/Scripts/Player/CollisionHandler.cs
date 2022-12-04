using Player;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] private ScoreController _scoreController;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(GameNames.Enemy.ToString()))
        {
            SceneManager.LoadScene(0);
        }
        else if (other.CompareTag(GameNames.Seed.ToString()))
        {
            Destroy(other.transform.parent.gameObject);
            _scoreController.AddSeeds(1);
        }
    }

}


