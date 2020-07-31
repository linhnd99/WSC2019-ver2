package com.example.wsc2019_ss3.Model;

import com.google.gson.Gson;
import com.google.gson.annotations.SerializedName;

public class ScheduleModel {
    @SerializedName("ID")
    int ID;
    @SerializedName("Name")
    String Name;
    @SerializedName("ScheduleTypeID")
    int ScheduleTypeID;
    @SerializedName("ScheduleTypeName")
    String ScheduleTypeName;

    public static ScheduleModel fromJson(String json)
    {
        Gson gson = new Gson();
        return gson.fromJson(json,ScheduleModel.class);
    }
    public static String toJson(ScheduleModel scheduleModel)
    {
        Gson gson = new Gson();
        return gson.toJson(scheduleModel);
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

    public int getScheduleTypeID() {
        return ScheduleTypeID;
    }

    public void setScheduleTypeID(int scheduleTypeID) {
        ScheduleTypeID = scheduleTypeID;
    }

    public String getScheduleTypeName() {
        return ScheduleTypeName;
    }

    public void setScheduleTypeName(String scheduleTypeName) {
        ScheduleTypeName = scheduleTypeName;
    }
}
