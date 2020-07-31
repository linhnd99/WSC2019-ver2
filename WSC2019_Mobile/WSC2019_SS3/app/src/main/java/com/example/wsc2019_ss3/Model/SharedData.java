package com.example.wsc2019_ss3.Model;

import java.util.ArrayList;

public class SharedData {
    public static SharedData sharedData;
    public SharedData(){
        listPMTask  = new ArrayList<>();
        listTask = new ArrayList<>();
        listAsset = new ArrayList<>();
        listScheduleModel = new ArrayList<>();
    }
    public ArrayList<Task> listTask;
    public ArrayList<PMTask> listPMTask;
    public ArrayList<Asset> listAsset;
    public ArrayList<ScheduleModel> listScheduleModel;
}
