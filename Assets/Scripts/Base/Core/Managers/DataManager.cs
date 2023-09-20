using System;
using System.IO;
using Newtonsoft.Json;

public class PlayerData
{
    //namify 
    public int _playerLevel = 1;
    public int _playerMoney = 0;
    public int _playerPower = 1;
    public int _playerExperiance = 0;
    public float _playerMoveSpeed = 1;
    public float _playerPunchSpeed = 1;
}

public class DataManager
{
    #region Event
    public event Action NotifyNewPlayerData;
    #endregion

    #region Const Values
    private const string SaveFilePath = "PlayerData.json";
    private const float _levUpMoveSpeedPlus = 0.01f;
    #endregion

    #region Private Variables
    private PlayerData playerData;
    #endregion

    /// <summary>
    /// Data Manager responsible for Saving and Loading player data.
    /// Every script has to reference this script to access player data.
    /// </summary>

    public PlayerData GetPlayerData()
    {
        LoadPlayerData();
        return playerData;
    }

    public void SetExperiance(int exp)
    {
        playerData._playerExperiance += exp;
        if (playerData._playerExperiance >= playerData._playerLevel * 250)
            SetNewLevel();
    }

    public void SetCoin(int coin)
    {
        playerData._playerMoney += coin;
        SavePlayerData();
    }

    private void SetNewLevel()
    {
        playerData._playerLevel += 1;
        playerData._playerPower += 5;
        playerData._playerMoveSpeed += _levUpMoveSpeedPlus;
        SavePlayerData();
        NotifyNewPlayerData?.Invoke();
    }

    private void SavePlayerData()
    {
        string jsonData = JsonConvert.SerializeObject(playerData);
        File.WriteAllText(SaveFilePath, jsonData);
    }

    private void LoadPlayerData()
    {
        if (File.Exists(SaveFilePath))
        {
            string jsonData = File.ReadAllText(SaveFilePath);
            playerData = JsonConvert.DeserializeObject<PlayerData>(jsonData);
            //string json = JsonConvert.SerializeObject(GetPlayerData());
        }
        else
        {
            playerData = new PlayerData();
        }
    }

    //    public void TestVoid()
    //    {
    //#if UNITY_EDITOR
    //        string outputPath = Application.persistentDataPath + "PlayerData_" + ".txt";
    //        bool fileExist = File.Exists(outputPath);
    //        TextReader reader = new StreamReader(outputPath, true);
    //        string data = reader.ReadToEnd();
    //        UnityEngine.Debug.LogError(data);
    //        PlayerData testPlayer;
    //        testPlayer = JsonConvert.DeserializeObject<PlayerData>(data);
    //        UnityEngine.Debug.LogError(testPlayer._playerPower);
    //#else
    //
    //#endif
    // }
}
