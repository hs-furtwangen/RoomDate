using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DialogController : MonoBehaviour {

    public GameObject UiPannel;
    public GameObject TextPrefab;
    public GameObject ButtonPrefab;

    public GameObject InterestText;
    private Text _interestText;

    public float ButtonVertOffset;

    private List<DialogEntry> dialogTree;

	// Use this for initialization
	void Start () {
        GameStates.Register("yeah", true);

        _interestText = InterestText.GetComponent<Text>();

        dialogTree = JsonConvert.DeserializeObject<List<DialogEntry>>(File.ReadAllText(Application.streamingAssetsPath + "/testdialog.json"));
        LoadId("root");
	}
	
	// Update is called once per frame
	void Update () {
        _interestText.text = GameStates.InterestLevel.ToString();
	}

    public void LoadId(string id)
    {
        DestroyTexts();

        if (id == "")
        {
            Debug.Log("Last id in dialogTree, going to next scene");
            SceneManager.LoadScene("End");
            return;
        }

        DialogEntry DE = new DialogEntry();

        foreach (var de in dialogTree)
        {
            if (de.id.Equals(id))
            {
                DE = de;
            }
        }

        if (DE.id != id)
        {
            Debug.LogError("ID " + id + " not found in dialogTree");
            return;
        }

        if (DE.nextIds != null)
        {
            if (DE.nextIds.Length > 1)
            {
                int count = 0;

                for (int i = 0; i < DE.nextIds.Length; i++)
                {
                    foreach (var de in dialogTree)
                    {
                        if (de.id.Equals(DE.nextIds[i]))
                        {
                            if (!de.used)
                            {
                                bool check = true;
                                if (de.stateDependency != null)
                                {
                                    for (int j = 0; j < de.stateDependency.Length; j++)
                                    {
                                        if (!GameStates.GetState(de.stateDependency[j]))
                                        {
                                            check = false;
                                        }
                                    }
                                }

                                if (check)
                                {
                                    GameObject go = Instantiate(ButtonPrefab, UiPannel.transform);
                                    go.transform.Find("Text").GetComponent<Text>().text = de.text;
                                    go.GetComponent<Button>().onClick.AddListener(delegate { this.LoadId(de.id); });
                                    Vector3 pos = go.transform.localPosition;

                                    if (de.needsInterest != 0 && de.interestValue != 0)
                                    {
                                        if (GameStates.InterestLevel >= de.needsInterest)
                                        {
                                            go.GetComponent<Button>().onClick.AddListener(delegate { GameStates.InterestLevel += de.interestValue; });
                                        }
                                        else
                                        {
                                            go.GetComponent<Button>().onClick.AddListener(delegate { GameStates.InterestLevel -= de.interestValue; });
                                        }
                                    }

                                    pos.y -= ButtonVertOffset * count;

                                    go.transform.localPosition = pos;

                                    count++;
                                }
                            }
                        }
                    }

                }
            }
            else
            {
                // display text
                GameObject go = Instantiate(TextPrefab, UiPannel.transform);
                go.transform.Find("Text").GetComponent<Text>().text = DE.text;

                string next = "";
                if (DE.nextIds != null)
                {
                    next = DE.nextIds[0];
                }
                
                go.GetComponent<Button>().onClick.AddListener(delegate { this.LoadId(next); });

                if (DE.needsInterest != 0 && DE.interestValue != 0)
                {
                    if (GameStates.InterestLevel >= DE.needsInterest)
                    {
                        go.GetComponent<Button>().onClick.AddListener(delegate { GameStates.InterestLevel += DE.interestValue; });
                    }
                    else
                    {
                        go.GetComponent<Button>().onClick.AddListener(delegate { GameStates.InterestLevel -= DE.interestValue; });
                    }
                }
            }
        }
        else
        {
            // display text
            GameObject go = Instantiate(TextPrefab, UiPannel.transform);
            go.transform.Find("Text").GetComponent<Text>().text = DE.text;

            string next = "";
            if (DE.nextIds != null)
            {
                next = DE.nextIds[0];
            }

            go.GetComponent<Button>().onClick.AddListener(delegate { this.LoadId(next); });

            if (DE.needsInterest != 0 && DE.interestValue != 0)
            {
                if (GameStates.InterestLevel >= DE.needsInterest)
                {
                    go.GetComponent<Button>().onClick.AddListener(delegate { GameStates.InterestLevel += DE.interestValue; });
                }
                else
                {
                    go.GetComponent<Button>().onClick.AddListener(delegate { GameStates.InterestLevel -= DE.interestValue; });
                }
            }
        }
        
    }

    private void DestroyTexts()
    {
        for (int i = 0; i < UiPannel.transform.childCount; i++)
        {
            GameObject go = UiPannel.transform.GetChild(i).gameObject;

            Destroy(go);
        }
    }
}
