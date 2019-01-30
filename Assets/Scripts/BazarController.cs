using System.Collections;
using System.Collections.Generic;
using System.Text;
using System;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
//using Boomlagoon.JSON;

public class BazarController : MonoBehaviour {
	
	public string apiUrl = "https://bazar.mfcoin.net/api/";
	public List<int> users_list; // = new List<int>();
	public List<GameObject> user_shops; // = 
	public GameObject shop_prefab;
	public Transform shops_origin;
	public float shopDeltaPosition = 5.0f;
	
	// Use this for initialization
	void Start () {
		initBazar();
	}
	
	public void initBazar() {
		HTTP.GET(apiUrl + "offersbyusers.php", (int code, WWW www) => {
			if (code == HTTP.OK) {
				string html = Encoding.UTF8.GetString(www.bytes, 0, www.bytes.Length);
				loadBazar(html);
			}
		});
	}
	
	void loadBazar(string html) {
		JObject jsonObject = JObject.Parse(html);
		//JSONObject jsonObject = JSONObject.Parse(html);
		//TODO: проверку на status
		//JObject response_data = jsonObject["data"];
		JToken offersObject = jsonObject["data"]["offers"];
		JToken usersObject  = jsonObject["data"]["users"];
		
		int user_ID;
		int users_count = 0;
		int user_index = 0;
		users_list = new List<int>();
		user_shops = new List<GameObject>();
		
		ShopController SC;
		Text user_nick;
		
		foreach(JToken userKeyPair in usersObject) {
			Debug.Log(userKeyPair.ToString());
			/* if(Int32.TryParse(userKeyPair.Key, out user_ID)) {
				users_list.Add(user_ID);
				
				Vector3 shop_position = shops_origin.position + Vector3.forward * shopDeltaPosition * user_index;
				
				GameObject shop_instance = new GameObject();
				shop_instance = Instantiate(shop_prefab, shop_position, Quaternion.identity) as GameObject;
				SC = shop_instance.GetComponent<ShopController>();
				user_nick = SC.user_nick;
				
				Debug.Log(userKeyPair);
				//user_nick.text = userKeyPair.Value.JSONValue("nick");
				
				user_index++;
			} else {
				Debug.Log("can't parse");
			} */
		}
	}
}
