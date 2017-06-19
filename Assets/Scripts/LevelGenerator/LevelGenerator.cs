using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelGenerator : MonoBehaviour {

    public Transform plaform;
    public Transform crystal;
    public Transform gemsAndCrytal;
    public Transform platform_right_spikes;
    public Transform platform_middle_spikes;
    public Transform jumpTrap;
    public Transform duckTrap;
    public Transform end;
    public int pProbability, pUserScore;
    [SerializeField]
    private RatingMenu Rmenu;

    public int platformCount;
    private int _platformMargin = 15;
    public bool _generated = false;
    public int startingPointX;
    private int _randomNumber;
    private int _normalPlatformProbability = 60;

    // Use this for initialization
    public void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        DontDestroyOnLoad(Rmenu.transform.gameObject);
    }

    public int getProbability()
    {
        return pProbability;
    }

    public int getUserScore()
    {
        return pUserScore;
    }
	
	// Update is called once per frame
	void Update () {
	if(SceneManager.GetActiveScene().name == "AGD-Level" && !_generated)
        {
           Rmenu.GenerateNextLevel();
        }
	}

    public void Generate(int pProbability)
    {
        for (int x = 0; x < platformCount; x++)
        {
            if (x == platformCount - 1)
            {
                Instantiate(end, new Vector3(startingPointX + _platformMargin, 0, 0), Quaternion.identity);
                break;
            }
            _randomNumber = Random.Range(0, 100);

            if (_randomNumber <= _normalPlatformProbability - pProbability)
            {
                int rand = Random.Range(0, 100);
                if(rand > 50)
                {
                Instantiate(plaform, new Vector3(startingPointX + _platformMargin, 0, 0), Quaternion.identity);
                }
                if(rand <= 50)
                {
                    int rand2 = Random.Range(0, 100);
                    if(rand2 >= 75)
                    {
                        Instantiate(crystal, new Vector3(startingPointX + _platformMargin, 0, 0), Quaternion.identity);
                    }
                    else
                    {
                        Instantiate(gemsAndCrytal, new Vector3(startingPointX + _platformMargin, 0, 0), Quaternion.identity);
                    }

                }
            }
            else if (_randomNumber <= 100 && _randomNumber >= 60 -  pProbability)
            {
                int rand = Random.Range(0, 100);
                if (rand <= 50)
                {
                    int rand2 = Random.Range(0, 100);
                    if (rand2 < 50)
                    {
                        Instantiate(jumpTrap, new Vector3(startingPointX + _platformMargin, 0, 0), Quaternion.identity);
                    }
                    else
                    {
                        Instantiate(platform_right_spikes, new Vector3(startingPointX + _platformMargin, -0.1f, 0), Quaternion.identity);
                    }
                    _platformMargin += 2;
                }
                else if (rand <= 100 && rand >= 50)
                {
                    int rand2 = Random.Range(0, 100);
                    if(rand2 <= 50)
                    {
                    Instantiate(duckTrap, new Vector3(startingPointX + _platformMargin, 0, 0), Quaternion.identity);
                    }
                    else if(rand2 > 50)
                    {
                        Instantiate(platform_middle_spikes, new Vector3(startingPointX + _platformMargin, 0, 0), Quaternion.identity);
                    }
                }

            }
            _generated = true;
            _platformMargin += 10;
        }
    }

    public int CalculateProbabilityWithUserInput(int pUserScore, bool pChallanging, bool pFun, int pChallangeLevel, int pFunFactor)
    {
        
        
        if (pChallanging == false && pFun == false) {
            //normal increase in difficulty
            pUserScore *= 5;
            pProbability += 5 * (pChallangeLevel * pFunFactor);
        }
        else if (pChallanging == false && pFun == true)
        {
            //small increase in difficulty
            pUserScore *= 5;
            pProbability += 2 * ((pChallangeLevel * pFunFactor) * pChallangeLevel);
        }
        else if (pChallanging == true && pFun == true)
        {
            //small increase in difficulty
            pUserScore *= 1;
            if(pChallangeLevel < pFunFactor)
            pProbability += 2 *((pChallangeLevel * pFunFactor) / pFunFactor);
        }
        else if (pChallanging == true && pFun == false)
        {
            //small decrease in difficulty.
            pUserScore *= 1;
            pProbability += 2 * (pChallangeLevel * pFunFactor);
        }

        return pProbability;
    }

}
