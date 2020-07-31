package com.example.wsc2019_ss3.Model;

import com.google.gson.Gson;
import com.google.gson.annotations.SerializedName;

public class Task {
    @SerializedName("ID")
    int ID;
    @SerializedName("Name")
    String Name;

    public static String toJson(Task task){
        Gson gson = new Gson();
        return gson.toJson(task);
    }

    public static Task fromJson(String json)
    {
        Gson gson = new Gson();
        return gson.fromJson(json,Task.class);
    }

    public Task() {
    }

    @Override
    public String toString() {
        return Name;
    }

    public int getID() {
        return ID;
    }

    public void setID(int ID) {
        this.ID = ID;
    }

    public String getName() {
        return Name;
    }

    public void setName(String name) {
        Name = name;
    }
}
