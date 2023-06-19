using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class ZombieDeath : MonoBehaviour
{
    public ScoreInGame _scorePlayer;

    [SerializeField] private int _minScoreOfDead;
    [SerializeField] private int _maxScoreOfDead;
    [SerializeField] private ZombiesSounds _zombiesSounds;

    private bool _death = false;

    public bool Death { get => _death; set => _death = value; }

    public void Die(Ragdoll ragdoll, NavMeshAgent navMeshAgent)
    {
        if (!Death)
        {
            AudioSource.PlayClipAtPoint(_zombiesSounds._zombieDeathSound, gameObject.transform.position, 60);
            Death = true;
            ragdoll.AcivateRagdoll();
            navMeshAgent.speed = 0f;
            StartCoroutine(ProcessDeathZombie(0.5f));
        }
    }

    IEnumerator ProcessDeathZombie(float timeForWait)
    {
        yield return new WaitForSeconds(timeForWait);
        _scorePlayer.AddScore(Random.Range(_minScoreOfDead, _maxScoreOfDead));
        Destroy(gameObject);
    }
}
