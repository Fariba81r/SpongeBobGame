using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Gun : MonoBehaviour {
	public float damage = 10;
	public float range=100f;
	public float impactForce=30f;
	public float firerate=15f;
	public float nextTimeToFire=0.1f;
	public int totalAmmo;
	public int fullAmmo=10;
	private int currentAmmo;
	public float reloadTime = 1f;
	public Camera fpsCam;
	public GameObject impactEffect;
	public ParticleSystem MuzzleFlash;
	public bool Weapon1,Weapon2,Weapon3;
	public bool isReloading=false;
	public bool EndAmmo;
	public Animator animator;
	
	AudioSource weaponSounds;
	public AudioClip shootSound;
	void Start () {
		currentAmmo = fullAmmo;
		weaponSounds = GetComponent<AudioSource> ();
	}
	void OnEnable(){
		isReloading = false;
		animator.SetBool ("Reloading", false);
	}
	
	void Update () {
		if (EndAmmo) {
			isReloading = false;
		}
		if (totalAmmo<=0) {
			EndAmmo = true;
			animator.enabled = false;
		}
		if (totalAmmo>0) {
			animator.enabled = true;
		}
		if (isReloading) {
			return;
		}
		if (currentAmmo<=0 || Input.GetKeyUp(KeyCode.R) && currentAmmo>0) {
			StartCoroutine(Reload());
			return;
		}
		if (Weapon1||Weapon2 ||Weapon3) {
			if (Input.GetButton("Fire1") && Time.time>=nextTimeToFire && currentAmmo>0) {
				nextTimeToFire = Time.time + 1f / firerate;
				weaponSounds.PlayOneShot (shootSound);
				Shoot ();
			}
		}

	}
	IEnumerator Reload(){
		isReloading = true;
		Debug.Log ("Reloading...");
		animator.SetBool ("Reloading", true);
		yield return new WaitForSeconds (reloadTime-0.25f);
		animator.SetBool ("Reloading", false);
		yield return new WaitForSeconds (0.25f);
		AmmoCount ();
		isReloading = false;
	}

	public void AmmoCount(){
		if (totalAmmo>=fullAmmo-currentAmmo) {
			totalAmmo -= fullAmmo - currentAmmo;
			currentAmmo = fullAmmo;
		}
		if (totalAmmo<fullAmmo-currentAmmo) {
			currentAmmo += totalAmmo;
			totalAmmo = 0;
		}
	}
	void Shoot (){
		MuzzleFlash.Play ();
		currentAmmo--;
		RaycastHit hit;
		if (Physics.Raycast(fpsCam.transform.position,fpsCam.transform.forward,out hit,range)) {
			Target target =hit.transform.GetComponent<Target> ();
			if (target != null) {
				target.TakeDamage (damage);
			}
			if (hit.rigidbody !=null) {
				hit.rigidbody.AddForce (-hit.normal * impactForce);
			}
			GameObject impactGo= Instantiate (impactEffect, hit.point, Quaternion.LookRotation (hit.normal));
			Destroy (impactGo,0.1f);
		}
	}
}
