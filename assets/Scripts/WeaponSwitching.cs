using UnityEngine;

public class WeaponSwitching : MonoBehaviour
{
    public int SelectedWeapon = 0;
    void Start()
    {
        SelectWeapon();
    }

    void Update()
    {
        int previousSelectedWeapon = SelectedWeapon;
        if (Input.GetAxis("Mouse ScrollWheel") > 0){
            if(SelectedWeapon >= transform.childCount -1){
                SelectedWeapon = 0;
            } else 
                SelectedWeapon++;
            
        }   

        if (Input.GetAxis("Mouse ScrollWheel") < 0){
            if(SelectedWeapon <= 0 ){
                SelectedWeapon = transform.childCount -1;
            } else 
                SelectedWeapon--;
        }

        if (Input.GetKeyDown(KeyCode.Alpha1)){
            SelectedWeapon = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2)&& transform.childCount >= 2){
            SelectedWeapon = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3)&& transform.childCount >= 3){
            SelectedWeapon = 2;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4)&& transform.childCount >= 4){
            SelectedWeapon = 3;
        }

             
        if (previousSelectedWeapon != SelectedWeapon){
            SelectWeapon();
        }
           

    }
    void SelectWeapon (){
        int i = 0;
        foreach (Transform Weapon in transform){
            if (i == SelectedWeapon){
                Weapon.gameObject.SetActive(true);
            } else {
                Weapon.gameObject.SetActive(false);
            }
            i++;
        }
    }
}
