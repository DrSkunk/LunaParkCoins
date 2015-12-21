using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class MainScript : MonoBehaviour
{
    public GameObject scoreText;
    public GameObject coinPrefab;
    public GameObject coinsHolder;
    private int score = 100;
    private List<GameObject> coins
    {
        get
        {
            List<GameObject> ret = new List<GameObject>();
            for (int i = 0; i < coinsHolder.transform.childCount; i++)
            {
                ret.Add(coinsHolder.transform.GetChild(i).gameObject);
            }
            return ret;
        }
    }

    void Start()
    {
        UpdateScoreText();
        InitBoard();
    }

    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit) && hit.transform.gameObject != null && hit.transform.tag == "CoinPlacer" && score > 0)
            {
                score--;
                UpdateScoreText();
                Vector3 point = new Vector3(hit.point.x, hit.point.y, hit.point.z - 1);
                GameObject coin = (GameObject)Instantiate(coinPrefab, point, Quaternion.Euler(90, 0, 0));
                coin.transform.SetParent(coinsHolder.transform);
            }
        }
    }

    private void InitBoard()
    {
        int ROWWIDTH = 8;

        for (int z = -8; z <= -2; z += 2)
        {
            for (int x = -ROWWIDTH; x <= ROWWIDTH; x++)
            {
                Vector3 point = new Vector3(x, 0, z);
                GameObject coin = (GameObject)Instantiate(coinPrefab, point, Quaternion.identity);
                coin.transform.SetParent(coinsHolder.transform);

                point = new Vector3(x - .5f, 0, z - 1);
                coin = (GameObject)Instantiate(coinPrefab, point, Quaternion.identity);
                coin.transform.SetParent(coinsHolder.transform);

                if (x == ROWWIDTH)
                {
                    point = new Vector3(x + .5f, 0, z - 1);
                    coin = (GameObject)Instantiate(coinPrefab, point, Quaternion.identity);
                    coin.transform.SetParent(coinsHolder.transform);
                }
            }
        }
    }

    public void UpdateScore(bool add)
    {
        score = add ? score + 1 : score - 1;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        scoreText.GetComponent<Text>().text = score.ToString();

    }
}
