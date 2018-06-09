using UnityEngine;

public class ItemClickBehaviour : MonoBehaviour {

    public string GameState;
    public bool InitialState;

    public bool DeactivateColliderOnClick;
    public bool DeactivateGameobjectOnClick;
    public GameObject[] ActivateGameobjects;

    void Start()
    {
        if (GameState != "")
        {
            GameStates.Register(GameState, InitialState);
        }
        else
        {
            Debug.Log("No GameState associated with item " + this.gameObject.name);
        }
    }

    private void OnMouseDown()
    {
        Debug.Log("Click on " + this.gameObject.name);

        if (DeactivateColliderOnClick)
        {
            Debug.Log("Deactivated collider for " + this.gameObject.name);
            this.GetComponent<Collider2D>().enabled = false;
        }

        if (ActivateGameobjects.Length > 0)
        {
            foreach (var go in ActivateGameobjects)
            {
                Debug.Log("Activating gameobject " + go.name);
                go.SetActive(true);
            }
        }

        if (DeactivateGameobjectOnClick)
        {
            Debug.Log("Deactivated gamobject " + this.gameObject.name);
            this.gameObject.SetActive(false);
        }
    }
}
