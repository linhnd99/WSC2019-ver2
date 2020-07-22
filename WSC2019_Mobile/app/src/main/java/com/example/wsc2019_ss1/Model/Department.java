package com.example.wsc2019_ss1.Model;

import com.google.gson.Gson;
import com.google.gson.annotations.SerializedName;

public class Department {
    @SerializedName("ID")
    private int ID;
    @SerializedName("Name")
    private String name;

    @Override
    public String toString() {
        return this.name;
    }

    public static Department fromJson(String json){
        Gson gson = new Gson();
        return gson.fromJson(json,Department.class);
    }

    public static String toJson(Department department)
    {
        Gson gson = new Gson();
        return gson.toJson(department);
    }

    public Department() {
    }

    public Department(int ID, String name) {
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
