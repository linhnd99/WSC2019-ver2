package com.example.wsc2019_ss1.Model;

public class SharedData {
    public static SharedData sharedData;
    public SharedData()
    {
        asset = new Asset();
    }

    public Asset asset;
}
