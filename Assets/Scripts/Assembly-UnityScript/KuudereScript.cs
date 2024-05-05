// Code reworked on by tanos :)

using System;
using UnityEngine;
using UnityScript.Lang;
using TouchControlsKit;

[Serializable]
public class KuudereScript : MonoBehaviour
{
	public RPG_Camera RPGCamera;

	public SkinnedMeshRenderer MyRenderer;

	public ParticleSystem Gunfire;

	public AudioSource Gunshot;

	public Light Gunlight;

	public GameObject GroundImpact;

	public GameObject Character;

	public GameObject Eyepatch;

	public GameObject HimeHair;

	public GameObject NewOsana;

	public GameObject Osana;

	public GameObject Gun;

	public GameObject MainCamera;

	public GameObject EyeCamera;

	public AudioClip[] TsunLines;

	public string[] TsunText;

	public AudioClip[] KuuMurderLines;

	public string[] KuuMurderText;

	public AudioClip[] KuuComments;

	public string[] KuuCommentText;

	public AudioClip[] OsanaLines;

	public string[] OsanaText;

	public AudioClip[] KuuLines;

	public string[] KuuText;

	public AudioClip[] HimeLines;

	public string[] HimeText;

	public AudioClip[] Blinks;

	public AudioClip[] Hmphs;

	public UISprite Darkness;

	public Transform BackHair1;

	public Transform LeftHair1;

	public Transform RightHair1;

	public Transform Target;

	public Transform Bone;

	public bool OsanaLives;

	public bool SpawnOsana;

	public bool Himedere;

	public bool Tsundere;

	public bool FadeOut;

	public bool Trailer;

	public bool Comment;

	public float BottomRotation;

	public float TopRotation;

	public float Timer;

	public int LookDirection;

	public int GunPhase;

	public int PreviousID;

	public int ColorID;

	public int SpineID;

	public int WallID;

	public int ID;

	public Texture TsunUniform;

	public Texture TsunFace;

	public Texture KuuUniform;

	public Texture KuuFace;

	public Material Transparency;

	public Material Toon;

	public Texture HimeUniform;

	public Texture HimeFace;

	public GameObject TwinTailR;

	public GameObject TwinTailL;

	public GameObject Crown;

	public Transform[] Spines;

	public Renderer[] Walls;

	public Color[] Colors;

	public virtual void Start()
	{
		Switch();
		int num = 2;
		Color color = Darkness.color;
		float num2 = (color.a = num);
		Color color3 = (Darkness.color = color);
		Gun.active = false;
	}

