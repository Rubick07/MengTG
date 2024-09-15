using UnityEngine;

public class Nodes : MonoBehaviour
{
    public Color hoverColor;
    public Vector3 offset;
    public Vector3 offset_pivotbottom;

    [Header("Script Lain")]
    public GameObject Build_Menu;
    public static Nodes build;
    public Interact Is_Range;
    public Nodes_Wood Oke_wood;
    public Nodes_Stone Oke_Stone;
    public Nodes_Mana Oke_Mana;

    [Header("Tipe Turret")]
    public GameObject Wood_turret;
    public GameObject stone_turret;
    public GameObject mana_turret;

    private Nodes nodes;
    private Color StartColor;
    private GameObject turret;
    private Renderer rend;
    private BoxCollider2D box;
    private bool Is_build = false;
    
    void Start()
    {
        rend = GetComponent<Renderer>();
        StartColor = rend.material.color;
        box = GetComponent<BoxCollider2D>();
        nodes = GetComponent<Nodes>();
    }
    private void Awake()
    {
        build = this;
    }
    private void Update()
    {
        if(turret != null)
        {
            rend.material.color = Color.clear;
        }

        //Debug.Log(Is_Range.InRange);
        if(Input.GetMouseButtonDown(1) || Is_Range.InRange == false)
        {
            Close_Build();
        }
        if(Oke_wood.Build == true && turret == null)
        {
            turret = (GameObject)Instantiate(Wood_turret, transform.position + offset, transform.rotation);
            //nodes.enabled = !nodes.enabled;
            Destroy(gameObject);
            //Close_Build();
        }
        else if(Oke_Stone.Build == true && turret == null)
        {
            turret = (GameObject)Instantiate(stone_turret, transform.position + offset, transform.rotation);
            //rend.material.color = Color.clear;
            Destroy(gameObject);

            //Close_Build();
        }
        else if(Oke_Mana.Build == true && turret == null)
        {
            turret = (GameObject)Instantiate(mana_turret, transform.position + offset_pivotbottom, transform.rotation);
            //rend.material.color = Color.clear;
            //box.enabled = !box.enabled;
            Destroy(gameObject);
            //Close_Build();
        }
        
    }

    private void OnMouseDown()
    {
        
        if(turret != null)
        {
            Debug.Log("Ada Turret");
            return;
        }
        
        if(Input.GetMouseButtonDown(0) && Is_Range.InRange == true)
        {
        Is_build = true;
        Build_Menu.SetActive(Is_build);
            return;
        }
        else if (Input.GetMouseButtonDown(0)&& Is_Range.InRange == false)
        {
            Debug.Log("Kejauhan");
            return;
        }
    }


    void OnMouseEnter()
    {
        if (turret != null)
        {
            return;

        }
        rend.material.color = hoverColor;
    }
    void OnMouseExit()
    {
        if(turret != null)
        {
            return;
        }
        rend.material.color = StartColor;

    }

    public void Close_Build()
    {
        Is_build = false;
        //Debug.Log("Plis sir");
        Build_Menu.SetActive(Is_build);
    }
    /*
    public void BuildWood()
    {
        turret = (GameObject)Instantiate(Wood_turret, transform.position + offset, transform.rotation);
        turret.transform.SetParent(gameObject.transform);
    }

    public void BuildStone()
    {
        turret = (GameObject)Instantiate(stone_turret, transform.position + offset, transform.rotation);
        turret.transform.SetParent(gameObject.transform);
    }

    public void BuildMana()
    {
        turret = (GameObject)Instantiate(mana_turret, transform.position + offset_pivotbottom, transform.rotation);

    }
    */
}
