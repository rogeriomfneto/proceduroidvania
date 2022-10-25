using System.Collections;
using System.Collections.Generic;

public class SceneData {
    public string name;
    public KeysEnum keyType = KeysEnum.None;
    public Dictionary<string, DoorData> doors = new Dictionary<string, DoorData>(4);
    public Stack availableDoors;
    private const int doorsNumber = 4;

    public SceneData(string name) {
        this.name = name;
        for (int i = 0; i < doorsNumber; i++) {
            doors["Door" + (i+1)] = new DoorData("Door" + (i+1));
        }

        this.availableDoors = new Stack();
        this.availableDoors.Push(1);
        this.availableDoors.Push(3);
        this.availableDoors.Push(2);
        this.availableDoors.Push(4);
    }

    public DoorData getDoor(string name) {
        if (doors.ContainsKey(name))
            return doors[name];
        return null;
    }

    public int getAvailableDoor() {
        if (availableDoors.Count == 0) UnityEngine.Debug.LogError("No available doors");
        return (int) availableDoors.Pop();
    }
}