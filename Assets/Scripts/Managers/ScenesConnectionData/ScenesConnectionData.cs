using System.Collections;
using System.Collections.Generic;

public class ScenesConnectionData {
    
    private Dictionary<string, SceneData> scenesData = new Dictionary<string, SceneData>();

    public SceneData getScene(string name) {
        if (!scenesData.ContainsKey(name)) {
            scenesData[name] = new SceneData(name);
        }

        return scenesData[name];
    }

    public void connect(string fromScene, string toScene, KeysEnum keyType) {
        int fromDoorNumber = getScene(fromScene).getAvailableDoor();
        int toDoorNumber = getScene(toScene).getMatchingDoor(fromDoorNumber);

        string fromDoor = "Door" + fromDoorNumber;
        string toDoor = "Door" + toDoorNumber;

        DoorData from = getScene(fromScene).getDoor(fromDoor);
        DoorData to = getScene(toScene).getDoor(toDoor);

        from.active = true;
        from.destinationDoor = toDoor;
        from.destinationScene = toScene;
        from.keyType = keyType;

        to.active = true;
        to.destinationDoor = fromDoor;
        to.destinationScene = fromScene;
        to.keyType = keyType;
    }
}