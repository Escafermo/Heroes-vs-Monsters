using UnityEngine;
using System.Collections;

public class DefenderSpawner : MonoBehaviour {

    public Camera myCamera;

    private GameObject defenderParent;
    private CoracaoDisplay coracaoDisplay;
    private float decimalPart;
    private float valor;
     
    void Start()
    {
        defenderParent = GameObject.Find("Defenders");

        coracaoDisplay = GameObject.FindObjectOfType<CoracaoDisplay>();

        if (!defenderParent)
        {
            defenderParent = new GameObject("Defenders");
        }
    }
    
    private void OnMouseDown()
    {
        Vector2 rawPos = CalculateWorldPointMouse();
        Vector2 roundedPos = SnapToGrid(rawPos);
        GameObject defender = Button.selectedDefender;

        //Debug.LogError(rawPos);
       // Debug.LogError(roundedPos);

        decimalPart = (rawPos.y % 1);
      
        int defenderCusto = defender.GetComponent<Defender>().coracaoCusto;

        if (decimalPart <= 0.4 || decimalPart >= 0.6 && roundedPos.x >= 1 && roundedPos.x <= 9 && roundedPos.y >= 1 && roundedPos.y <= 5)
        {
            if (coracaoDisplay.UseCoracao(defenderCusto) == CoracaoDisplay.Status.SUCCESS)
            {
                SpawnDefender(roundedPos, defender);
            }
            else
            {
                Debug.Log("Falta coracao");
            }
        } else
        {
            Debug.LogError("Can't spawn there!");
        }

       
        
    }

    public void SpawnDefender(Vector2 roundedPos, GameObject defender)
    {
        Quaternion zeroRotation = Quaternion.identity;
        GameObject newDefender = Instantiate(defender, roundedPos, zeroRotation) as GameObject;

        newDefender.transform.parent = defenderParent.transform;
    }

    Vector2 SnapToGrid (Vector2 rawWorldPosition)
    {
        float newX = Mathf.RoundToInt(rawWorldPosition.x);
        float newY = Mathf.RoundToInt(rawWorldPosition.y);
        return new Vector2(newX, newY);
    }
    
    Vector2 CalculateWorldPointMouse()
    {

        float mouseX = Input.mousePosition.x;
        float mouseY = Input.mousePosition.y;
        float distanceFromCamera = 10f;

        Vector3 weirdTriplet = new Vector3(mouseX, mouseY, distanceFromCamera);
        Vector2 worldPosition = myCamera.ScreenToWorldPoint(weirdTriplet);

        return worldPosition;
    }


}
