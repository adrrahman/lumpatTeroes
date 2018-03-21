using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Data;
using Mono.Data.Sqlite;

public class DatabaseManager : MonoBehaviour {

    private string connectionString;

    public GameObject scorePrefab;
    public Transform scoreParent;

	// Use this for initialization
	void Start () {
        connectionString = "URI=file:" + Application.dataPath + "/Database/score.db";
        // GetScores();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void GetScores()
    {
        using (IDbConnection dbConnection = new SqliteConnection(connectionString))
        {
            dbConnection.Open();

            using(IDbCommand dbCmd = dbConnection.CreateCommand())
            {
                string sqlQuery = "select * from playerScore";

                dbCmd.CommandText = sqlQuery;

                using(IDataReader reader = dbCmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Debug.Log(reader.GetValue(0) + " " + reader.GetValue(1));

                        GameObject temp = Instantiate(scorePrefab);
                        temp.GetComponent<ScoreScript>().SetScore(reader.GetValue(0).ToString(), reader.GetValue(1).ToString());
                        temp.transform.SetParent(scoreParent);
                    }
                    reader.Close();

                }
                
            }
            dbConnection.Close();
        }
    }
}
