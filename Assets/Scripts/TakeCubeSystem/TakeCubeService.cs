using System.Collections.Generic;
using GameSystem;
using UnityEngine;

namespace TakeCubeSystem
{
    public class TakeCubeService : MonoBehaviour
    {
        [SerializeField] private List<GameObject> cubesUnderPlayer = new List<GameObject>();
        [SerializeField] private GameObject cubePrefabs;
        [SerializeField] private Transform player;


        private void AddCube()
        {
          player.position = new Vector3(player.position.x, player.position.y + 0.8f, player.position.z);
            GameObject cube = Instantiate(cubePrefabs,
                new Vector3(cubesUnderPlayer[cubesUnderPlayer.Count - 1].transform.position.x, 
                    cubesUnderPlayer[cubesUnderPlayer.Count - 1].transform.position.y - 0.8f, 
                      cubesUnderPlayer[cubesUnderPlayer.Count - 1].transform.position.z),
                      Quaternion.identity, transform);
            cubesUnderPlayer.Add(cube);
        }

        private void CheckListCount()
        {
            if (cubesUnderPlayer.Count == 0)
            {
                GameManager.Instance.LoseGame();
            }
        }

        public void RemoveCube()
        {
            CheckListCount();
            cubesUnderPlayer[(cubesUnderPlayer.Count - 1)].transform.parent = null;
            cubesUnderPlayer.RemoveAt(cubesUnderPlayer.Count - 1);
        }
        
        public void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("Take"))
            {
                AddCube();
                Destroy(other.gameObject);
            }

            if (other.gameObject.CompareTag("Respawn"))
            {
                other.gameObject.layer = 10;
                RemoveCube();
            }
            if (other.gameObject.CompareTag("Finish"))
            {
                GameManager.Instance.WinGame();
            }
        }
    }
}