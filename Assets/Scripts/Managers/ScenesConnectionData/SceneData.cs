using System.Collections;
using System.Collections.Generic;

public class SceneData {
    public string name;
    public KeysEnum keyType = KeysEnum.None;
    public Dictionary<string, DoorData> doors = new Dictionary<string, DoorData>(4);
    public Stack availableDoors;
    private const int doorsNumber = 4;

    private int[] doorsOrder = {2, 4, 1, 3};

    private int[] matchingDoor = {0, 2, 1, 4, 3};

    private int[] secondaryMatchingDoor = {0, 4, 3, 2, 1};


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

    public int getAvailableDoor() {
        foreach (int i in doorsOrder) {
            if (!doors["Door" + i].active) {
                return i;
            }
        }
        UnityEngine.Debug.LogError("Could not find available door for scene: " + name);
        return 0;
    }

    public int getMatchingDoor(int door) {
        int mDoor = matchingDoor[door];
        if (!doors["Door" + mDoor].active) {
            return mDoor;
        }

        mDoor = secondaryMatchingDoor[door];
        if (!doors["Door" + mDoor].active) {
            return mDoor;
        }

        UnityEngine.Debug.LogError("Could not find matching door for door " + door + " and scene " + name);
        return 0;
    }
}