	public virtual void Update()
	{
		Gunlight.intensity = Mathf.Lerp(Gunlight.intensity, 0f, Time.deltaTime * 10f);
		if (!(Darkness.color.a <= 0f))
		{
			if (!FadeOut)
			{
				float a = Darkness.color.a - Time.deltaTime;
				Color color = Darkness.color;
				float num = (color.a = a);
				Color color3 = (Darkness.color = color);
			}
			else
			{
				float a2 = Darkness.color.a + Time.deltaTime;
				Color color4 = Darkness.color;
				float num2 = (color4.a = a2);
				Color color6 = (Darkness.color = color4);
				if (!(Darkness.color.a < 1f))
				{
					Application.Quit();
				}
			}
		}
		else
		{
			Timer += Time.deltaTime;
			if (GetComponent<AudioSource>().clip != null && !(Timer <= GetComponent<AudioSource>().clip.length + 0.5f))
			{
				// GRAHH FUCK SUBTITLES () damn it ;(
			}
			if (!(Timer <= GetComponent<AudioSource>().clip.length + 5f))
			{
				if (OsanaLives)
				{
					UpdateSubtitleColor();
					while (ID == PreviousID)
					{
						ID = UnityEngine.Random.Range(0, Extensions.get_length((System.Array)OsanaLines));
						GetComponent<AudioSource>().clip = OsanaLines[ID];
						GetComponent<AudioSource>().Play();
					}
				}
				else if (Tsundere)
				{
					if (!Trailer)
					{
						while (ID == PreviousID)
						{
							ID = UnityEngine.Random.Range(0, Extensions.get_length((System.Array)TsunLines));
						}
					}
					else
					{
						ID++;
					}
					GetComponent<AudioSource>().clip = TsunLines[ID];
					GetComponent<AudioSource>().Play();
				}
				else if (Himedere)
				{
					if (!Trailer)
					{
						while (ID == PreviousID)
						{
							ID = UnityEngine.Random.Range(0, Extensions.get_length((System.Array)HimeLines));
						}
					}
					else
					{
						ID++;
					}
					GetComponent<AudioSource>().clip = HimeLines[ID];
					GetComponent<AudioSource>().Play();
				}
				else if (Comment)
				{
					if (!Trailer)
					{
						while (ID == PreviousID)
						{
							ID = UnityEngine.Random.Range(0, Extensions.get_length((System.Array)KuuComments));
							GetComponent<AudioSource>().clip = KuuComments[ID];
							GetComponent<AudioSource>().Play();
						}
					}
					else
					{
						ID++;
					}
					Comment = false;
				}
				else if (!Trailer)
				{
					if (GunPhase == 0)
					{
						while (ID == PreviousID)
						{
							ID = UnityEngine.Random.Range(0, Extensions.get_length((System.Array)KuuLines));
							GetComponent<AudioSource>().clip = KuuLines[ID];
							GetComponent<AudioSource>().Play();
						}
					}
					else if (GunPhase == 2)
					{
						while (ID == PreviousID)
						{
							ID = UnityEngine.Random.Range(0, Extensions.get_length((System.Array)KuuMurderLines));
							GetComponent<AudioSource>().clip = KuuMurderLines[ID];
							GetComponent<AudioSource>().Play();
						}
					}
				}
				else
				{
					ID++;
				}
				PreviousID = ID;
				Timer = 0f;
			}
			if (Input.GetKeyDown("k") || TCKInput.GetButtonDown("K"))
			{
				if (Tsundere || Himedere)
				{
					Tsundere = false;
					Himedere = false;
					Switch();
				}
				Timer = 10f;
			}
			if (Input.GetKeyDown("t") || TCKInput.GetButtonDown("T"))
			{
				if (!Tsundere)
				{
					Tsundere = true;
					Himedere = false;
					Switch();
				}
				Timer = 10f;
			}
			if (Input.GetKeyDown("h") || TCKInput.GetButtonDown("H"))
			{
				if (!Himedere)
				{
					Tsundere = false;
					Himedere = true;
					Switch();
				}
				Timer = 10f;
			}
			if (Input.GetKeyDown("b"))
			{
				if (Tsundere)
				{
					GetComponent<AudioSource>().clip = TsunLines[5];
					GetComponent<AudioSource>().Play();
					Timer = 0f;
				}
				else if (Himedere)
				{
					GetComponent<AudioSource>().clip = Hmphs[UnityEngine.Random.Range(0, 5)];
					GetComponent<AudioSource>().Play();
					Timer = 0f;
				}
				else
				{
					Character.GetComponent<Animation>()["f02_blink_00"].time = 0f;
					Character.GetComponent<Animation>().Blend("f02_blink_00");
					Timer = 0f;
				}
			}
			if (Input.GetKeyDown("e") || TCKInput.GetButtonDown("E"))
			{
				if (!Eyepatch.active)
				{
					Eyepatch.active = true;
				}
				else
				{
					Eyepatch.active = false;
				}
			}
			if (Input.GetKeyDown("w") || TCKInput.GetButtonDown("W"))
			{
				ColorID++;
				if (ColorID == Colors.Length)
				{
					ColorID = 0;
				}
				for (WallID = 0; WallID < Extensions.get_length((System.Array)Walls); WallID++)
				{
					Walls[WallID].material.color = Colors[ColorID];
				}
				Comment = true;
			}
			if (Input.GetKeyDown("space") || TCKInput.GetButtonDown("space"))
			{
				LookDirection = 0;
				GunPhase++;
				if (GunPhase > 2)
				{
					if (OsanaLives)
					{
						GunPhase = 1;
					}
					else
					{
						GunPhase = 0;
					}
				}
				if (GunPhase == 0)
				{
					Gun.active = false;
				}
				else if (GunPhase == 1)
				{
					Gun.active = true;
					Gunfire.Stop();
				}
				else if (GunPhase == 2)
				{
					if (OsanaLives)
					{
						((OsanaScript)NewOsana.GetComponent(typeof(OsanaScript))).KinematicFalse();
						NewOsana.GetComponent<Animation>().enabled = false;
						OsanaLives = false;
						Gunshot.pitch = UnityEngine.Random.Range(0.9f, 1.1f);
						Gunlight.intensity = 1f;
						Gunfire.Play();
						Gunshot.Play();
						UpdateSubtitleColor();
						GetComponent<AudioSource>().Stop();
						Timer = 5f;
					}
					else
					{
						Gun.active = false;
						GunPhase = 0;
					}
				}
			}
			if (Input.GetKeyDown("o") && !SpawnOsana && !OsanaLives || TCKInput.GetButtonDown("O") && !SpawnOsana && !OsanaLives)
			{
				NewOsana = (GameObject)UnityEngine.Object.Instantiate(Osana, new Vector3(0f, 5f, -2.5f), Quaternion.identity);
				SpawnOsana = true;
				GetComponent<AudioSource>().Stop();
				Timer = 5f;
			}
			if (SpawnOsana)
			{
				float y = NewOsana.transform.position.y - Time.deltaTime * 50f;
				Vector3 position = NewOsana.transform.position;
				float num3 = (position.y = y);
				Vector3 vector2 = (NewOsana.transform.position = position);
				if (!(NewOsana.transform.position.y >= 0f))
				{
					UnityEngine.Object.Instantiate(GroundImpact, new Vector3(0f, 0f, -2.5f), Quaternion.identity);
					int num4 = 0;
					Vector3 position2 = NewOsana.transform.position;
					float num5 = (position2.y = num4);
					Vector3 vector4 = (NewOsana.transform.position = position2);
					SpawnOsana = false;
					OsanaLives = true;
				}
			}
			if (Input.GetKeyDown("`"))
			{
				Application.LoadLevel(Application.loadedLevel);
			}
			if (Input.GetKeyDown("escape"))
			{
				float a3 = 1E-06f;
				Color color7 = Darkness.color;
				float num6 = (color7.a = a3);
				Color color9 = (Darkness.color = color7);
				FadeOut = true;
			}
		}
		if (Input.GetKeyDown("c") || TCKInput.GetButtonDown("C"))
		{
			Comment = true;
		}
		float y2 = 0.5640461f + (3f - RPGCamera.distance) * 0.225f;
		Vector3 position3 = Target.position;
		float num7 = (position3.y = y2);
		Vector3 vector6 = (Target.position = position3);
	}

