package com.example.wsc2019_ss3.Model;

import com.google.gson.Gson;
import com.google.gson.annotations.SerializedName;

public class PMTask {
    @SerializedName("ID")
    int ID;
    @SerializedName("AssetID")
    int AssetID;
    @SerializedName("AssetName")
    String AssetName;
    @SerializedName("AssetSN")
    String AssetSN;
    @SerializedName("TaskID")
    int TaskID;
    @SerializedName("TaskName")
    String TaskName;
    @SerializedName("PMScheduleTypeID")
    int PMScheduleTypeID;
    @SerializedName("PMScheduleTypeName")
    String PMScheduleTypeName;
    @SerializedName("ScheduleDate")
    String ScheduleDate;
    @SerializedName("ScheduleKilometer")
    int ScheduleKilometer;
    @SerializedName("TaskDone")
    Boolean TaskDone;

    public static PMTask fromJson(String json)
    {
        Gson gson = new Gson();
        return gson.fromJson(json,PMTask.class);
    }
    public static String toJson(Task task){
        Gson gson = new Gson();
        return gson.toJson(task);
    }

    public PMTask() {
    }

    public int getID() {
        return ID;
    }

    public void setID(int ID) {
        this.ID = ID;
    }

    public int getAssetID() {
        return AssetID;
    }

    public void setAssetID(int assetID) {
        AssetID = assetID;
    }

    public String getAssetName() {
        return AssetName;
    }

    public void setAssetName(String assetName) {
        AssetName = assetName;
    }

    public String getAssetSN() {
        return AssetSN;
    }

    public void setAssetSN(String assetSN) {
        AssetSN = assetSN;
    }

    public int getTaskID() {
        return TaskID;
    }

    public void setTaskID(int taskID) {
        TaskID = taskID;
    }

    public String getTaskName() {
        return TaskName;
    }

    public void setTaskName(String taskName) {
        TaskName = taskName;
    }

    public int getPMScheduleTypeID() {
        return PMScheduleTypeID;
    }

    public void setPMScheduleTypeID(int PMScheduleTypeID) {
        this.PMScheduleTypeID = PMScheduleTypeID;
    }

    public String getPMScheduleTypeName() {
        return PMScheduleTypeName;
    }

    public void setPMScheduleTypeName(String PMScheduleTypeName) {
        this.PMScheduleTypeName = PMScheduleTypeName;
    }

    public String getScheduleDate() {
        return ScheduleDate;
    }

    public void setScheduleDate(String scheduleDate) {
        ScheduleDate = scheduleDate;
    }

    public int getScheduleKilometer() {
        return ScheduleKilometer;
    }

    public void setScheduleKilometer(int scheduleKilometer) {
        ScheduleKilometer = scheduleKilometer;
    }

    public Boolean getTaskDone() {
        return TaskDone;
    }

    public void setTaskDone(Boolean taskDone) {
        TaskDone = taskDone;
    }
}


