using System.Collections;
using System.Collections.Generic;

public class ScenesConnectionData {
    
    private Dictionary<string, SceneData> scenesData = new Dictionary<string, SceneData>();
    public ScenesConnectionData() {
        init();
    }

    public SceneData getScene(string name) {
        if (!scenesData.ContainsKey(name)) {
            scenesData[name] = new SceneData(name);
        }

        return scenesData[name];
    }

    public void connect(string fromScene, string fromDoor, string toScene, string toDoor) {
        DoorData from = getScene(fromScene).getDoor(fromDoor);
        DoorData to = getScene(toScene).getDoor(toDoor);

        from.active = true;
        from.destinationDoor = toDoor;
        from.destinationScene = toScene;

        to.active = true;
        to.destinationDoor = fromDoor;
        to.destinationScene = fromScene;
    }

    void init() {
        connect("Test", "Door1", "scene2", "Door1");
    }
}