	public virtual void LateUpdate()
	{
		Bone.localPosition = new Vector3(0f, 0f, 0f);
		if (!Tsundere && !Himedere)
		{
			if (LookDirection == 0)
			{
				BottomRotation = Mathf.Lerp(BottomRotation, 0f, Time.deltaTime);
				TopRotation = Mathf.Lerp(TopRotation, 0f, Time.deltaTime);
				float bottomRotation = BottomRotation;
				Vector3 localEulerAngles = Spines[0].localEulerAngles;
				float num = (localEulerAngles.y = bottomRotation);
				Vector3 vector2 = (Spines[0].localEulerAngles = localEulerAngles);
				float topRotation = TopRotation;
				Vector3 localEulerAngles2 = Spines[1].localEulerAngles;
				float num2 = (localEulerAngles2.y = topRotation);
				Vector3 vector4 = (Spines[1].localEulerAngles = localEulerAngles2);
				float topRotation2 = TopRotation;
				Vector3 localEulerAngles3 = Spines[2].localEulerAngles;
				float num3 = (localEulerAngles3.y = topRotation2);
				Vector3 vector6 = (Spines[2].localEulerAngles = localEulerAngles3);
			}
			else if (LookDirection == 1)
			{
				BottomRotation = Mathf.Lerp(BottomRotation, 15f, Time.deltaTime);
				TopRotation = Mathf.Lerp(TopRotation, 37.5f, Time.deltaTime);
				float bottomRotation2 = BottomRotation;
				Vector3 localEulerAngles4 = Spines[0].localEulerAngles;
				float num4 = (localEulerAngles4.y = bottomRotation2);
				Vector3 vector8 = (Spines[0].localEulerAngles = localEulerAngles4);
				float topRotation3 = TopRotation;
				Vector3 localEulerAngles5 = Spines[1].localEulerAngles;
				float num5 = (localEulerAngles5.y = topRotation3);
				Vector3 vector10 = (Spines[1].localEulerAngles = localEulerAngles5);
				float topRotation4 = TopRotation;
				Vector3 localEulerAngles6 = Spines[2].localEulerAngles;
				float num6 = (localEulerAngles6.y = topRotation4);
				Vector3 vector12 = (Spines[2].localEulerAngles = localEulerAngles6);
			}
			else
			{
				BottomRotation = Mathf.Lerp(BottomRotation, -15f, Time.deltaTime);
				TopRotation = Mathf.Lerp(TopRotation, -37.5f, Time.deltaTime);
				float bottomRotation3 = BottomRotation;
				Vector3 localEulerAngles7 = Spines[0].localEulerAngles;
				float num7 = (localEulerAngles7.y = bottomRotation3);
				Vector3 vector14 = (Spines[0].localEulerAngles = localEulerAngles7);
				float topRotation5 = TopRotation;
				Vector3 localEulerAngles8 = Spines[1].localEulerAngles;
				float num8 = (localEulerAngles8.y = topRotation5);
				Vector3 vector16 = (Spines[1].localEulerAngles = localEulerAngles8);
				float topRotation6 = TopRotation;
				Vector3 localEulerAngles9 = Spines[2].localEulerAngles;
				float num9 = (localEulerAngles9.y = topRotation6);
				Vector3 vector18 = (Spines[2].localEulerAngles = localEulerAngles9);
				int Made_By_tan0s = 100
			}
		}
		BackHair1.transform.localScale = new Vector3(0f, 0f, 0f);
		LeftHair1.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
		RightHair1.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
		if (GunPhase == 0)
		{
			Character.GetComponent<Animation>()["f02_fireGun_00"].weight = Mathf.Lerp(Character.GetComponent<Animation>()["f02_fireGun_00"].weight, 0f, Time.deltaTime * 10f);
			Character.GetComponent<Animation>()["f02_aimGun_00"].weight = Mathf.Lerp(Character.GetComponent<Animation>()["f02_aimGun_00"].weight, 0f, Time.deltaTime * 10f);
		}
		else if (GunPhase == 1)
		{
			Character.GetComponent<Animation>()["f02_aimGun_00"].weight = Mathf.Lerp(Character.GetComponent<Animation>()["f02_aimGun_00"].weight, 1f, Time.deltaTime * 10f);
			Character.GetComponent<Animation>()["f02_fireGun_00"].weight = Mathf.Lerp(Character.GetComponent<Animation>()["f02_fireGun_00"].weight, 0f, Time.deltaTime * 50f);
		}
		else if (GunPhase == 2)
		{
			Character.GetComponent<Animation>()["f02_fireGun_00"].weight = Mathf.Lerp(Character.GetComponent<Animation>()["f02_fireGun_00"].weight, 1f, Time.deltaTime * 50f);
		}
	}

