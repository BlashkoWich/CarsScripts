[System.Serializable]
public struct PostStruct
{
    public int place;

    public cars car;

    public playerCfg player;

    [System.Serializable]
    public class cars
    {
        public int id;
        public string colorId;
        public int graffitiId;
        public int rimsId;
        public string engineName;
        public string transmissionName;
        public string gearboxName;
    }
    [System.Serializable]
    public class playerCfg
    {
        public string name;
    }
}


