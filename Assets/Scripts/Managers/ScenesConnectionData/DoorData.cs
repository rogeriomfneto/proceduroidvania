public class DoorData {

    public string name;
    public bool active = false;
    public KeysEnum keyType = KeysEnum.None;
    public string destinationScene = "";
    public string destinationDoor = "";
    public DoorData(string name) {
        this.name = name;
    }
}