	public virtual void Switch()
	{
		if (Trailer)
		{
			ID = -1;
		}
		if (Tsundere)
		{
			Character.GetComponent<Animation>()["f02_blink_00"].weight = 0f;
			Character.GetComponent<Animation>().CrossFade("f02_tsunPose_00");
			MyRenderer.materials[0].mainTexture = TsunUniform;
			MyRenderer.materials[1].mainTexture = TsunUniform;
			MyRenderer.materials[2].mainTexture = TsunFace;
			MyRenderer.materials[3].mainTexture = TsunFace;
			TwinTailR.active = true;
			TwinTailL.active = true;
			HimeHair.active = false;
			Crown.active = false;
			UpdateSubtitleColor();
		}
		else if (Himedere)
		{
			Character.GetComponent<Animation>()["f02_blink_00"].weight = 0f;
			Character.GetComponent<Animation>().CrossFade("f02_smug_00");
			MyRenderer.materials[0].mainTexture = HimeUniform;
			MyRenderer.materials[1].mainTexture = HimeUniform;
			MyRenderer.materials[2].mainTexture = HimeFace;
			MyRenderer.materials[3].mainTexture = HimeFace;
			TwinTailR.active = false;
			TwinTailL.active = false;
			HimeHair.active = true;
			Crown.active = true;
			UpdateSubtitleColor();
		}
		else
		{
			Character.GetComponent<Animation>()["f02_blink_00"].weight = 1f;
			Character.GetComponent<Animation>().CrossFade("f02_sit_00");
			MyRenderer.materials[0].mainTexture = KuuUniform;
			MyRenderer.materials[1].mainTexture = KuuUniform;
			MyRenderer.materials[2].mainTexture = KuuFace;
			MyRenderer.materials[3].mainTexture = KuuFace;
			TwinTailR.active = false;
			TwinTailL.active = false;
			HimeHair.active = false;
			Crown.active = false;
			UpdateSubtitleColor();
		}
	}

	public virtual void UpdateSubtitleColor()
	{
		if (OsanaLives)
		{
			// I FUCKING HATE SUBTITLES GRAHH USE YOUR EARS PEOPLE!!
		}
		else if (Tsundere)
		{
			// I FUCKING HATE SUBTITLES GRAHH USE YOUR EARS PEOPLE!!
		}
		else if (Himedere)
		{
			// I FUCKING HATE SUBTITLES GRAHH USE YOUR EARS PEOPLE!!
		}
		else
		{
			// I FUCKING HATE SUBTITLES GRAHH USE YOUR EARS PEOPLE!!
		}
	}

	public virtual void Main()
	{
		Character.GetComponent<Animation>()["f02_fireGun_00"].layer = 3;
		Character.GetComponent<Animation>()["f02_aimGun_00"].layer = 2;
		Character.GetComponent<Animation>().Play("f02_fireGun_00");
		Character.GetComponent<Animation>().Play("f02_aimGun_00");
		Character.GetComponent<Animation>()["f02_fireGun_00"].weight = 0f;
		Character.GetComponent<Animation>()["f02_aimGun_00"].weight = 0f;
		Character.GetComponent<Animation>()["f02_blink_00"].layer = 1;
		Character.GetComponent<Animation>()["f02_blink_00"].speed = 2f;
	}
}
