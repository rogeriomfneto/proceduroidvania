using System.Collections;
using System.Collections.Generic;

public class SceneData {
    public string name;
    public KeysEnum keyType = KeysEnum.None;
    public Dictionary<string, DoorData> doors = new Dictionary<string, DoorData>(4);

    private const int doorsNumber = 4;

    public SceneData(string name) {
        this.name = name;
        for (int i = 0; i < doorsNumber; i++) {
            doors["Door" + (i+1)] = new DoorData("Door" + (i+1));
        }
    }

    public DoorData getDoor(string name) {
        if (doors.ContainsKey(name))
            return doors[name];
        return null;
    }
}