using UnityEngine;

public class Home : MonoBehaviour
{
    [SerializeField] private GameObject explore;
    [SerializeField] private GameObject home;
    public void TurnExplore()
    {
        explore.SetActive(true);
        home.SetActive(false);
    }
}
