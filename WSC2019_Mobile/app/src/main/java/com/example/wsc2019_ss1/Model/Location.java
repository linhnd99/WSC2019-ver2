package com.example.wsc2019_ss1.Model;

import com.google.gson.Gson;
import com.google.gson.annotations.SerializedName;

public class Location {
    @SerializedName("ID")
    private int ID;
    @SerializedName("Name")
    private String name;

    @Override
    public String toString() {
        return this.name;
    }

    public static Location fromJson(String json){
        Gson gson = new Gson();
        return gson.fromJson(json,Location.class);
    }

    public static String toJson(Location location)
    {
        Gson gson = new Gson();
        return gson.toJson(location);
    }

    public Location() {
    }

    public Location(int ID, String name) {
        this.ID = ID;
        this.name = name;
    }

    public int getID() {
        return ID;
    }

    public void setID(int ID) {
        this.ID = ID;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }
}
